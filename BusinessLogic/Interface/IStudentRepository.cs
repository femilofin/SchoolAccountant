using System.Collections.Generic;
using System.Data;
using System.Linq;
using BusinessLogic.Entities;

namespace BusinessLogic.Interface
{
    public interface IStudentRepository
    {
        IList<Student> GetActiveStudents();
        bool Add(Student student);
        bool Delete(Student student);
        bool Update(Student student);

    }
}
