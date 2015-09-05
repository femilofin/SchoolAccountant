using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAccountant.Models
{
    public class FeeHistoryModel
    {
        public int Index { get; set; }
        public string Session { get; set; }
        public string Term { get; set; }
        public string PaidFee { get; set; }
        public string OutstandingFee { get; set; }
        public DateTime DatePaid { get; set; }
        public string FilePath { get; set; }    
    }
}
