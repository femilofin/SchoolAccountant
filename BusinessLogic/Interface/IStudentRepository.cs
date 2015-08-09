using System;
using System.Collections.Generic;
using BusinessLogic.Entities;
using MongoRepository;

namespace BusinessLogic.Interface
{
    public interface IStudentRepository : IService<Student>
    {
        IList<Student> GetActiveStudents();
        bool DeactivateStudent(string id);
        bool Update(Student student);
        //        bool UpdateStudentFees(Student student);
        bool UpdateStudentFees();
        bool UndoUpdatedFees();

    }
}
