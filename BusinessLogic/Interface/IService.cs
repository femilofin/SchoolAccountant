using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IService<TM>
    {
        void Create(TM model);
        void Edit(TM model);
        void Delete(IEnumerable<int> ids);
        IEnumerable<TM> Query(int page, int count,
            string orderByExpression = null, string whereCondition = null);
        int GetCount(string whereCondition = null);
        TM GetDetails(int id);
        TM GetById(int id);
        void Delete(int id);
    }
}
