using System.Collections.Generic;
using System.Data;
using System.Linq;
using BusinessLogic.Entities;

namespace BusinessLogic.Interface
{
    public interface IStudentRepository : IService<Student>
    {
        IList<Student> GetActiveStudents();

    }
}
