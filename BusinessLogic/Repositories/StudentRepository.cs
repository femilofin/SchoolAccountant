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
            try
            {
                _studentRepository.Add(model);

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

        /// <summary>
        /// Updates the student collection.
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

                _studentRepository.Update(studentFromDb);

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

        public IEnumerable<Student> Query(int page, int count, string orderByExpression = null, string whereCondition = null)
        {
            throw new NotImplementedException();
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

                _auditTrailRepository.Log($"Student {student.FirstName} {student.LastName}", AuditActionEnum.Deleted);
                
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
