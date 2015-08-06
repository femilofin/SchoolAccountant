using System;
using System.Windows.Forms;
using BusinessLogic.Interface;
using BusinessLogic.Repositories;

namespace SchoolAccountant.Forms
{
    public partial class Login : Form
    {
        private readonly IUserRepository _userRepository = new UserRepository();

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = tboUsername.Text;
            var password = tboPassword.Text;

            var success = _userRepository.Login(username, password);
            
            if (success)
            {
                Hide();

                new DashBoard(username).Show();
            }
            else
            {
                MessageBox.Show(@"Something went wrong, please try again");
            }
        }

      
    }
}
