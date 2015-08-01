using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Constants;
using BusinessLogic.Entities;
using BusinessLogic.Interface;
using log4net;
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
            log4net.Config.XmlConfigurator.Configure();
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
        /// Add new student into the student collection
        /// </summary>
        /// <param name="model">Loaded student class</param>
        /// <returns>Whether the method is successful</returns>
        public bool Create(Student model)
        {
            try
            {
                _studentRepository.Add(model);

                _auditTrailRepository.Log(string.Format("Created Student {model.FirstName} {model.LastName}"), AuditActionEnum.Create);

                _log.Info("Student Added");

                return true;
            }
            catch (MongoConnectionException ex)
            {
                _log.Error("Mongodb", ex);
                return false;
            }
            catch (Exception ex)
            {
                _log.Error("Others", ex);
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

                _auditTrailRepository.Log(string.Format("Edited Student {model.FirstName} {model.LastName}"), AuditActionEnum.Update);

                _log.Info("Student Edited");

                return true;
            }
            catch (MongoConnectionException ex)
            {
                _log.Error("Mongodb", ex);
                return false;
            }
            catch (Exception ex)
            {
                _log.Error("Others", ex);
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

                _auditTrailRepository.Log(string.Format("Deleted Student {model.FirstName} {model.LastName}"), AuditActionEnum.Delete);

                return true;
            }
            catch (MongoConnectionException ex)
            {
                _log.Error("Mongodb", ex);
                return false;
            }
            catch (Exception ex)
            {
                _log.Error("Others", ex);
                return false;
            }
        }
    }
}
