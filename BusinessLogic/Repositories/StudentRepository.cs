using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Constants;
using BusinessLogic.Entities;
using BusinessLogic.Interface;
using log4net;
using log4net.Config;
using MongoDB.Driver;
using MongoRepository;

namespace BusinessLogic.Repositories
{
    /// <summary>
    /// Contains the methods for student collection
    /// </summary>
    public class StudentRepository : IStudentRepository
    {
        private readonly ILog _log = LogManager.GetLogger("BusinessLogic.StudentRepository.cs");
        private readonly MongoRepository<Student> _studentRepository = new MongoRepository<Student>();
        readonly IAuditTrailRepository _auditTrailRepository = new AuditTrailRepository();
        private readonly ISchoolRepository _schoolRepository = new SchoolRepository();
        private readonly IClassTermFeeRepository _classTermFeeRepository = new ClassTermFeeRepository();


        public StudentRepository()
        {
            XmlConfigurator.Configure();
        }

        /// <summary>
        /// Retrieve all active students in the collection
        /// </summary>
        /// <returns>A list of students</returns>
        public IList<Student> GetActiveStudents()
        {
            try
            {
                return _studentRepository.Where(x => x.Active).OrderBy(x => x.LastName).ToList();
            }
            catch (MongoConnectionException ex)
            {
                _log.Error("Mongodb", ex);
                return null;
            }
            catch (Exception ex)
            {
                _log.Error("Others", ex);
                return null;
            }
        }

        /// <summary>
        /// Deactivates the student
        /// </summary>
        /// <param name="id">Student id</param>
        /// <returns>if success, true, else false</returns>
        public bool DeactivateStudent(string id)
        {
            try
            {
                var student = _studentRepository.GetById(id);

                student.Active = false;
                student.DeactivatedDate = DateTime.Now;

                _studentRepository.Update(student);

                // Decrease Student Count
                DecreaseStudentCount();

                _auditTrailRepository.Log($"Deactivated Student {student.FirstName} {student.LastName}", AuditActionEnum.Deactivated);

                _log.Info("Student Deactivated");

                return true;
            }
            catch (Exception ex)
            {
                _log.Error("Error", ex);
                return false;
            }

        }


        /// <summary>
        /// Add new student into the student collection
        /// </summary>
        /// <param name="model">Loaded student class</param>
        /// <returns>Whether the method is successful</returns>
        public bool Create(Student model)
        {
//            bool studentExist = CheckIfStudentExist(model);
//
//            if (studentExist) return false;

            try
            {
                _studentRepository.Add(model);

                // Add fee
                UpdateStudentFees(model);

                // Update Student count
                IncreaseStudentCount();

                _auditTrailRepository.Log($"Created Student {model.FirstName} {model.LastName}", AuditActionEnum.Created);

                _log.Info("Student Added");

                return true;
            }
            catch (Exception ex)
            {
                _log.Error("Error", ex);
                return false;
            }
        }

        private bool CheckIfStudentExist(Student student)
        {
            return
                _studentRepository.Any(x => string.Equals(x.FirstName.Trim(), student.FirstName.Trim(),
                            StringComparison.CurrentCultureIgnoreCase) &&
                        string.Equals(x.LastName.Trim(), student.LastName.Trim(),
                            StringComparison.CurrentCultureIgnoreCase) &&
                        string.Equals(x.MiddleName.Trim(), student.MiddleName.Trim(),
                            StringComparison.CurrentCultureIgnoreCase));
        }

        private void IncreaseStudentCount()
        {
            var school = _schoolRepository.Get();
            school.StudentCount++;

            _schoolRepository.Edit(school);
        }

        private void DecreaseStudentCount()
        {
            var school = _schoolRepository.Get();
            school.StudentCount--;

            _schoolRepository.Edit(school);
        }

        /// <summary>
        /// Updates the student
        /// </summary>
        /// <param name="student">Instance of the given student</param>
        /// <returns>true if success else false</returns>
        public bool Update(Student student)
        {
            try
            {
                _studentRepository.Update(student);

                _auditTrailRepository.Log($"Updated Student {student.FirstName} {student.LastName}", AuditActionEnum.Updated);

                _log.Info("Student Edited");

                return true;
            }
            catch (Exception ex)
            {
                _log.Error("Error", ex);
                return false;
            }
        }


        /// <summary>
        /// Edit the student info from the dgv
        /// </summary>
        /// <param name="model">Instance of student class</param>
        /// <returns>True if success, else false</returns>
        public bool Edit(Student model)
        {
            try
            {
                var studentFromDb = _studentRepository.GetById(model.Id);

                // Update items
                studentFromDb.MiddleName = model.MiddleName;
                studentFromDb.FirstName = model.FirstName;
                studentFromDb.LastName = model.LastName;
                studentFromDb.BirthDate = model.BirthDate;
                studentFromDb.StartDate = model.StartDate;
                studentFromDb.PresentArm = model.PresentArm;

                _studentRepository.Update(model);

                _auditTrailRepository.Log($"Student {model.FirstName} {model.LastName}", AuditActionEnum.Updated);

                _log.Info("Student Edited");

                return true;

            }
            catch (Exception ex)
            {
                _log.Error("Error", ex);
                return false;
            }
        }

