using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Entities;


namespace BusinessLogic.Interface
{
    public interface IUserRepository
    {
        bool Login(string username, string password);
        bool Register(User user);
        bool Delete(User user);

    }
}
