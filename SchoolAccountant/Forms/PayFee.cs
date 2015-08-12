using System;
using System.Linq;
using System.Windows.Forms;
using BusinessLogic.Constants;
using BusinessLogic.Entities;
using BusinessLogic.Interface;
using BusinessLogic.Repositories;
using SchoolAccountant.Helpers;

namespace SchoolAccountant.Forms
{
    public partial class PayFee : Form
    {
        readonly DataGridViewRow _row;
        private readonly ISchoolRepository _schoolRepository = new SchoolRepository();
        private readonly IStudentRepository _studentRepository = new StudentRepository();
        private readonly IClassTermFeeRepository _classTermFeeRepository = new ClassTermFeeRepository();

        public PayFee(DataGridViewRow row)
        {
            InitializeComponent();
            _row = row;
            Utilities.InitializeSessionCombo(new[] {cboSession});
            Utilities.InitialiizeTermCombo(new[] {cboTerm});
        }

        private void PayFee_Load(object sender, EventArgs e)
        {
            lblFullName.Text = _row.Cells["FullName"].Value.ToString().ToUpper();
            lblClass.Text = _row.Cells["PresentClass"].Value.ToString();
            tboAmount.Text = _row.Cells["OutstandingFee"].Value.ToString();

            // Load school details
            var school = _schoolRepository.Get();
            cboSession.SelectedValue = school.PresentSession;
            cboTerm.SelectedIndex = (int) school.PresentTermEnum + 1;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var session = cboSession.SelectedValue;
            var term = cboTerm.SelectedValue;
            var amount = tboAmount.Text;

            if (session != "" && term != "" && !string.IsNullOrWhiteSpace(amount))
            {
                decimal result;

                if (decimal.TryParse(amount, out result))
                {
                    var id = _row.Cells["Id"].Value.ToString();
                    var classEnum = (ClassEnum) _row.Cells["PresentClassEnum"].Value;
                    var classTermFee =
                        _classTermFeeRepository.GetCurrentFees().FirstOrDefault(x => x.ClassEnum == classEnum);

                    var student = _studentRepository.GetStudentById(id);

                    // Update student fees
                    var feePayment = new FeePayment()
                    {
                        Amount = Convert.ToDecimal(amount),
                        HasCollectedReceipt = chkPrintReceipt.Checked,
                        PaidDate = DateTime.Now,
                        ClassArmTermFeeId = classTermFee.Id
                    };

                    student.FeePayments.Add(feePayment);
                    student.OutstandingFee -= Convert.ToDecimal(amount);
                    var updateSuccess = _studentRepository.Update(student);

                    // If print receipt check box is checked, open pdf file(recipt)
                    // and save copy to student folder, update if not exist, else create

                    // Else save copy to student folder, update if not exist, else create

                    // 
                }
                else
                {
                    MessageBox.Show(@"Please, enter correct amount in the amount field", @"School Accountant");
                }
            }
            else
            {
                MessageBox.Show(@"Please, ensure that the session, term and the amount is filled", @"School Accountant");
            }
        }
    }
}
