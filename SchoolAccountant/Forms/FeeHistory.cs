using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
