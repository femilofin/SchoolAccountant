using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Constants;
using MongoRepository;

namespace BusinessLogic.Entities
{
    public class FeePayment : Entity
    {
        public string StudentId { get; set; }
        public string ClassArmTermFeeId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ReceiptDate { get; set; }
        public bool HasCollectedReceipt { get; set; }
        public string UserId { get; set; }
        public bool IsFullPayment { get; set; }
    }
}
