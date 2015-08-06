using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Entities;
using BusinessLogic.Utility;
using MongoRepository;

namespace BusinessLogic.Interface
{
    public interface IClassTermFeeRepository
    {
        ActivatedAndDeactivatedId AddClassTermFees(IList<ClassTermFee> classTermFees, string username);
        bool DeleteCurrentFeesAndActivatePreviousFees(ActivatedAndDeactivatedId activatedAndDeactivatedId, string username);
        List<ClassTermFee> GetCurrentFees();
    }
}
