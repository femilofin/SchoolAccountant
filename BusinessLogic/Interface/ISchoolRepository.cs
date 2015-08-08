using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Entities;

namespace BusinessLogic.Interface
{
    public interface ISchoolRepository
    {
        string SchoolSetup(School school);
        bool Delete(string id);
        School Get();
        bool PromoteStudents(List<Student> repeatingStudents);
        bool UpdateStudentFees();
        bool UndoUpdatedFees();
    }
}
