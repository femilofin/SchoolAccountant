using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Constants;
using MongoRepository;

namespace BusinessLogic.Entities
{
    public class ClassArmTermFee : Entity
    {
        public ClassEnum ClassEnum { get; set; }
        public string ClassArmId { get; set; }
        public TermEnum TermEnum { get; set; }
        public decimal Fee { get; set; }
        public bool Active { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
