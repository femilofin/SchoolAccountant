using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using MongoRepository;

namespace BusinessLogic.Entities
{
    public class User : Entity
    {
        public string FullName { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
