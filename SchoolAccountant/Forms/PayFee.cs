using System;
using System.Windows.Forms;

namespace SchoolAccountant.Forms
{
    public partial class PayFee : Form
    {
        readonly DataGridViewRow _row;
        public PayFee(DataGridViewRow row)
        {
            InitializeComponent();
            _row = row;
        }

        private void PayFee_Load(object sender, EventArgs e)
        {
            lblFullName.Text = _row.Cells["FullName"].Value.ToString().ToUpper();
            lblClass.Text = _row.Cells["PresentClass"].Value.ToString();

        }
    }
}
