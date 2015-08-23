using System;
using System.Security.AccessControl;

namespace BusinessLogic.Entities
{
    public class FeePayment
    {
        public string ClassArmTermFeeId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaidDate { get; set; }
        public bool HasCollectedReceipt { get; set; }
        public string Bank { get; set; }
        public string ReceiptNumber { get; set; }
        public string ChequeNumber { get; set; }
        public string Comment { get; set; }
        public string PaidBy { get; set; }
    }
}