        /// <summary>
        /// Delete Student from the student collection
        /// </summary>
        /// <param name="id">Student Id</param>
        /// <returns>Whether the method is successful</returns>
        public bool Delete(string id)
        {
            try
            {
                var student = _studentRepository.GetById(id);

                _studentRepository.Delete(student);

                // Decrease student count
                DecreaseStudentCount();

                _auditTrailRepository.Log($"Student {student.FirstName} {student.LastName}", AuditActionEnum.Deleted);

                return true;
            }
            catch (Exception ex)
            {
                _log.Error("Error", ex);
                return false;
            }
        }

        /// <summary>
        /// Update the fees of a given student, only for when adding a new student 
        /// (not necessary new to the school) to the system
        /// </summary>
        /// <param name="student">The student whose fees is to be updated</param>
        /// <returns>true if success else false</returns>
        public bool UpdateStudentFees(Student student)
        {
            try
            {
                var currentFees = _classTermFeeRepository.GetCurrentFees() ?? new List<ClassTermFee>();

                var presentClass = student.PresentClass;


                var isNewIntake = presentClass == student.StartClass && student.PresentTerm == student.StartTerm;

                if (isNewIntake)
                {
                    switch (presentClass)
                    {
                        case ClassEnum.JSS1:
                        case ClassEnum.JSS2:
                        case ClassEnum.JSS3:
                            student.OutstandingFee += currentFees.FirstOrDefault(x => x.ClassEnum == ClassEnum.JSS).Fee;

                            _studentRepository.Update(student);

                            break;

                        case ClassEnum.SSS1:
                        case ClassEnum.SSS2:
                        case ClassEnum.SSS3:
                            student.OutstandingFee += currentFees.FirstOrDefault(x => x.ClassEnum == ClassEnum.SSS).Fee;

                            _studentRepository.Update(student);

                            break;
                    }
                    return true;
                }

                var classTermFee = currentFees.FirstOrDefault(x => x.ClassEnum == presentClass);

                // Not new student
                student.OutstandingFee += classTermFee.Fee;

                _studentRepository.Update(student);

                return true;

            }
            catch (Exception ex)
            {
                _log.Error("Error", ex);
                return false;
            }
        }

        /// <summary>
        /// Used to promote all promoting students
        /// </summary>
        /// <param name="repeatingStudents">A list of repeating students</param>
        /// <returns>true if success else false</returns>
        public bool PromoteStudents(List<Student> repeatingStudents)
        {
            try
            {
                // Get all active students
                var students = GetActiveStudents();

                var repeatingStudentsList = repeatingStudents ?? new List<Student>();

                // Get promoting students
                var promotingStudents = students.Where(x => repeatingStudentsList.All(y => y.Id != x.Id)).ToList();

                foreach (var student in promotingStudents)
                {
                    var presentClass = student.PresentClass;    

                    switch (presentClass)
                    {
                        case ClassEnum.JSS1:
                            {
                                //Promote to Jss 2
                                student.PresentClass = ClassEnum.JSS2;
                                Update(student);
                            }
                            break;
                        case ClassEnum.JSS2:
                            {
                                //Promote to Jss 3
                                student.PresentClass = ClassEnum.JSS3;
                                Update(student);
                            }
                            break;
                        case ClassEnum.JSS3:
                            {
                                //Promote to Sss 1
                                student.PresentClass = ClassEnum.SSS1;
                                Update(student);
                            }
                            break;
                        case ClassEnum.SSS1:
                            {
                                //Promote to Sss 2
                                student.PresentClass = ClassEnum.SSS2;
                                Update(student);
                            }
                            break;
                        case ClassEnum.SSS2:
                            {
                                //Promote to Sss 3
                                student.PresentClass = ClassEnum.SSS3;
                                Update(student);
                            }
                            break;
                        case ClassEnum.SSS3:
                            {
                                // Deactivate student
                                student.Active = false;
                                Update(student);
                            }
                            break;
                    }

                }

                var school = _schoolRepository.Get();

                // Update School details

                school.PromotionDate = DateTime.Now;
                _schoolRepository.Edit(school);

                return true;
            }
            catch (Exception ex)
            {
                _log.Error("Error", ex);
                return false;
            }
        }

        public Student GetStudentById(string id)
        {
            return _studentRepository.GetById(id);
        }

        /// <summary>
        /// Updates the fees of all active students
        /// </summary>
        /// <returns>true if success else false</returns>
        public bool UpdateStudentFees()
        {
            try
            {
                var students = GetActiveStudents();

                var currentFees = _classTermFeeRepository.GetCurrentFees();

                foreach (var student in students)
                {
                    var presentClass = student.PresentClass;

                    var classTermFee = currentFees.FirstOrDefault(x => x.ClassEnum == presentClass);

                    student.OutstandingFee += classTermFee.Fee;

                    _studentRepository.Update(student);
                }

                return true;

            }
            catch (Exception ex)
            {
                _log.Error("Error", ex);
                return false;
            }

        }

        /// <summary>
        /// Undo/delete the last added fee during the current session
        /// </summary>
        /// <returns>true if success else false</returns>
        public bool UndoUpdatedFees()
        {
            try
            {
                var students = GetActiveStudents();

                var currentFees = _classTermFeeRepository.GetCurrentFees();

                foreach (var student in students)
                {
                    var presentClass = student.PresentClass;

                    var classTermFee = currentFees.FirstOrDefault(x => x.ClassEnum == presentClass);

                    student.OutstandingFee -= classTermFee.Fee;

                    _studentRepository.Update(student);

                }
                return true;

            }
            catch (Exception ex)
            {
                _log.Error("Error", ex);
                return false;
            }
        }
    }
}
