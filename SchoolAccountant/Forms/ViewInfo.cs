using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SchoolAccountant.Helpers;

namespace SchoolAccountant.Forms
{
    public partial class ViewInfo : Form
    {
        readonly DataGridViewRow _row;
        public ViewInfo(DataGridViewRow row)
        {
            InitializeComponent();
            _row = row;
            Utilities.InitialiizeArmCombo(new[] { cboPresentArm });

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




        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
