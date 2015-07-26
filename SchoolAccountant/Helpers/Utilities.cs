using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace SchoolAccountant.Helpers
{
    public class Utilities
    {
        /// <summary>
        /// Initializes the class combo boxes
        /// </summary>
        /// <param name="comboBoxes">A list of combo boxes</param>
        public static void InitialiizeClassCombo(IEnumerable<ComboBox> comboBoxes)
        {
            var nameAndValues = new BindingList<NameAndValue>();

            var names = new[] { "", "JSS 1", "JSS 2", "JSS 3", "SSS 1", "SSS 2", "SSS 3" };
            var values = Enumerable.Range(-1, 7).ToArray();

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

        /// <summary>
        /// Initializes the list of Term combo boxes
        /// </summary>
        /// <param name="comboBoxes">List of combo boxes</param>
        public static void InitialiizeTermCombo(IEnumerable<ComboBox> comboBoxes)
        {
            var nameAndValues = new BindingList<NameAndValue>();

            var names = new[] { "", "First", "Second", "Third" };
            var values = Enumerable.Range(-1, 4).ToArray();

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

        /// <summary>
        /// Initializes the list of Class Arm combo boxes
        /// </summary>
        /// <param name="comboBoxes">List of combo boxes</param>
        public static void InitialiizeArmCombo(IEnumerable<ComboBox> comboBoxes)
        {
            var nameAndValues = new BindingList<NameAndValue>();

            var names = new[] {"", "A", "B", "C", "D"};
            var values = Enumerable.Range(-1, 5).ToArray();

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

        /// <summary>
        /// Initialize the fee status combo boxes
        /// </summary>
        /// <param name="comboBoxes">A list of combo boxes</param>
        public static void InitialiizeFeeStatusCombo(IEnumerable<ComboBox> comboBoxes)
        {
            var nameAndValues = new BindingList<NameAndValue>();

            var names = new[] { "", "Owing", "Not Owning" };
            var values = Enumerable.Range(-1, 3).ToArray();

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
