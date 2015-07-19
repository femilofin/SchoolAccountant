using System.Collections.Generic;
using BusinessLogic.Entities;

namespace BusinessLogic.Interface
{
    public interface IStudentRepository
    {
        IList<Student> GetActiveStudents();
        bool AddStudent(Student student);
    }
}
