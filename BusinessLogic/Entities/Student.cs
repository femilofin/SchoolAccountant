using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Constants;
using MongoRepository;

namespace BusinessLogic.Entities
{
    public class Student : Entity
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int StartClass { get; set; }
        public int StartTerm { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }
        public DateTime StartDate { get; set; }
    }
}