using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic.Interface;
using BusinessLogic.Repositories;

namespace SchoolAccountant.Forms
{
    public partial class ChangeFees : Form
    {
        private DataGridViewRow _row;
        private readonly IStudentRepository _studentRepository = new StudentRepository();

        public ChangeFees(DataGridViewRow row)
        {
            InitializeComponent();
            _row = row;
        }

        private void ChangeFees_Load(object sender, EventArgs e)
        {
            llStudentName.Text = _row.Cells["FullName"].Value.ToString();
            llPresentAmount.Text = _row.Cells["OutstandingFee"].Value.ToString();
        }

        private void btnChangeFees_Click(object sender, EventArgs e)
        {
            var newAmount = tboNewAmount.Text.Replace(",", "");

            decimal result;

            if (decimal.TryParse(newAmount, out result))
            {
                var id = _row.Cells["Id"].Value.ToString();

                // Change Fees
                var success = _studentRepository.ChangeOutstandingFees(id, Convert.ToDecimal(newAmount));

                if (success)
                {
                    MessageBox.Show(@"Fees successfully changed", @"Change Fees");
                    Close();
                }
            }
            else
            {
                MessageBox.Show(@"Please, enter correct amount in the amount field.", @"School Accountant");
            }
        }
    }
}
