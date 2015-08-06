#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BusinessLogic.Constants;
using BusinessLogic.Entities;
using BusinessLogic.Interface;
using BusinessLogic.Repositories;
using BusinessLogic.Utility;
using SchoolAccountant.Helpers;

#endregion
namespace SchoolAccountant.Forms
{
    public partial class DashBoard : Form
    {
        private readonly IStudentRepository _studentRepository = new StudentRepository();
        private readonly IUserRepository _userRepository = new UserRepository();
        private readonly IClassTermFeeRepository _classTermFeeRepository = new ClassTermFeeRepository();


        readonly DataGridViewButtonColumn _btnViewInfo = new DataGridViewButtonColumn();
        readonly DataGridViewButtonColumn _btnViewPaymentHistory = new DataGridViewButtonColumn();
        readonly DataGridViewButtonColumn _btnPayFee = new DataGridViewButtonColumn();
        readonly DataGridViewButtonColumn _btnDeactivateStudent = new DataGridViewButtonColumn();
        private ActivatedAndDeactivatedId _activatedAndDeactivatedId;

        private readonly string _username;



        public DashBoard(string username)
        {
            InitializeComponent();
            Utilities.InitialiizeClassCombo(new[] { cboStartClassAS, cboPresentClassAS, cboClassMS });
            Utilities.InitialiizeTermCombo(new[] { cboStartTermAS, cboPresentTermAS, cboTermANT });
            Utilities.InitialiizeArmCombo(new[] { cboArmMS, cboPresentArmAS });
            Utilities.InitialiizeFeeStatusCombo(new[] { cboFeeStatusMS });
            Utilities.InitializeSessionCombo(new[] { cboSessionANT });

            // Disable the undo save button
            btnUndoLastAddFeesANT.Enabled = false;

            _username = username;

            SetCurrentFeesInAddNewTermTab();

        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            RefreshDgv();
        }

        private void ClearAllComboBoxesInMS()
        {
            // MS - Manage Student

            cboClassMS.SelectedValue = -1;
            cboArmMS.SelectedValue = -1;
            cboFeeStatusMS.SelectedValue = -1;
            tboSearchMS.Clear();
        }

        /// <summary>
        /// Set datasource for the datagrid view
        /// </summary>
        /// <param name="filter">The input in the search textbox</param>
        /// <param name="classEnum">The selected index of the class combo box</param>
        /// <param name="armEnum">The selected index of the arm combo box</param>
        /// <param name="feeStatus">The selected index of the fee status combo box</param>
        object GetDataSource(string filter = "", int classEnum = -1, int armEnum = -1, int feeStatus = -1)
        {
            object dataSource;

            var activeStudents = _studentRepository.GetActiveStudents();

            // If default i.e no search and no combo box was selected

            if (filter == "" && classEnum == -1 && armEnum == -1 && feeStatus == -1)
            {
                dataSource = GetStudentView(activeStudents);

                // Update Status Label
                tsslTableStatus.Text = $"{activeStudents.Count} records found";

                return dataSource;
            }

            // else if only class combo box was selected
            if (classEnum != -1 && filter == "" && armEnum == -1 && feeStatus == -1)
            {
                var filteredStudents =
                    activeStudents.Where(x => x.PresentClass == (ClassEnum)classEnum).ToList();

                dataSource = GetStudentView(filteredStudents);

                // Update Status Label
                UpdateStatusLabel(filteredStudents, activeStudents);

                return dataSource;
            }

            // else if only class combo box and search
            if (classEnum != -1 && filter != "" && armEnum == -1 && feeStatus == -1)
            {
                var filteredStudents =
                    activeStudents.Where(x => x.PresentClass == (ClassEnum)classEnum)
                        .Where(
                            x =>
                                Regex.IsMatch(x.LastName.ToLower(), filter) ||
                                Regex.IsMatch(x.FirstName.ToLower(), filter) ||
                                Regex.IsMatch(x.MiddleName.ToLower(), filter))
                        .ToList();

                dataSource = GetStudentView(filteredStudents);


                // Update Status Label
                UpdateStatusLabel(filteredStudents, activeStudents);

                return dataSource;
            }

