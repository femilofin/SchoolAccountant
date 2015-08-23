using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Entities;

namespace SchoolAccountant.Models
{
    public class ReceiptModel
    {
        public Student Student { get; set; }
        public ClassTermFee ClassTermFee { get; set; }
        public School School { get; set; }
        
    }
}
    