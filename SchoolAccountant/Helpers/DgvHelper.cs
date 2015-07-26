using System.Drawing;
using System.Windows.Forms;

namespace SchoolAccountant.Helpers
{
    public class DgvHelper
    {
        public DataGridView Dgv = new DataGridView();

        public DgvHelper(DataGridView dataGridView, object dataSource)
        {
            Dgv = dataGridView;
            Dgv.DataSource = dataSource;
        }


        public DgvHelper Properties(string font = "Courier New", int fontSize = 9, Color foreColor = default(Color), Color backColor = default(Color), BorderStyle borderStyle = default(BorderStyle), bool virtualMode = false, bool rowHeaderVisible = false)
        {

            Dgv.VirtualMode = virtualMode;
            Dgv.RowHeadersVisible = rowHeaderVisible;
            Dgv.DefaultCellStyle.Font = new Font(font, fontSize);
            Dgv.DefaultCellStyle.ForeColor = foreColor;
            Dgv.DefaultCellStyle.BackColor = backColor;
            Dgv.BorderStyle = borderStyle;
            return this;
        }

        public DgvHelper Header(string font = "Courier New", int fontSize = 9, Color foreColor = default(Color), Color backColor = default(Color), char alignment = 'L')
        {
            Dgv.ColumnHeadersDefaultCellStyle.BackColor = backColor;
            Dgv.ColumnHeadersDefaultCellStyle.ForeColor = foreColor;
            Dgv.ColumnHeadersDefaultCellStyle.Font = new Font(font, fontSize);
            Dgv.ColumnHeadersDefaultCellStyle.Alignment = alignment == 'M'
                                                                     ? DataGridViewContentAlignment.MiddleCenter
                                                                     : DataGridViewContentAlignment.MiddleLeft;
            Dgv.AutoResizeColumnHeadersHeight();

            return this;
        }

        public DgvHelper Add(int columnIndex, string name, string headerText, Color foreColor = default(Color), Color backColor = default(Color), int width = default(int), char alignment = 'L', string format = default(string), bool readOnly = false, bool frozen = false, bool visible = true)
        {
            Dgv.Columns[name].DefaultCellStyle.Format = format;
            Dgv.Columns[name].DefaultCellStyle.ForeColor = foreColor;
            Dgv.Columns[name].DefaultCellStyle.BackColor = backColor;
            // Dgv.Columns[name].DefaultCellStyle.Font = new Font(font, fontSize);
            Dgv.Columns[name].HeaderText = headerText;
            Dgv.Columns[name].Width = width;
            Dgv.Columns[name].Visible = visible;
            Dgv.Columns[name].ReadOnly = readOnly;
            Dgv.Columns[name].Frozen = frozen;
            Dgv.Columns[name].DefaultCellStyle.Alignment = alignment == 'M'
                                                                     ? DataGridViewContentAlignment.MiddleCenter
                                                                     : DataGridViewContentAlignment.MiddleLeft;
            Dgv.Columns[name].DisplayIndex = columnIndex;
            return this;
        }

        public void For(DataGridView dataGridView)
        {
            Dgv = dataGridView;
        }
    }
}
