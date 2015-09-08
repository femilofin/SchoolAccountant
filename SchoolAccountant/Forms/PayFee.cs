using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using BusinessLogic.Constants;
using BusinessLogic.Entities;
using BusinessLogic.Interface;
using BusinessLogic.Repositories;
using SchoolAccountant.Helpers;
using SchoolAccountant.Models;

namespace SchoolAccountant.Forms
{
    public partial class PayFee : Form
    {
        readonly DataGridViewRow _row;
        private readonly string _username;
        private readonly ISchoolRepository _schoolRepository = new SchoolRepository();
        private readonly IStudentRepository _studentRepository = new StudentRepository();
        private readonly IClassTermFeeRepository _classTermFeeRepository = new ClassTermFeeRepository();
        private PrintPreviewDialog _printPreviewDialog = new PrintPreviewDialog();
        private PrintDocument _printDocument = new PrintDocument();
        private string _documentContents;

        private School _school;

        public PayFee(DataGridViewRow row, string username)
        {
            InitializeComponent();

            _row = row;
            _username = username;
            Utilities.InitializeSessionCombo(new[] { cboSession });
            Utilities.InitialiizeTermCombo(new[] { cboTerm });
        }

        private void PayFee_Load(object sender, EventArgs e)
        {
            lblFullName.Text = _row.Cells["FullName"].Value.ToString().ToUpper();
            lblClass.Text = _row.Cells["PresentClass"].Value.ToString();
            tboAmount.Text = _row.Cells["OutstandingFee"].Value.ToString();
            chkPrintReceipt.Checked = true;

            // Load school details
            _school = _schoolRepository.Get();
            cboSession.SelectedValue = _school.PresentSession;
            cboTerm.SelectedIndex = (int)_school.PresentTermEnum + 1;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var session = cboSession.SelectedValue;
            var term = cboTerm.SelectedValue;
            var amount = tboAmount.Text;
            var paidBy = tboPaidBy.Text;

            if (session != "" && term != "" && !string.IsNullOrWhiteSpace(paidBy) && !string.IsNullOrWhiteSpace(amount))
            {
                decimal result;

                if (decimal.TryParse(amount, out result))
                {
                    var id = _row.Cells["Id"].Value.ToString();
                    var classEnum = (ClassEnum)_row.Cells["PresentClassEnum"].Value;

                    // session, class, 
                    var classTermFee = _classTermFeeRepository.GetFees(session.ToString(), (TermEnum)term, classEnum);

                    var student = _studentRepository.GetStudentById(id);

                    // Update student fees
                    var feePayment = new FeePayment()
                    {
                        Amount = Convert.ToDecimal(amount),
                        PaidDate = DateTime.Now,
                        ClassArmTermFeeId = classTermFee.Id,
                        HasCollectedReceipt = chkPrintReceipt.Checked,
                        Bank = tboBank.Text == "" ? null : tboBank.Text,
                        ReceiptNumber = tboReceiptNo.Text == "" ? null : tboReceiptNo.Text,
                        ChequeNumber = tboChequeNo.Text == "" ? null : tboChequeNo.Text,
                        Comment = rtboComment.Text == "" ? null : rtboComment.Text,
                        PaidBy = tboPaidBy.Text
                    };

                    student.FeePayments.Add(feePayment);
                    student.OutstandingFee -= Convert.ToDecimal(amount);
                    student.PaidFee += Convert.ToDecimal(amount);

                    var updateSuccess = _studentRepository.Update(student);

                    if (updateSuccess)
                    {
                        MessageBox.Show(@"Fees paid", @"Pay Fees");

                        var receiptModel = new ReceiptModel()
                        {
                            ClassTermFee = classTermFee,
                            Student = student,
                            School = _school
                        };

                        // Generate receipt 
                        var receipt = new ReceiptGenerator(receiptModel);
                        var path = receipt.Generate();

                        Close();

                        // If print receipt check box is checked, open pdf file(recipt)
                        if (chkPrintReceipt.Checked)
                        {
                            //Process.Start(path);
                           // _printDocument.DocumentName = path;
                            //_printPreviewDialog.Document = _printDocument;
                           // _printPreviewDialog.ShowDialog();

                            //PrintDialog pDialog = new PrintDialog();
                            //pDialog.Document = _printDocument;
                            //if (pDialog.ShowDialog() == DialogResult.OK)
                            //{
                              //  _printDocument.DocumentName = path;
                               // _printDocument.Print();
                          //  }
                          Utilities.SendToPrinter(path);
                        }

                    }

                }
                else
                {
                    MessageBox.Show(@"Please, enter correct amount in the amount field.", @"School Accountant");
                }
            }
            else
            {
                MessageBox.Show(@"Please, ensure that the session, paidby, term and the amount is filled", @"School Accountant");
            }
        }

       
    }
}
