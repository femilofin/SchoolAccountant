using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BusinessLogic.Constants;
using BusinessLogic.Entities;
using BusinessLogic.Interface;
using BusinessLogic.Repositories;
using iTextSharp.text.pdf;
using SchoolAccountant.Helpers;
using SchoolAccountant.Models;

namespace SchoolAccountant.Forms
{
    public partial class FeeHistory : Form
    {
        readonly DataGridViewRow _row;
        private readonly IClassTermFeeRepository _classTermFeeRepository = new ClassTermFeeRepository();

        readonly DataGridViewLinkColumn _llbPrintReceipt = new DataGridViewLinkColumn();

        public FeeHistory(DataGridViewRow row)
        {
            InitializeComponent();
            _row = row;
        }

        private void FeeHistory_Load(object sender, System.EventArgs e)
        {
            lblStudentName.Text = $"Name: {_row.Cells["FullName"].Value.ToString().ToUpper()}";
            RefreshDgvFeeHistory();
        }

        private void RefreshDgvFeeHistory()
        {
            var dataSource = GetDataSource();
            FillDgvFeeHistory(dataSource);
        }

        private List<FeeHistoryModel> GetDataSource()
        {
            List<FeePayment> feePayments = _row.Cells["FeePayments"].Value as List<FeePayment>;

            List<FeeHistoryModel> feeHistoryModels = new List<FeeHistoryModel>();

            if (feePayments != null)
            {
                var indexes = Enumerable.Range(1, feePayments.Count).ToList();

                var student = new Student()
                {
                    FirstName = _row.Cells["FirstName"].Value.ToString(),
                    LastName = _row.Cells["LastName"].Value.ToString(),
                    MiddleName = _row.Cells["MiddleName"].Value.ToString()
                };

                for (int i = 0; i < feePayments.Count; i++)
                {
                    ClassTermFee classTermFee = GetClassTermFeeById(feePayments[i].ClassArmTermFeeId);

                    feeHistoryModels.Add(new FeeHistoryModel()
                    {
                        Index = indexes[i],
                        Session = classTermFee.Session,
                        Term = Enum.GetName(typeof (TermEnum), classTermFee.TermEnum),
                        PaidFee = feePayments[i].Amount.ToString(),
                        OutstandingFee = _row.Cells["OutstandingFee"].Value.ToString(),
                        DatePaid = feePayments[i].PaidDate,
                        FilePath = Utilities.GetFilePath(student, classTermFee)
                    });

                }
                return feeHistoryModels;
            }
            return new List<FeeHistoryModel>();
        }

        private ClassTermFee GetClassTermFeeById(string classTermFeeId) => _classTermFeeRepository.GetClassTermFeeById(classTermFeeId);

        private void FillDgvFeeHistory(object dataSource)
        {
            var dgvHelper = new DgvHelper(dgvFeeHistory, dataSource);
            dgvHelper.Properties(borderStyle: BorderStyle.Fixed3D, font: "Arial", fontSize: 8)
                .Header(fontSize: 8, font: "Arial")
                .Add(0, "Index", "", width: 20, readOnly: true, visible: true)
                .Add(1, "Session", "Session", width: 80, readOnly: true, visible: true)
                .Add(2, "Term", "Term", width: 50, readOnly: true, visible: true)
                .Add(4, "OutstandingFee", "Outstanding Fee", width: 80, readOnly: true, visible: true, alignment: 'R')
                .Add(3, "PaidFee", "Fees Paid (Naira)", width: 80, readOnly: true, visible: true, alignment: 'R')
                .Add(5, "DatePaid", "Date Paid", width: 120, readOnly: true, visible: true)
                .Add(6, "FilePath", "FilePath", width: 120, readOnly: true);
                

            // Add "Pay Fee" button
            _llbPrintReceipt.Text = "Print Receipt";
            _llbPrintReceipt.UseColumnTextForLinkValue = true;

            dgvFeeHistory.Columns.Insert(7, _llbPrintReceipt);

            dgvFeeHistory.AllowUserToResizeRows = false;

        }

        private void dgvFeeHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvFeeHistory.Rows[e.RowIndex];
            string path = row.Cells["FilePath"].Value.ToString();

            // link label print receipt is in cell 7
            if (e.ColumnIndex == 7)
            {
                Utilities.SendToPrinter(path);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
