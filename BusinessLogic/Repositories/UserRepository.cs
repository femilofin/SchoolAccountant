using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Entities;
using BusinessLogic.Interface;
using log4net;
using MongoDB.Driver;
using MongoRepository;


namespace BusinessLogic.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MongoRepository<User> _userRepository = new MongoRepository<User>();
        private readonly ILog _log = LogManager.GetLogger("BusinessLogic.UserRepository.cs");

        public UserRepository()
        {
            log4net.Config.XmlConfigurator.Configure();
        }


        public bool Login(string username, string password)
        {
            try
            {
                var isARegisteredUser = _userRepository.Any(x => x.Username == username && x.PasswordHash == password);
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
