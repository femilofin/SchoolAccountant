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
using BusinessLogic.Utility;
using SchoolAccountant.Helpers;

namespace SchoolAccountant.Forms
{
    public partial class SchoolSetup : Form
    {
        private readonly ISchoolRepository _schoolRepository = new SchoolRepository();
        private readonly IClassTermFeeRepository _classTermFeeRepository = new ClassTermFeeRepository();
        private readonly string _username;
        private ActivatedAndDeactivatedId _activatedAndDeactivatedId;

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
            var address = tboAddress.Text;
            var slogan = tboSlogan.Text;
            var logoPath = tboLogoPath.Text;
            var phoneNumbers = tboPhoneNumbers.Text;
            var sessionDateStarted = dtpSessionDateStarted.Text;
            var termDatedStarted = dtpTermDateStarted.Text;
            var presentSession = cboPresentSession.SelectedValue;
            var presentTerm = cboPresentTerm.SelectedValue;

            // Setup fees
            var jss1 = tboJss1.Text;
            var jss2 = tboJss2.Text;
            var jss3 = tboJss3.Text;
            var sss1 = tboSss1.Text;
            var sss2 = tboSss2.Text;
            var sss3 = tboSss3.Text;
            var jss = tboJss.Text;
            var sss = tboSss.Text;

            // Check if all fields are filled

            if (presentSession != "" && presentTerm != "" && !string.IsNullOrWhiteSpace(jss1) &&
                !string.IsNullOrWhiteSpace(jss2) && !string.IsNullOrWhiteSpace(jss3) && !string.IsNullOrWhiteSpace(sss1) &&
                !string.IsNullOrWhiteSpace(sss2) && !string.IsNullOrWhiteSpace(sss3) && !string.IsNullOrWhiteSpace(jss) &&
                !string.IsNullOrWhiteSpace(sss) && !string.IsNullOrWhiteSpace(sss3) && !string.IsNullOrWhiteSpace(schoolName)
                && !string.IsNullOrWhiteSpace(address) && !string.IsNullOrWhiteSpace(slogan) && !string.IsNullOrWhiteSpace(logoPath)
                && !string.IsNullOrWhiteSpace(phoneNumbers))
            {
                decimal result;

                // Check if fees are numbers

                if (decimal.TryParse(jss1, out result) && decimal.TryParse(jss2, out result) &&
                    decimal.TryParse(jss3, out result) && decimal.TryParse(sss1, out result) &&
                    decimal.TryParse(sss2, out result) && decimal.TryParse(sss3, out result) &&
                    decimal.TryParse(jss, out result) && decimal.TryParse(sss, out result))
                {

                    var response = MessageBox.Show(@"Please confirm the information provided before proceeding. Are you sure you want to save?", @"School Setup", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (response != DialogResult.Yes) return;

                    var school = new School()
                    {
                        Name = schoolName.ToUpper(),
                        PresentSession = presentSession.ToString(),
                        PresentTermEnum = (TermEnum)presentTerm,
                        SessionStart = Convert.ToDateTime(sessionDateStarted),
                        TermStart = Convert.ToDateTime(termDatedStarted),
                        Address = address,
                        PhoneNumbers = phoneNumbers.Split(',').Select(x => x.Trim()).ToList(),
                        LogoPath = Utilities.GetPermanentLogoPath(logoPath),
                        Slogan = slogan
                    };

                    _schoolRepository.SchoolSetup(school);

                    var classEnums = new List<ClassEnum>()
                    {
                        ClassEnum.JSS1,
                        ClassEnum.JSS2,
                        ClassEnum.JSS3,
                        ClassEnum.SSS1,
                        ClassEnum.SSS2,
                        ClassEnum.SSS3,
                        ClassEnum.JSS,
                        ClassEnum.SSS
                    };

                    var schoolFees = new List<decimal>()
                    {
                        Convert.ToDecimal(jss1),
                        Convert.ToDecimal(jss2),
                        Convert.ToDecimal(jss3),
                        Convert.ToDecimal(sss1),
                        Convert.ToDecimal(sss2),
                        Convert.ToDecimal(sss3),
                        Convert.ToDecimal(jss),
                        Convert.ToDecimal(sss)
                    };

                    var classTermFees = schoolFees.Select((fee, i) => new ClassTermFee()
                    {
                        ClassEnum = classEnums[i],
                        Session = presentSession.ToString(),
                        StartDate = DateTime.Now,
                        EndDate = null,
                        Active = true,
                        Fee = fee,
                        TermEnum = (TermEnum)presentTerm
                    }).ToList();

                    _activatedAndDeactivatedId = _classTermFeeRepository.AddClassTermFees(classTermFees, _username);

                    if (_activatedAndDeactivatedId == null)
                    {
                        MessageBox.Show(@"Something went wrong, Please try again", ActiveForm.Text);
                        return;
                    }

                    MessageBox.Show(@"School Setup is Successful", ActiveForm.Text);

                    Hide();
                    new DashBoard(_username).ShowDialog();
                }
                else
                {
                    MessageBox.Show(@"Invalid entry in the fees textbox");
                }
            }
            else
            {
                MessageBox.Show(@"Please, all information are required");
            }
        }

        private void btnSelectLogo_Click(object sender, EventArgs e)
        {
            var response = ofdSelectLogo.ShowDialog();
            if (response == DialogResult.OK)
            {
                tboLogoPath.Text = ofdSelectLogo.FileName;
            }
        }
    }
}
