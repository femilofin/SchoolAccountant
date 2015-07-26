using System;
using System.Linq;
using BusinessLogic.Entities;
using BusinessLogic.Interface;
using log4net;
using log4net.Config;
using MongoDB.Driver;
using MongoRepository;

namespace BusinessLogic.Repositories
{
    /// <summary>
    ///     Contains the methods for the user collection.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly ILog _log = LogManager.GetLogger("BusinessLogic.UserRepository.cs");
        private readonly MongoRepository<User> _userRepository = new MongoRepository<User>();

        public UserRepository()
        {
            XmlConfigurator.Configure();
        }


        /// <summary>
        ///     Checks if user exist in the user collection.
        /// </summary>
        /// <param name="username">Username of the user.</param>
        /// <param name="password">Password of the user.</param>
        /// <returns>True if the login succeeds; otherwise, false</returns>
        public bool Login(string username, string password)
        {
            try
            {
                bool isARegisteredUser = _userRepository.Any(x => x.Username == username && x.PasswordHash == password);
                return isARegisteredUser;
            }
            catch (MongoConnectionException ex)
            {
                _log.Error("Mongodb", ex);
                return false;
            }
            catch (Exception ex)
            {
                _log.Error("Others", ex);
                return false;
            }
        }

        /// <summary>
        ///     Add user to the user collection.
        /// </summary>
        /// <param name="user">An instance of the user class.</param>
        /// <returns>True if the registration succeeds; otherwise, false.</returns>
        public bool Register(User user)
        {
            try
            {
                _userRepository.Add(user);
                return true;
            }
            catch (MongoConnectionException ex)
            {
                _log.Error("Mongodb", ex);
                return false;
            }
            catch (Exception ex)
            {
                _log.Error("Others", ex);
                return false;
            }
        }

        /// <summary>
        ///     Delete User from the user collection.
        /// </summary>
        /// <param name="user">An instance of the user class.</param>
        /// <returns>True if the registration succeeds; otherwise, false.</returns>
        public bool Delete(User user)
        {
            try
            {
                _userRepository.Delete(user);
                return true;
            }
            catch (MongoConnectionException ex)
            {
                _log.Error("Mongodb", ex);
                return false;
            }
            catch (Exception ex)
            {
                _log.Error("Others", ex);
                return false;
            }
        }
    }
}