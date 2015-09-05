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
    public partial class ViewInfo : Form
    {
        readonly DataGridViewRow _row;
        private readonly IStudentRepository _studentRepository = new StudentRepository();

        public ViewInfo(DataGridViewRow row)
        {
            InitializeComponent();
            _row = row;
            Utilities.InitialiizeArmCombo(new[] { cboPresentArm });
            btnEdit.Enabled = false;
        }

        private void ViewInfo_Load(object sender, EventArgs e)
        {

            tboFirstName.Text = _row.Cells["FirstName"].Value.ToString();
            tboLastName.Text = _row.Cells["LastName"].Value.ToString();
            tboMiddleName.Text = _row.Cells["MiddleName"].Value.ToString();
            dtpBirthDate.Text = _row.Cells["BirthDate"].Value.ToString();
            lblClasStarted.Text = _row.Cells["StartClass"].Value.ToString();
            lblOutstandingFees.Text = _row.Cells["OutstandingFee"].Value.ToString();
            lblTermStarted.Text = _row.Cells["StartTerm"].Value.ToString();
            dtpDateStarted.Text = _row.Cells["StartDate"].Value.ToString();

            // Trimmed out the Arms
            lblPresentClass.Text = _row.Cells["PresentClass"].Value.ToString().Substring(0, 4);

            lblFeesPaid.Text = _row.Cells["PaidFee"].Value.ToString();
            cboPresentArm.Text = _row.Cells["PresentArm"].Value.ToString();

            // Register all controls on the form to respond to the form content change event
            AddHandlers();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var response = MessageBox.Show(@"You made some changes, Do you want to save the changes for this student?",
                @"Update Student", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (response == DialogResult.Yes)
            {
                var student = new Student
                {
                    MiddleName = tboMiddleName.Text,
                    LastName = tboLastName.Text,
                    FirstName = tboFirstName.Text,
                    BirthDate = DateTime.Parse(dtpBirthDate.Text),
                    StartDate = DateTime.Parse(dtpDateStarted.Text),
                    PresentArm = (ArmEnum) cboPresentArm.SelectedValue,
                    Id = _row.Cells["Id"].Value.ToString()

                };

                var success = _studentRepository.Edit(student);
                if (success)
                {
                    MessageBox.Show(@"Student has been updated");
                }
            }
           
        }

        private void AddHandlers()
        {
            foreach (var control in Controls.OfType<TextBox>())
            {
                control.TextChanged += OnContentChanged;
            }
            foreach (var control in Controls.OfType<ComboBox>())
            {
                control.SelectedIndexChanged += OnContentChanged;
            }
            foreach (var picker in Controls.OfType<DateTimePicker>())
            {
                picker.TextChanged += OnContentChanged;
            }
        }

        protected void OnContentChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = true;
        }



    }
}
