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
using SchoolAccountant.Helpers;

#endregion
namespace SchoolAccountant.Forms
{
    public partial class DashBoard : Form
    {
        private readonly IStudentRepository _studentRepository = new StudentRepository();
        private readonly IUserRepository _userRepository = new UserRepository();
        readonly DataGridViewButtonColumn _btnViewInfo = new DataGridViewButtonColumn();
        readonly DataGridViewButtonColumn _btnViewPaymentHistory = new DataGridViewButtonColumn();
        readonly DataGridViewButtonColumn _btnPayFee = new DataGridViewButtonColumn();
        readonly DataGridViewButtonColumn _btnDeactivateStudent = new DataGridViewButtonColumn();



        public DashBoard()
        {
            InitializeComponent();
            Utilities.InitialiizeClassCombo(new[] { cboStartClassAS, cboPresentClassAS, cboClassMS });
            Utilities.InitialiizeTermCombo(new[] { cboStartTermAS, cboPresentTermAS });
            Utilities.InitialiizeArmCombo(new[] { cboArmMS, cboPresentArmAS });
            Utilities.InitialiizeFeeStatusCombo(new[] { cboFeeStatusMS });
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
                tsslTableStatus.Text = string.Format("{0} records found", activeStudents.Count);

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
            tsslTableStatus.Text = string.Format("{0} records found", activeStudents.Count);

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
                        string.Format("{0} {1} {2}", activeStudents[i].LastName.ToUpper(), activeStudents[i].FirstName,
                            activeStudents[i].MiddleName),
                    PresentClass =
                        string.Format("{0} {1}", activeStudents[i].PresentClass, activeStudents[i].PresentArm),
                    OutstandingFee =
                        activeStudents[i].OutstandingFee > 0
                            ? string.Format("NGN {0}", activeStudents[i].OutstandingFee)
                            : "Cleared",
                    PaidFee = string.Format("NGN {0}", activeStudents[i].PaidFee),
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

                    
                }
                    );

            }

            return studentViews;
        }

        private void UpdateStatusLabel(IReadOnlyCollection<Student> filteredActiveStudentsByClass, ICollection<Student> activeStudents)
        {
            tsslTableStatus.Text = string.Format("{0} record(s) found out of {1} records available.",
                filteredActiveStudentsByClass.Count, activeStudents.Count);
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
                .Add(3, "OutstandingFee", "Debt", foreColor: Color.Red, width: 80, readOnly: true);

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
            var startDate = dtpStartDateAS.Text;
            var birthDate = dtpBirthDateAS.Text;
            var outstandingFee = tboOutstandingFeeAS.Text;
            var startClass = cboStartClassAS.SelectedValue;
            var startTerm = cboStartTermAS.SelectedValue;
            var presentClass = cboPresentClassAS.SelectedValue;
            var presentTerm = cboPresentTermAS.SelectedValue;
            var presentArm = cboPresentArmAS.SelectedValue;

            if (!string.IsNullOrWhiteSpace(lastName) && !string.IsNullOrWhiteSpace(firstName) &&
                !string.IsNullOrWhiteSpace(middleName) && !string.IsNullOrWhiteSpace(outstandingFee))
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
                    OutstandingFee = Convert.ToDecimal(outstandingFee),
                    PresentClass = (ClassEnum)presentClass,
                    PresentTerm = (TermEnum)presentTerm,
                    PresentArm = (ArmEnum)presentArm

                };

                var success = _studentRepository.Add(student);

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
            cboStartTermAS.SelectedIndex = 0;
            cboStartClassAS.SelectedIndex = 0;
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
            if (e.ColumnIndex == (int)ButtonColumnIndex.PayFee)
            {
                var row = dgvViewStudent.Rows[e.RowIndex];
                new PayFee(row).ShowDialog();

            }


            // if view info
            else if (e.ColumnIndex == (int)ButtonColumnIndex.ViewInfo)
            {
                var row = dgvViewStudent.Rows[e.RowIndex];
                new ViewInfo(row).ShowDialog();
            }

             // if view fee history
            else if (e.ColumnIndex == (int)ButtonColumnIndex.FeeHistory)
            {
                var row = dgvViewStudent.Rows[e.RowIndex];
                new FeeHistory(row).ShowDialog();
            }

             // if deactivate student
            else if (e.ColumnIndex == (int)ButtonColumnIndex.Deactivate)
            {
                MessageBox.Show("Deactivated");
            }
        }

    }
}