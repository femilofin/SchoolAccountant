using System.Collections.Generic;

namespace BusinessLogic.Interface
{
    public interface IService<in TM>
    {
        bool Create(TM model);
        bool Edit(TM model);
        bool Delete(string id);
    }
}