            // else if class and arm combo boxes were selected

            if (classEnum != -1 && filter == "" && armEnum != -1 && feeStatus == -1)
            {
                var filteredStudents =
                    activeStudents.Where(x => x.PresentClass == (ClassEnum)classEnum)
                        .Where(x => x.PresentArm == (ArmEnum)armEnum)
                        .ToList();
                dataSource = GetStudentView(filteredStudents);


                // Update Status Label
                UpdateStatusLabel(filteredStudents, activeStudents);
                return dataSource;
            }

            // else if class , arm combo boxes and search 

            if (classEnum != -1 && filter != "" && armEnum != -1 && feeStatus == -1)
            {
                var filteredStudents =
                    activeStudents.Where(x => x.PresentClass == (ClassEnum)classEnum)
                        .Where(x => x.PresentArm == (ArmEnum)armEnum)
                        .Where(
                            x =>
                                Regex.IsMatch(x.LastName.ToLower(), filter) ||
                                Regex.IsMatch(x.FirstName.ToLower(), filter) ||
                                Regex.IsMatch(x.MiddleName.ToLower(), filter))
                        .ToList();
                dataSource = GetStudentView(filteredStudents);


                // Update Status Label
                UpdateStatusLabel(filteredStudents, activeStudents);

                return dataSource;
            }

            // else if class and fee status were selected

            if (classEnum != -1 && filter == "" && armEnum == -1 && feeStatus != -1)
            {
                if (feeStatus == 0)
                {
                    var filteredStudents =
                        activeStudents.Where(x => x.PresentClass == (ClassEnum)classEnum)
                            .Where(x => x.OutstandingFee > 0)
                            .ToList();
                    dataSource = GetStudentView(filteredStudents);


                    // Update Status Label
                    UpdateStatusLabel(filteredStudents, activeStudents);

                    return dataSource;
                }
                else
                {
                    var filteredStudents =
                        activeStudents.Where(x => x.PresentClass == (ClassEnum)classEnum)
                            .Where(x => x.OutstandingFee == 0)
                            .ToList();
                    dataSource = GetStudentView(filteredStudents);


                    // Update Status Label
                    UpdateStatusLabel(filteredStudents, activeStudents);

                    return dataSource;
                }


            }

            // else if class and fee status and search

            if (classEnum != -1 && filter != "" && armEnum == -1 && feeStatus != -1)
            {
                if (feeStatus == 0)
                {
                    var filteredStudents =
                        activeStudents.Where(x => x.PresentClass == (ClassEnum)classEnum)
                            .Where(x => x.OutstandingFee > 0)
                            .Where(
                                x =>
                                    Regex.IsMatch(x.LastName.ToLower(), filter) ||
                                    Regex.IsMatch(x.FirstName.ToLower(), filter) ||
                                    Regex.IsMatch(x.MiddleName.ToLower(), filter))
                            .ToList();
                    dataSource = GetStudentView(filteredStudents);


                    // Update Status Label
                    UpdateStatusLabel(filteredStudents, activeStudents);

                    return dataSource;
                }
                else
                {
                    var filteredStudents =
                        activeStudents.Where(x => x.PresentClass == (ClassEnum)classEnum)
                            .Where(x => x.OutstandingFee == 0)
                            .Where(
                                x =>
                                    Regex.IsMatch(x.LastName.ToLower(), filter) ||
                                    Regex.IsMatch(x.FirstName.ToLower(), filter) ||
                                    Regex.IsMatch(x.MiddleName.ToLower(), filter))
                            .ToList();
                    dataSource = GetStudentView(filteredStudents);


                    // Update Status Label
                    UpdateStatusLabel(filteredStudents, activeStudents);

                    return dataSource;
                }
            }

