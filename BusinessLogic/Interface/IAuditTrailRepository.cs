using BusinessLogic.Constants;
using BusinessLogic.Entities;

namespace BusinessLogic.Interface
{
    public interface IAuditTrailRepository
    {
        AuditTrail Log(string detail, AuditActionEnum actionEnum);
    }
}
