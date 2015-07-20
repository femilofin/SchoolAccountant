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
    public class UserRepositoryTest
    {
        readonly IUserRepository _userRepository = new UserRepository();

        [Test]
        public void LoginShouldReturnTrue()
        {
            var success = _userRepository.Login("admin", "3756");
            Assert.AreEqual(true, success);
        }

        [Test]
        public void RegisterAndDeleteShouldReturnTrue()
        {
            var user = Builder<User>.CreateNew().With(x => x.Id = null).Build();
            var registerSuccess = _userRepository.Register(user);
            Assert.AreEqual(true, registerSuccess);

            var deleteSuccess = _userRepository.Delete(user);
            Assert.AreEqual(true, deleteSuccess);
        }
    }
}
