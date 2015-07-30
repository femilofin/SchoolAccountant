using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        /// <param name="student">Loaded student class</param>
        /// <returns>Whether the method is successful</returns>
        public bool Add(Student student)
        {
            try
            {
                _studentRepository.Add(student);
                _log.Info(string.Format("Student \"{0}\" \"{1}\"  Added", student.FirstName, student.LastName));
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
        /// Delete Student from the student collection
        /// </summary>
        /// <param name="student">Instance of student class</param>
        /// <returns>Whether the method is successful</returns>
        public bool Delete(Student student)
        {
            try
            {
                _studentRepository.Delete(student);
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
        /// <param name="student">Instance of student class</param>
        /// <returns>True if success, else false</returns>
        public bool Update(Student student)
        {
            try
            {
                var studentFromDb = _studentRepository.GetById(student.Id);

                // Update items
                studentFromDb.MiddleName = student.MiddleName;
                studentFromDb.FirstName = student.FirstName;
                studentFromDb.LastName = student.LastName;
                studentFromDb.BirthDate = student.BirthDate;
                studentFromDb.StartDate = student.StartDate;
                studentFromDb.PresentArm = student.PresentArm;

                _studentRepository.Update(studentFromDb);

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
