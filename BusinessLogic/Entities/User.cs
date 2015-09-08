using System;
using MongoRepository;

namespace BusinessLogic.Entities
{
    public class User : Entity
    {
        public string FullName { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
