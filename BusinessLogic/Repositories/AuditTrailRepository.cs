using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Entities;
using BusinessLogic.Interface;

namespace BusinessLogic.Repositories
{
    public class AuditTrailRepository : IAuditTrailRepository
    {
        public bool Create(AuditTrail model)
        {
            throw new NotImplementedException();
        }

        public bool Edit(AuditTrail model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AuditTrail> Query(int page, int count, string orderByExpression = null, string whereCondition = null)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
