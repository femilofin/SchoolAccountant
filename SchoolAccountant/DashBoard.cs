using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic.Entities;
using BusinessLogic.Interface;
using BusinessLogic.Repositories;

namespace SchoolAccountant
{
    public partial class DashBoard : Form
    {
        private readonly IUserRepository _userRepository = new UserRepository();
        private readonly IStudentRepository _studentRepository = new StudentRepository();

        public DashBoard()
        {
            InitializeComponent();
            InitializeDateCombo();
            Utilities.InitialiizeClassCombo(new[] { cboStartClassAS });
            Utilities.InitialiizeTermCombo(new[] { cboStartTermAS });
        }

        private void InitializeDateCombo()
        {
            var year = DateTime.UtcNow.Year - 1980;
            cboDayAS.Items.AddRange(Enumerable.Range(1, 31).Cast<object>().ToArray());
            cboMonthAS.Items.AddRange(Enumerable.Range(1, 12).Cast<object>().ToArray());
            cboYearAS.Items.AddRange(Enumerable.Range(1980, year).Reverse().Cast<object>().ToArray());
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            // AU - Add User

            var username = tboUsernameAU.Text;
            var passwword = tboPasswordAU.Text;
            var fullName = tboFullNameAU.Text;

            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(passwword) &&
                !string.IsNullOrWhiteSpace(fullName))
            {
                var user = new User
                {
                    FullName = fullName,
                    PasswordHash = passwword,
                    Username = username,
                    TimeStamp = DateTime.UtcNow
                };

                var success = _userRepository.Register(user);

                if (success)
                {
                    MessageBox.Show(string.Format("User \"{0}\" has been registered", username));
                    ClearTextBoxesAU();
                }
                else
                {
                    MessageBox.Show(@"Something went wrong, please try again");
                }
            }

            else
            {
                MessageBox.Show(@"Please, all information are required");
            }

        }

      private void btnAddStudent_Click(object sender, EventArgs e)
        {
            // AS - Add Student

            var lastName = tboLastNameAS.Text;
            var firstName = tboFirstNameAS.Text;
            var middleName = tboMiddleNameAS.Text;
            var birthDay = cboDayAS.Text;
            var birthMonth = cboMonthAS.Text;
            var birthYear = cboYearAS.Text;
            var startDate = dtpStartDateAS.Text;
            var startClass = cboStartClassAS.SelectedValue;
            var startTerm = cboStartTermAS.SelectedValue;

            if (!string.IsNullOrWhiteSpace(lastName) && !string.IsNullOrWhiteSpace(firstName) &&
                !string.IsNullOrWhiteSpace(middleName) && !string.IsNullOrWhiteSpace(birthDay) &&
                !string.IsNullOrWhiteSpace(birthMonth) && !string.IsNullOrWhiteSpace(birthYear))
            {

                var student = new Student()
                {
                    LastName = lastName,
                    FirstName = firstName,
                    MiddleName = middleName,
                    Active = true,
                    BirthDate = new DateTime(int.Parse(birthYear), int.Parse(birthMonth), int.Parse(birthDay)),
                    StartClass = (int) startClass,
                    StartTerm = (int) startTerm,
                    StartDate = DateTime.Parse(startDate)
                };

                var success = _studentRepository.AddStudent(student);

                if (success)
                {
                    MessageBox.Show(string.Format("Student \"{0} {1}\" has been registered", firstName, lastName));
                    ClearTextBoxesAS();
                }
                else
                {
                    MessageBox.Show(@"Something went wrong, please try again");
                }
            }

            else
            {
                MessageBox.Show(@"Please, all information are required");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnClearTextBoxes_Click(object sender, EventArgs e)
        {
            ClearTextBoxesAS();
        }

        private void ClearTextBoxesAU()
        {
            tboUsernameAU.Clear();
            tboFullNameAU.Clear();
            tboPasswordAU.Clear();
        }

        private void ClearTextBoxesAS()
        {
            tboLastNameAS.Clear();
            tboMiddleNameAS.Clear();
            tboFirstNameAS.Clear();
            cboDayAS.SelectedIndex = -1;
            cboMonthAS.SelectedIndex = -1;
            cboYearAS.SelectedIndex = -1;
            cboStartTermAS.SelectedIndex = 0;
            cboStartClassAS.SelectedIndex = 0;
            dtpStartDateAS.Value = DateTime.Now;
        }
    }

    public class NameAndValue
    {
        public NameAndValue(string name, int value)
        {
            Name = name;
            Value = value;
        }
        public int Value { get; set; }
        public string Name { get; set; }
    }
}
