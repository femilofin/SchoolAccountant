using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IService<TM>
    {
        bool Create(TM model);
        bool Edit(TM model);
        IEnumerable<TM> Query(int page, int count,
            string orderByExpression = null, string whereCondition = null);
        bool Delete(string id);
    }
}
