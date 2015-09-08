using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using BusinessLogic.Constants;
using BusinessLogic.Entities;
using SchoolAccountant.Models;
using static System.Environment;

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
            foreach (var comboBox in comboBoxes)
            {
                var nameAndValues = new BindingList<NameAndValue>();

                var names = new[] { "", "JSS 1", "JSS 2", "JSS 3", "SSS 1", "SSS 2", "SSS 3" };
                var values = Enumerable.Range(-1, 7).ToArray();

                for (int i = 0; i < names.Length; i++)
                {
                    nameAndValues.Add(new NameAndValue(names[i], values[i]));
                }


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
            foreach (var comboBox in comboBoxes)
            {
                var nameAndValues = new BindingList<NameAndValue>();

                var names = new[] { "", "First", "Second", "Third" };
                var values = Enumerable.Range(-1, 4).ToArray();

                for (int i = 0; i < names.Length; i++)
                {
                    nameAndValues.Add(new NameAndValue(names[i], values[i]));
                }

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
            foreach (var comboBox in comboBoxes)
            {
                var nameAndValues = new BindingList<NameAndValue>();

                var names = new[] { "", "A", "B", "C", "D" };
                var values = Enumerable.Range(-1, 5).ToArray();

                for (int i = 0; i < names.Length; i++)
                {
                    nameAndValues.Add(new NameAndValue(names[i], values[i]));
                }

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
            foreach (var comboBox in comboBoxes)
            {
                var nameAndValues = new BindingList<NameAndValue>();

                var names = new[] { "", "Owing", "Not Owning" };
                var values = Enumerable.Range(-1, 3).ToArray();

                for (int i = 0; i < names.Length; i++)
                {
                    nameAndValues.Add(new NameAndValue(names[i], values[i]));
                }


                comboBox.DataSource = nameAndValues;
                comboBox.DisplayMember = "Name";
                comboBox.ValueMember = "Value";
            }

        }

        /// <summary>
        /// Initialize the session combo boxes
        /// </summary>
        /// <param name="comboBoxes">A list of combo boxes</param>
        public static void InitializeSessionCombo(IEnumerable<ComboBox> comboBoxes)
        {
            foreach (var comboBox in comboBoxes)
            {
                var nameAndValues = new BindingList<NameAndValueString>();
                var names = new[] {"", $"{DateTime.Now.AddYears(-1).Year}/{DateTime.Now.Year}", $"{DateTime.Now.Year}/{DateTime.Now.AddYears(1).Year}" };
                var values = new[] { "", $"{DateTime.Now.AddYears(-1).Year}/{DateTime.Now.Year}", $"{DateTime.Now.Year}/{DateTime.Now.AddYears(1).Year}" };

                for (int i = 0; i < names.Length; i++)
                {
                    nameAndValues.Add(new NameAndValueString(names[i], values[i]));
                }

                comboBox.DataSource = nameAndValues;
                comboBox.DisplayMember = "Name";
                comboBox.ValueMember = "Value";
            }
        }

        public static string GetPermanentLogoPath(string logoPath)
        {
            if (!File.Exists(logoPath)) return null;

            var fileName = Path.GetFileName(logoPath);
            var destinationPath = GetFolderPath(SpecialFolder.LocalApplicationData);
            var destinationFile = Path.Combine(destinationPath, fileName);

            File.Copy(logoPath, destinationFile, true);
            return destinationFile;
        }

        public static void SendToPrinter(string path)
        {
            ProcessStartInfo info = new ProcessStartInfo
            {
                Verb = "print",
                FileName = path,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            Process p = new Process { StartInfo = info };
            p.Start();

            p.WaitForInputIdle();
            Thread.Sleep(10000);
            if (false == p.CloseMainWindow())
                p.Kill();
        }

        public static string GetFilePath(Student student, ClassTermFee classTermFee)
        {
            //check if school folder exist, create if false. Document\SchoolReceipt.
            var parentDirectory = GetFolderPath(SpecialFolder.ApplicationData);
            var schoolDirectory = Path.Combine(parentDirectory, "SchoolAccountant");

            if (!Directory.Exists(schoolDirectory))
            {
                Directory.CreateDirectory(schoolDirectory);
            }

            //Check if student folder exist, create if false. Format -> FirstName.LastName.MiddleName
            var studentFolder = $"{student.FirstName}.{student.LastName}.{student.MiddleName}";
            var studentDirectory = Path.Combine(schoolDirectory, studentFolder);

            if (!Directory.Exists(studentDirectory))
            {
                Directory.CreateDirectory(studentDirectory);
            }

            //Set file name in format -> fullname.Session.term
            var currentTerm =
                $"{studentFolder}.{classTermFee.Session.Replace(@"/", "-")}.{Enum.GetName(typeof(TermEnum), classTermFee.TermEnum)}.pdf";

            //append all path to string and return
            var currentTermFileName = Path.Combine(studentDirectory, currentTerm);

            return currentTermFileName;

        }

        public static byte[] GetPasswordHash(string passwword)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(passwword);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            return data;
        }
    }
}
