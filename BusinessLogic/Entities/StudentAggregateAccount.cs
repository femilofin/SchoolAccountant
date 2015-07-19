using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoRepository;

namespace BusinessLogic.Entities
{
    public class StudentAggregateAccount : Entity
    {
        public string StudentId { get; set; }
        public decimal OutstandingFee { get; set; }
        public decimal PaidFee { get; set; }
    }
}
