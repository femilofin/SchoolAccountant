using BusinessLogic.Entities;
using BusinessLogic.Interface;
using BusinessLogic.Repositories;
using FizzWare.NBuilder;
using NUnit.Framework;

namespace SchoolAccountantTest
{
    [TestFixture]
    public class ClassTermFeeRepositoryTest
    {
        private readonly IClassTermFeeRepository _classTermFeeRepository = new ClassTermFeeRepository();
        private readonly IAuditTrailRepository _auditTrailRepository = new AuditTrailRepository();

        /// <summary>
        /// GetCurrentFees should not return null
        /// </summary>
        [Test]
        public void GetCurrentFeesShouldNotReturnNull()
        {
            // Get current fees
            var currentFees = _classTermFeeRepository.GetCurrentFees();
            Assert.AreNotEqual(null, currentFees);
        }

        /// <summary>
        /// AddClassTermFees should not return null and delete fees should return true
        /// </summary>
        [Ignore]
        [Test]
        public void AddClassTermFeesDoesNotReturnNullAndDeleteReturnsTrue()
        {
            var classTermFees = Builder<ClassTermFee>.CreateListOfSize(8).All().With(x => x.Id = null).And(x => x.Active = true).And(x => x.EndDate = null).Build();
            var activatedAndDeactivatedId =  _classTermFeeRepository.AddClassTermFees(classTermFees, "Test");
            Assert.AreNotEqual(null, activatedAndDeactivatedId);
            
            var success = _classTermFeeRepository.DeleteCurrentFeesAndActivatePreviousFees(activatedAndDeactivatedId, "Test");
            Assert.AreEqual(true, success);

            var deleteSuccess = _auditTrailRepository.DeleteTestLog();
            Assert.AreEqual(true, deleteSuccess);
        }


    }
}
