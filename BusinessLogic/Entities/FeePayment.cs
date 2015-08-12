using System;

namespace BusinessLogic.Entities
{
    public class FeePayment
    {
        public string ClassArmTermFeeId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaidDate { get; set; }
        public bool HasCollectedReceipt { get; set; }
    }
}
