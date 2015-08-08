using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic.Constants;
using BusinessLogic.Entities;
using BusinessLogic.Interface;
using BusinessLogic.Repositories;
using SchoolAccountant.Helpers;

namespace SchoolAccountant.Forms
{
    public partial class SchoolSetup : Form
    {
        private readonly ISchoolRepository _schoolRepository = new SchoolRepository();
        private readonly string _username;

        public SchoolSetup(string username)
        {
            InitializeComponent();

            _username = username;

            Utilities.InitializeSessionCombo(new[] { cboPresentSession });
            Utilities.InitialiizeTermCombo(new[] { cboPresentTerm });
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var schoolName = tboSchoolName.Text;
            var presentSession = cboPresentSession.SelectedValue;
            var presentTerm = cboPresentTerm.SelectedValue;
            var sessionDateStarted = dtpSessionDateStarted.Text;
            var termDatedStarted = dtpTermDateStarted.Text;

            if (presentSession == "" || presentTerm == "" || string.IsNullOrWhiteSpace(schoolName)) return;

            var school = new School()
            {
                Name = schoolName,
                PresentSession = presentSession.ToString(),
                PresentTermEnum = (TermEnum) presentTerm,
                SessionStart = Convert.ToDateTime(sessionDateStarted),
                TermStart = Convert.ToDateTime(termDatedStarted)
            };

            _schoolRepository.SchoolSetup(school);

            Hide();
            new DashBoard(_username).ShowDialog();
        }
    }
}