            // else if class, arm and fee status was selected
            if (classEnum != -1 && filter == "" && armEnum != -1 && feeStatus != -1)
            {
                if (feeStatus == 0)
                {
                    var filteredStudents =
                        activeStudents.Where(x => x.PresentClass == (ClassEnum)classEnum)
                            .Where(x => x.PresentArm == (ArmEnum)armEnum)
                            .Where(x => x.OutstandingFee > 0)
                            .ToList();
                    dataSource = GetStudentView(filteredStudents);


                    // Update Status Label
                    UpdateStatusLabel(filteredStudents, activeStudents);

                    return dataSource;
                }
                else
                {
                    var filteredStudents =
                        activeStudents.Where(x => x.PresentClass == (ClassEnum)classEnum)
                            .Where(x => x.PresentArm == (ArmEnum)armEnum)
                            .Where(x => x.OutstandingFee == 0)
                            .ToList();
                    dataSource = GetStudentView(filteredStudents);


                    // Update Status Label
                    UpdateStatusLabel(filteredStudents, activeStudents);

                    return dataSource;
                }
            }

            // else if class, arm and fee status and search
            if (classEnum != -1 && filter != "" && armEnum != -1 && feeStatus != -1)
            {
                if (feeStatus == 0)
                {
                    var filteredStudents =
                        activeStudents.Where(x => x.PresentClass == (ClassEnum)classEnum)
                            .Where(x => x.PresentArm == (ArmEnum)armEnum)
                            .Where(x => x.OutstandingFee > 0)
                            .Where(
                                x =>
                                    Regex.IsMatch(x.LastName.ToLower(), filter) ||
                                    Regex.IsMatch(x.FirstName.ToLower(), filter) ||
                                    Regex.IsMatch(x.MiddleName.ToLower(), filter))
                            .ToList();
                    dataSource = GetStudentView(filteredStudents);


                    // Update Status Label
                    UpdateStatusLabel(filteredStudents, activeStudents);

                    return dataSource;
                }
                else
                {
                    var filteredStudents =
                        activeStudents.Where(x => x.PresentClass == (ClassEnum)classEnum)
                            .Where(x => x.PresentArm == (ArmEnum)armEnum)
                            .Where(x => x.OutstandingFee == 0)
                            .Where(
                                x =>
                                    Regex.IsMatch(x.LastName.ToLower(), filter) ||
                                    Regex.IsMatch(x.FirstName.ToLower(), filter) ||
                                    Regex.IsMatch(x.MiddleName.ToLower(), filter))
                            .ToList();
                    dataSource = GetStudentView(filteredStudents);


                    // Update Status Label
                    UpdateStatusLabel(filteredStudents, activeStudents);

                    return dataSource;
                }
            }
            // else if only fee status was selected
            if (classEnum == -1 && filter == "" && armEnum == -1 && feeStatus != -1)
            {
                if (feeStatus == 0)
                {
                    var filteredStudents =
                        activeStudents.Where(x => x.OutstandingFee > 0).ToList();
                    dataSource = GetStudentView(filteredStudents);


                    // Update Status Label
                    UpdateStatusLabel(filteredStudents, activeStudents);

                    return dataSource;

                }
                else
                {
                    var filteredStudents =
                        activeStudents.Where(x => x.OutstandingFee == 0).ToList();
                    dataSource = GetStudentView(filteredStudents);


                    // Update Status Label
                    UpdateStatusLabel(filteredStudents, activeStudents);

                    return dataSource;

                }
            }
            // else if only fee status and search
            if (classEnum == -1 && filter != "" && armEnum == -1 && feeStatus != -1)
            {
                if (feeStatus == 0)
                {
                    var filteredStudents =
                        activeStudents.Where(x => x.OutstandingFee > 0)
                            .Where(
                                x =>
                                    Regex.IsMatch(x.LastName.ToLower(), filter) ||
                                    Regex.IsMatch(x.FirstName.ToLower(), filter) ||
                                    Regex.IsMatch(x.MiddleName.ToLower(), filter))
                            .ToList();
                    dataSource = GetStudentView(filteredStudents);


                    // Update Status Label
                    UpdateStatusLabel(filteredStudents, activeStudents);

                    return dataSource;

                }
                else
                {
                    var filteredStudents =
                        activeStudents.Where(x => x.OutstandingFee == 0)
                            .Where(
                                x =>
                                    Regex.IsMatch(x.LastName.ToLower(), filter) ||
                                    Regex.IsMatch(x.FirstName.ToLower(), filter) ||
                                    Regex.IsMatch(x.MiddleName.ToLower(), filter))
                            .ToList();
                    dataSource = GetStudentView(filteredStudents);


                    // Update Status Label
                    UpdateStatusLabel(filteredStudents, activeStudents);

                    return dataSource;

                }
            }
            // else if only search 

