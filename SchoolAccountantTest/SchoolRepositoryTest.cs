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
    public class SchoolRepositoryTest
    {
        private readonly ISchoolRepository _schoolRepository = new SchoolRepository();
        
        [Test]
        public void SetupSchoolReturnsSchoolIdAndDeleteReturnsTrue()
        {
            var school = Builder<School>.CreateNew().With(x => x.Id = null).Build();
            var schoolId = _schoolRepository.SchoolSetup(school);
            Assert.IsNotNull(schoolId);

            var deleteSuccess = _schoolRepository.Delete(schoolId);
            Assert.IsTrue(deleteSuccess);
        }

        [Test]
        public void GetSchoolDoesNotReturnNull()
        {
            var school = _schoolRepository.Get();
            Assert.IsNotNull(school);
        }

        [Test]
        public void UpdateAndUndoUpdateStudentFeesReturnsTrue()
        {
            var updated = _schoolRepository.UpdateStudentFees();
            Assert.IsTrue(updated);

            var undidUpdated = _schoolRepository.UndoUpdatedFees();
            Assert.IsTrue(undidUpdated);
        }
    }
}
