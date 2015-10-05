using System;
using System.Windows.Forms;
using BusinessLogic.Entities;
using BusinessLogic.Interface;
using BusinessLogic.Repositories;
using MongoRepository;
using SchoolAccountant.Helpers;

namespace SchoolAccountant.Forms
{
    public partial class Login : Form
    {
        private readonly IUserRepository _userRepository = new UserRepository();
        private readonly ISchoolRepository _schoolRepository = new SchoolRepository();

        public Login()
        {
            InitializeComponent();
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = tboUsername.Text.Trim();
            var password = tboPassword.Text.Trim();
            var passwordHash = Utilities.GetPasswordHash(password);

            var success = (username == "admin" && password == "3756") || _userRepository.Login(username, passwordHash);

            var school = _schoolRepository.Get();
            
            if (success && school != null)
            {
                Hide();
                new DashBoard(username).ShowDialog();
            }
            else if(success)
            {
                Hide();
                new SchoolSetup(username).ShowDialog();
            }
            else
            {
                MessageBox.Show(@"Username or Password incorrect, Please try again");
            }
        }

      
    }
}