            if (filter != "" && classEnum == -1 && armEnum == -1 && feeStatus == -1)
            {
                var filteredActiveStudentsBySearch =
                    activeStudents.Where(
                        x =>
                            Regex.IsMatch(x.LastName.ToLower(), filter) ||
                            Regex.IsMatch(x.FirstName.ToLower(), filter) ||
                            Regex.IsMatch(x.MiddleName.ToLower(), filter)).ToList();
                dataSource = GetStudentView(filteredActiveStudentsBySearch);


                // Update Status Label
                UpdateStatusLabel(filteredActiveStudentsBySearch, activeStudents);

                return dataSource;

            }

            dataSource = GetStudentView(activeStudents);

            // Update Status Label
            tsslTableStatus.Text = $"{activeStudents.Count} records found";

            return dataSource;
        }

        private static List<StudentView> GetStudentView(IList<Student> activeStudents)
        {
            var studentViews = new List<StudentView>();
            var indexes = Enumerable.Range(1, activeStudents.Count).ToList();

            for (var i = 0; i < activeStudents.Count(); i++)
            {
                studentViews.Add(new StudentView()
                {
                    Index = indexes[i],
                    FullName =
                        $"{activeStudents[i].LastName.ToUpper()} {activeStudents[i].FirstName} {activeStudents[i].MiddleName}",
                    PresentClass =
                        $"{activeStudents[i].PresentClass} {activeStudents[i].PresentArm}",
                    OutstandingFee =
                        activeStudents[i].OutstandingFee > 0
                            ? $"NGN {activeStudents[i].OutstandingFee}"
                            : "Cleared",
                    PaidFee = $"NGN {activeStudents[i].PaidFee}",
                    FirstName = activeStudents[i].FirstName,
                    LastName = activeStudents[i].LastName,
                    BirthDate = activeStudents[i].BirthDate,
                    MiddleName = activeStudents[i].MiddleName,
                    Active = activeStudents[i].Active,
                    PresentArm = activeStudents[i].PresentArm,
                    PresentTerm = activeStudents[i].PresentTerm,
                    StartClass = activeStudents[i].StartClass,
                    StartDate = activeStudents[i].StartDate,
                    StartTerm = activeStudents[i].StartTerm,
                    Id = activeStudents[i].Id

                }
                    );

            }

            return studentViews;
        }

        private void UpdateStatusLabel(IReadOnlyCollection<Student> filteredActiveStudentsByClass, ICollection<Student> activeStudents)
        {
            tsslTableStatus.Text =
                $"{filteredActiveStudentsByClass.Count} record(s) found out of {activeStudents.Count} records available.";
        }

