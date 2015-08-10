using BusinessLogic.Entities;
using BusinessLogic.Interface;
using BusinessLogic.Repositories;
using FizzWare.NBuilder;
using NUnit.Framework;

namespace SchoolAccountantTest
{
    [TestFixture]
    public class StudentRepositoryTest
    {
        private readonly IStudentRepository _studentRepository =  new StudentRepository();

        [Test]
        public void GetActiveStudentsShouldNotReturnNull()
        {
            var students = _studentRepository.GetActiveStudents();
            Assert.AreNotEqual(null, students);
        }

        [Test]
        public void AddUpdateDeactivateAndDeleteShouldReturnTrue()
        {
            // Add
            var student = Builder<Student>.CreateNew().With(x => x.Id = null).Build();
            var addSuccess = _studentRepository.Create(student);
            Assert.AreEqual(true, addSuccess);

            // Edit
            student.LastName = "TestLastName";
            var editSuccess = _studentRepository.Edit(student);
            Assert.AreEqual(true, editSuccess);

            // Update
            var updateSuccess = _studentRepository.Update(student);
            Assert.IsTrue(updateSuccess);

            // Deactivate
            var deactivated = _studentRepository.DeactivateStudent(student.Id);
            Assert.AreEqual(true, deactivated);

            // Delete
            var deleteSuccess = _studentRepository.Delete(student.Id);
            Assert.AreEqual(true, deleteSuccess);
        }

        [Test]
        public void UpdateAndUndoUpdateStudentFeesReturnsTrue()
        {
            var updated = _studentRepository.UpdateStudentFees();
            Assert.IsTrue(updated);

            var undidUpdated = _studentRepository.UndoUpdatedFees();
            Assert.IsTrue(undidUpdated);
        }

    }
}
