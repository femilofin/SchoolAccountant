using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Constants;
using MongoRepository;

namespace BusinessLogic.Entities
{
    public class ClassArm : Entity
    {
        public ClassEnum ClassEnum { get; set; }
        public string Arm { get; set; }
    }
}