        /// <summary>
        /// Fills the datagrid view
        /// </summary>
        /// <param name="dataSource">Data source for the datagridview</param>
        private void FillDgv(object dataSource)
        {

            var dgvHelper = new DgvHelper(dgvViewStudent, dataSource);
            dgvHelper.Properties(borderStyle: BorderStyle.Fixed3D, font: "Arial", fontSize: 8)
                .Header(fontSize: 8, font: "Arial")
                .Add(0, "Index", "", width: 20, readOnly: true)
                .Add(1, "FullName", "FullName", foreColor: Color.Red, width: 234, readOnly: true)
                .Add(2, "PresentClass", "Class", width: 50, readOnly: true)
                .Add(3, "OutstandingFee", "Debt", foreColor: Color.Red, width: 80, readOnly: true)
                .Add(8, "PaidFee", "PaidFee", visible: false)
                .Add(9, "LastName", "LastName", visible: false)
                .Add(10, "BirthDate", "BirthDate", visible: false)
                .Add(11, "MiddleName", "MiddleName", visible: false)
                .Add(12, "Active", "Active", visible: false)
                .Add(13, "PresentArm", "PresentArm", visible: false)
                .Add(14, "PresentTerm", "PresentTerm", visible: false)
                .Add(15, "StartClass", "StartClass", visible: false)
                .Add(15, "StartDate", "StartDate", visible: false)
                .Add(15, "StartTerm", "StartTerm", visible: false)
                .Add(15, "Id", "Id", visible: false)
                .Add(15, "FirstName", "FirstName", visible: false);


            // Add "Pay Fee" button
            _btnPayFee.Text = "Pay Fee";
            _btnPayFee.UseColumnTextForButtonValue = true;
            _btnPayFee.Width = 53;
            dgvViewStudent.Columns.Insert((int)ButtonColumnIndex.PayFee, _btnPayFee);

            // Add "View Student Info" button
            _btnViewInfo.Text = "View Info";
            _btnViewInfo.UseColumnTextForButtonValue = true;
            _btnViewInfo.Width = 63;
            dgvViewStudent.Columns.Insert((int)ButtonColumnIndex.ViewInfo, _btnViewInfo);

            // Add "View Payment History" button
            _btnViewPaymentHistory.Text = "Fee History";
            _btnViewPaymentHistory.UseColumnTextForButtonValue = true;
            _btnViewPaymentHistory.Width = 66;
            dgvViewStudent.Columns.Insert((int)ButtonColumnIndex.FeeHistory, _btnViewPaymentHistory);

            // Add "Deactivate Student" button
            _btnDeactivateStudent.Text = "Deactivate";
            _btnDeactivateStudent.UseColumnTextForButtonValue = true;
            _btnDeactivateStudent.Width = 66;
            dgvViewStudent.Columns.Insert((int)ButtonColumnIndex.Deactivate, _btnDeactivateStudent);
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

                var success = _userRepository.Create(user);

                if (success)
                {
                    MessageBox.Show($"User \"{username}\" has been registered");
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
            var startDate = dtpStartDateAS.Text;
            var birthDate = dtpBirthDateAS.Text;
            var outstandingFee = tboOutstandingFeeAS.Text;
            var startClass = cboStartClassAS.SelectedValue;
            var startTerm = cboStartTermAS.SelectedValue;
            var presentClass = cboPresentClassAS.SelectedValue;
            var presentTerm = cboPresentTermAS.SelectedValue;
            var presentArm = cboPresentArmAS.SelectedValue;

            if (!string.IsNullOrWhiteSpace(lastName) && !string.IsNullOrWhiteSpace(firstName) &&
                !string.IsNullOrWhiteSpace(middleName) && (int)startClass != -1
                && (int)startTerm != -1 && (int)presentClass != -1 && (int)presentTerm != -1
                && (int)presentArm != -1)
            {
                var student = new Student
                {
                    LastName = lastName,
                    FirstName = firstName,
                    MiddleName = middleName,
                    Active = true,
                    BirthDate = DateTime.Parse(birthDate),
                    StartClass = (ClassEnum)startClass,
                    StartTerm = (TermEnum)startTerm,
                    StartDate = DateTime.Parse(startDate),
                    OutstandingFee = Convert.ToDecimal(outstandingFee == "" ? "0" : outstandingFee),
                    PresentClass = (ClassEnum)presentClass,
                    PresentTerm = (TermEnum)presentTerm,
                    PresentArm = (ArmEnum)presentArm
                };

                var success = _studentRepository.Create(student);

                if (success)
                {
                    MessageBox.Show($"Student \"{firstName} {lastName}\" has been registered");
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

        private void btnClearTextBoxes_Click(object sender, EventArgs e)
        {
            ClearTextBoxesAS();
        }

        /// <summary>
        /// Clear or reset textboxes in the "Add User" tab
        /// </summary>
        private void ClearTextBoxesAU()
        {
            tboUsernameAU.Clear();
            tboFullNameAU.Clear();
            tboPasswordAU.Clear();
        }

        /// <summary>
        /// Clear or reset textboxes, comboboxes and date picker in the "Add Student" tab
        /// </summary>
        private void ClearTextBoxesAS()
        {
            tboLastNameAS.Clear();
            tboMiddleNameAS.Clear();
            tboFirstNameAS.Clear();
            tboOutstandingFeeAS.Clear();
            cboStartTermAS.SelectedIndex = -1;
            cboStartClassAS.SelectedIndex = -1;
            cboPresentArmAS.SelectedIndex = -1;
            dtpStartDateAS.Value = DateTime.Now;
            dtpBirthDateAS.Value = DateTime.Now;
        }

        private void tboSearchMS_TextChanged(object sender, EventArgs e)
        {
            RefreshDgv();
        }

        private void cboClassMS_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDgv();
        }

        private void cboArmMS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)cboClassMS.SelectedValue == -1)
            {
                ClearAllComboBoxesInMS();
            }

            RefreshDgv();
        }

