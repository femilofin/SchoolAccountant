using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic.Interface;
using BusinessLogic.Repositories;

namespace SchoolAccountant
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
                new DashBoard().Show();
            }
            else
            {
                MessageBox.Show(@"Something went wrong, please try again");
            }
        }

      
    }
}
