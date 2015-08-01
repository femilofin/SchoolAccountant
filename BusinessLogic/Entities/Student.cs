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
        public ClassEnum StartClass { get; set; }
        public TermEnum StartTerm { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }
        public DateTime StartDate { get; set; }
        public decimal OutstandingFee { get; set; }
        public decimal PaidFee { get; set; }
        public ClassEnum PresentClass { get; set; }
        public TermEnum PresentTerm { get; set; }
        public ArmEnum PresentArm { get; set; }
        public IList<FeePayment> FeePayments { get; set; } = new List<FeePayment>();


    }
}