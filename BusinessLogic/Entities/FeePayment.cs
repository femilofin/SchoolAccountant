using System;

namespace BusinessLogic.Entities
{
    public class FeePayment
    {
        public string ClassArmTermFeeId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ReceiptDate { get; set; }
        public bool HasCollectedReceipt { get; set; }
        public string UserId { get; set; }
        public bool IsFullPayment { get; set; }
    }
}
