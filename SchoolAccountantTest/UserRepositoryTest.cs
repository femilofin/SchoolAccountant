using BusinessLogic.Entities;
using BusinessLogic.Interface;
using BusinessLogic.Repositories;
using FizzWare.NBuilder;
using NUnit.Framework;
using SchoolAccountant.Helpers;

namespace SchoolAccountantTest
{
    [TestFixture]
    public class UserRepositoryTest
    {
        readonly IUserRepository _userRepository = new UserRepository();

        [Test]
        public void LoginShouldReturnTrue()
        {
            var success = _userRepository.Login("admin", Utilities.GetPasswordHash("3756"));
            Assert.AreEqual(true, success);
        }

        [Test]
        public void RegisterAndDeleteShouldReturnTrue()
        {
            var user = Builder<User>.CreateNew().With(x => x.Id = null).Build();
            var registerSuccess = _userRepository.Create(user);
            Assert.AreEqual(true, registerSuccess);

            var deleteSuccess = _userRepository.Delete(user.Id);
            Assert.AreEqual(true, deleteSuccess);
        }
    }
}
