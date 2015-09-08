using BusinessLogic.Entities;

namespace BusinessLogic.Interface
{
    public interface IUserRepository : IService<User>
    {
        bool Login(string username, byte[] passwordHash);
    }
}