using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Constants;
using BusinessLogic.Entities;
using BusinessLogic.Interface;
using log4net;
using log4net.Config;
using MongoRepository;

namespace BusinessLogic.Repositories
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly ILog _log = LogManager.GetLogger("BusinessLogic.SchoolRepository.cs");
        private readonly MongoRepository<School> _schoolRepository = new MongoRepository<School>();
        private readonly IAuditTrailRepository _auditTrailRepository = new AuditTrailRepository();

        public SchoolRepository()
        {
            XmlConfigurator.Configure();
        }

        /// <summary>
        /// Get details of the school
        /// </summary>
        /// <returns>School details</returns>
        public School Get()
        {
            try
            {
                var school = _schoolRepository.FirstOrDefault();

                return school;
            }
            catch (Exception ex)
            {
                _log.Error("Error", ex);
                return null;
            }
        }
      
        /// <summary>
        /// Used to setup school on first run of the application
        /// </summary>
        /// <param name="school">An instance of school class</param>
        /// <returns>School Id</returns>
        public string SchoolSetup(School school)
        {
            try
            {
                _schoolRepository.Add(school);

                _auditTrailRepository.Log($"School {school.Name} Created", AuditActionEnum.Created);
                _log.Info("School Created");
                return school.Id;
            }
            catch (Exception ex)
            {
                _log.Error("Error", ex);
                return null;
            }
        }

        public bool Create(School model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update school details
        /// </summary>
        /// <param name="model">An instance of school class</param>
        /// <returns>true if success else false</returns>
        public bool Edit(School model)
        {
            try
            {
                _schoolRepository.Update(model);

                _auditTrailRepository.Log($"School {model.Name} Edited", AuditActionEnum.Updated);
                _log.Info("School Edited");
                return true;
            }
            catch (Exception ex)
            {
                _log.Error("Error", ex);
                return false;
            }
        }

        /// <summary>
        /// Delete the school setup
        /// </summary>
        /// <param name="id">school id</param>
        /// <returns>true if success else false</returns>
        public bool Delete(string id)
        {
            try
            {
                _schoolRepository.Delete(id);
                _log.Info("School Deleted");
                return true;
            }
            catch (Exception ex)
            {
                _log.Error("Error", ex);
                return false;
            }
        }

    }
}
