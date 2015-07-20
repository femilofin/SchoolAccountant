using System;
using System.Collections.Generic;
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
    public class StudentRepository : IStudentRepository
    {
        private readonly ILog _log = LogManager.GetLogger("BusinessLogic.StudentRepository.cs");
        private readonly MongoRepository<Student> _studentRepository = new MongoRepository<Student>(); 
        
        public StudentRepository()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
       
        public IList<Student> GetActiveStudents()
        {
            try
            {
                return _studentRepository.Where(x => x.Active).ToList();
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

        public bool AddStudent(Student student)
        {
            try
            {
                _studentRepository.Add(student);
                _log.Info(String.Format("Student \"{0}\" \"{1}\"  Added", student.FirstName, student.LastName));
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
    }
}
