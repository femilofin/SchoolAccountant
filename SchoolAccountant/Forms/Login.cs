using System;
using System.Windows.Forms;
using BusinessLogic.Entities;
using BusinessLogic.Interface;
using BusinessLogic.Repositories;
using MongoRepository;

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
            var username = tboUsername.Text;
            var password = tboPassword.Text;

            var success = _userRepository.Login(username, password);

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
                MessageBox.Show(@"Something went wrong, please try again");
            }
        }

      
    }
}
