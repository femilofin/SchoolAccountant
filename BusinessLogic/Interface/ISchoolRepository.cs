using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Entities;

namespace BusinessLogic.Interface
{
    public interface ISchoolRepository : IService<School>
    {
        string SchoolSetup(School school);
        School Get();
      
    }
}
