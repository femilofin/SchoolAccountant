using System;
using BusinessLogic.Constants;
using MongoRepository;

namespace BusinessLogic.Entities
{
    public class AuditTrail : Entity
    {
        public string Details { get; set; }
        public DateTime TimeStamp { get; set; }
        public AuditActionEnum AuditAction { get; set; }
    }
}
