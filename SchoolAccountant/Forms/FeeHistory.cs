using System.Windows.Forms;

namespace SchoolAccountant.Forms
{
    public partial class FeeHistory : Form
    {
        readonly DataGridViewRow _row = new DataGridViewRow();
        public FeeHistory(DataGridViewRow row)
        {
            InitializeComponent();
            _row = row;
        }
    }
}
