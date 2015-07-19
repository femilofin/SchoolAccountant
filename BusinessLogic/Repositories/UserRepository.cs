using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Entities;
using BusinessLogic.Interface;
using MongoDB.Driver;
using MongoRepository;


namespace BusinessLogic.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MongoRepository<User> _userRepository = new MongoRepository<User>();

        public bool Login(string username, string password)
        {
            try
            {
                var isARegisteredUser = _userRepository.Any(x => x.Username == username && x.PasswordHash == password);
                return isARegisteredUser;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Register(User user)
        {
            try
            {
                _userRepository.Add(user);
                return true;
            }
            catch (MongoConnectionException ex)
            {
                // Logged error
                return false;
            }

        }
    }
}
