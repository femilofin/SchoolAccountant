using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Constants;
using MongoRepository;

namespace BusinessLogic.Entities
{
    public class School : Entity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public IList<string> PhoneNumbers { get; set; }
        public string PresentSession { get; set; }
        public TermEnum PresentTermEnum { get; set; }
        public DateTime SessionStart { get; set; }
        public DateTime TermStart { get; set; }
        public int StudentCount { get; set; }
        public DateTime PromotionDate { get; set; }
        public string LogoPath { get; set; }
        public string Slogan { get; set; }
    }
}
