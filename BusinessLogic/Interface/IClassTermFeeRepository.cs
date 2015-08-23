using System.Collections.Generic;
using BusinessLogic.Constants;
using BusinessLogic.Entities;
using BusinessLogic.Utility;

namespace BusinessLogic.Interface
{
    public interface IClassTermFeeRepository
    {
        ActivatedAndDeactivatedId AddClassTermFees(IList<ClassTermFee> classTermFees, string username);
        bool DeleteCurrentFeesAndActivatePreviousFees(ActivatedAndDeactivatedId activatedAndDeactivatedId, string username);
        List<ClassTermFee> GetCurrentFees();
        ClassTermFee GetFees(string session, TermEnum term, ClassEnum classEnum);
    }
}
