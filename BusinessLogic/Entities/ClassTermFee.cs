using System;
using BusinessLogic.Constants;
using MongoRepository;

namespace BusinessLogic.Entities
{
    public class ClassTermFee : Entity
    {
        public ClassEnum ClassEnum { get; set; }
        public TermEnum TermEnum { get; set; }
        public string Session { get; set; }
        public decimal Fee { get; set; }
        public bool Active { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
    