using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Entities;
using BusinessLogic.Interface;
using MongoDB.Driver;
using MongoRepository;


namespace BusinessLogic.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly MongoRepository<Student> _studentRepository = new MongoRepository<Student>(); 
       
        public IList<Student> GetActiveStudents()
        {
            return _studentRepository.Where(x => x.Active).ToList();
        }

        public bool AddStudent(Student student)
        {
            try
            {
                _studentRepository.Add(student);
                return true;
                // Log
            }
            catch (MongoCommandException ex)
            {
                return false;
            }
        }
    }
}
