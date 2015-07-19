using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolAccountant
{
    public class Utilities
    {
       

        public static void InitialiizeClassCombo(IEnumerable<ComboBox> comboBoxes)
        {
            var nameAndValues = new BindingList<NameAndValue>();

            var names = new[] { "JSS 1", "JSS 2", "JSS 3", "SSS 1", "SSS 2", "SSS 3" };
            var values = Enumerable.Range(1, 6).ToArray();

            for (int i = 0; i < names.Length; i++)
            {
                nameAndValues.Add(new NameAndValue(names[i], values[i]));
            }

            foreach (var comboBox in comboBoxes)
            {
                comboBox.DataSource = nameAndValues;
                comboBox.DisplayMember = "Name";
                comboBox.ValueMember = "Value";
            }

        }

        public static void InitialiizeTermCombo(IEnumerable<ComboBox> comboBoxes)
        {
            var nameAndValues = new BindingList<NameAndValue>();

            var names = new[] { "First", "Second", "Third" };
            var values = Enumerable.Range(1, 3).ToArray();

            for (int i = 0; i < names.Length; i++)
            {
                nameAndValues.Add(new NameAndValue(names[i], values[i]));
            }

            foreach (var comboBox in comboBoxes)
            {
                comboBox.DataSource = nameAndValues;
                comboBox.DisplayMember = "Name";
                comboBox.ValueMember = "Value";
            }

        }
    }
}