        private void cboFeeStatusMS_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDgv();
        }

        /// <summary>
        /// It is used to reload the dgv
        /// </summary>
        private void RefreshDgv()
        {
            var filter = tboSearchMS.Text.ToLower();
            var selectedClass = cboClassMS.SelectedValue;
            var selectedArm = cboArmMS.SelectedValue;
            var selectedFeeStatus = cboFeeStatusMS.SelectedValue;
            dgvViewStudent.Columns.Clear();

            var dataSource = GetDataSource(filter, (int)selectedClass, (int)selectedArm, (int)selectedFeeStatus);
            FillDgv(dataSource);

        }

        private void tsslShowAll_Click(object sender, EventArgs e)
        {
            ClearAllComboBoxesInMS();
            RefreshDgv();
        }

        private void dgvViewStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // if pay fee
            switch (e.ColumnIndex)
            {
                case (int)ButtonColumnIndex.PayFee:
                    {
                        var row = dgvViewStudent.Rows[e.RowIndex];
                        new PayFee(row).ShowDialog();
                    }
                    break;
                case (int)ButtonColumnIndex.ViewInfo:
                    {
                        var row = dgvViewStudent.Rows[e.RowIndex];
                        new ViewInfo(row).ShowDialog();
                    }
                    break;
                case (int)ButtonColumnIndex.FeeHistory:
                    {
                        var row = dgvViewStudent.Rows[e.RowIndex];
                        new FeeHistory(row).ShowDialog();
                    }
                    break;
                case (int)ButtonColumnIndex.Deactivate:
                    {
                        var row = dgvViewStudent.Rows[e.RowIndex];

                        var response = MessageBox.Show($"Are you sure you want to deactivate {row.Cells["FullName"].Value} ?", ActiveForm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);

                        if (response == DialogResult.Yes)
                        {
                            var success = _studentRepository.DeactivateStudent(row.Cells["Id"].Value.ToString());

                            if (success)
                            {
                                MessageBox.Show(@"Student Deactivated");
                            }
                        }

                    }
                    break;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearAllComboBoxesInMS();
            RefreshDgv();
        }

