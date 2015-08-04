using System.Collections.Generic;
using BusinessLogic.Entities;

namespace BusinessLogic.Interface
{
    public interface IStudentRepository : IService<Student>
    {
        IList<Student> GetActiveStudents();

    }
}
