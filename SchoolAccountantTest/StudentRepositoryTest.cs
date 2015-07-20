using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void AddStudentShouldRetunNull()
        {
            var student = Builder<Student>.CreateNew().With(x => x.Id = null).Build();
            var addSuccess = _studentRepository.AddStudent(student);
            Assert.AreEqual(true, addSuccess);

            var deleteSuccess = _studentRepository.Delete(student);
            Assert.AreEqual(true, deleteSuccess);
        }
    }
}