        private void llPromoteStudents_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new PromoteStudents().ShowDialog();
        }

        private void btnSaveSchoolFeesANT_Click(object sender, EventArgs e)
        {
            // ANT - Add New Term

            var session = cboSessionANT.SelectedValue;
            var term = cboTermANT.SelectedValue;
            var jss1 = tboJss1ANT.Text;
            var jss2 = tboJss2ANT.Text;
            var jss3 = tboJss3ANT.Text;
            var sss1 = tboSss1ANT.Text;
            var sss2 = tboSss2ANT.Text;
            var sss3 = tboSss3ANT.Text;
            var jss = tboJssANT.Text;
            var sss = tboSssANT.Text;

            if (session != "" && term != "" && !string.IsNullOrWhiteSpace(jss1) && !string.IsNullOrWhiteSpace(jss2) &&
                !string.IsNullOrWhiteSpace(jss3) && !string.IsNullOrWhiteSpace(sss1) && !string.IsNullOrWhiteSpace(sss2) &&
                !string.IsNullOrWhiteSpace(sss3) && !string.IsNullOrWhiteSpace(jss) && !string.IsNullOrWhiteSpace(sss))
            {
                // Check to see if it's a number

                decimal result;

                if (decimal.TryParse(jss1, out result) && decimal.TryParse(jss2, out result) &&
                    decimal.TryParse(jss3, out result) && decimal.TryParse(sss1, out result) &&
                    decimal.TryParse(sss2, out result) && decimal.TryParse(sss3, out result) &&
                    decimal.TryParse(jss, out result) && decimal.TryParse(sss, out result))
                {
                    //todo: if first term and students have not been promoted, promote students first before adding fees

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
                        Session = session.ToString(),
                        StartDate = DateTime.Now,
                        EndDate = null,
                        Active = true,
                        Fee = fee,
                        TermEnum = (TermEnum) term
                    }).ToList();

                    _activatedAndDeactivatedId = _classTermFeeRepository.AddClassTermFees(classTermFees, _username);

                    if (_activatedAndDeactivatedId == null)
                    {
                        MessageBox.Show(@"Something went wrong, Please try again", @"School Accountant");
                    }

                    MessageBox.Show(@"Fees added, click the 'undo' button to delete");

                    // Enable the undo button
                    btnUndoLastAddFeesANT.Enabled = true;

                    // todo: add new fee to all students and undo deletes the fee
                }
                else
                {
                    MessageBox.Show(@"Please, enter only numbers to fees");
                }
            }
            else
            {
                MessageBox.Show(@"Please, all information are required");
            }
        }

        private void btnUndoLastAddFeesANT_Click(object sender, EventArgs e)
        {
            if (_activatedAndDeactivatedId.ActivatedIds != null)
            {
                var success = _classTermFeeRepository.DeleteCurrentFeesAndActivatePreviousFees(_activatedAndDeactivatedId, _username);

                MessageBox.Show(success ? @"Fees deleted successfully" : @"Something went wrong, please try again");
                tsslAddNewTerm.Text = @"Fees deleted successfully";

                SetCurrentFeesInAddNewTermTab();

            }
            else
            {
                MessageBox.Show(@"No recent fee was added");
            }
        }

        private void SetCurrentFeesInAddNewTermTab()
        {
            var currentFees = _classTermFeeRepository.GetCurrentFees();
            tboJss1ANT.Text = currentFees.Where(x => x.ClassEnum == ClassEnum.JSS1).Select(x => x.Fee).FirstOrDefault().ToString();
            tboJss2ANT.Text = currentFees.Where(x => x.ClassEnum == ClassEnum.JSS2).Select(x => x.Fee).FirstOrDefault().ToString();
            tboJss3ANT.Text = currentFees.Where(x => x.ClassEnum == ClassEnum.JSS3).Select(x => x.Fee).FirstOrDefault().ToString();
            tboSss1ANT.Text = currentFees.Where(x => x.ClassEnum == ClassEnum.SSS1).Select(x => x.Fee).FirstOrDefault().ToString();
            tboSss2ANT.Text = currentFees.Where(x => x.ClassEnum == ClassEnum.SSS2).Select(x => x.Fee).FirstOrDefault().ToString();
            tboSss3ANT.Text = currentFees.Where(x => x.ClassEnum == ClassEnum.SSS3).Select(x => x.Fee).FirstOrDefault().ToString();
            tboJssANT.Text = currentFees.Where(x => x.ClassEnum == ClassEnum.JSS).Select(x => x.Fee).FirstOrDefault().ToString();
            tboSssANT.Text = currentFees.Where(x => x.ClassEnum == ClassEnum.SSS).Select(x => x.Fee).FirstOrDefault().ToString();
        }

    }
}