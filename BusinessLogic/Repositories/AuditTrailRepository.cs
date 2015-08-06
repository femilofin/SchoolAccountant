#region

using System;
using System.Linq;
using BusinessLogic.Constants;
using BusinessLogic.Entities;
using BusinessLogic.Interface;
using log4net;
using log4net.Config;
using MongoRepository;

#endregion

namespace BusinessLogic.Repositories
{
    public class AuditTrailRepository : IAuditTrailRepository
    {
        private readonly MongoRepository<AuditTrail> _auditTrailRepository = new MongoRepository<AuditTrail>();
        private readonly ILog _log = LogManager.GetLogger("BusinessLogic.AuditTrailRepository.cs");

        public AuditTrailRepository()
        {
            XmlConfigurator.Configure();
        }

        /// <summary>
        /// Add a log to the database
        /// </summary>
        /// <param name="detail">The detail of the action</param>
        /// <param name="actionEnum">The type of action</param>
        public AuditTrail Log(string detail, AuditActionEnum actionEnum)
        {
            try
            {
                var audit = new AuditTrail
                {
                    Details = $"{Enum.GetName(typeof (AuditActionEnum), actionEnum)}: {detail}",
                    TimeStamp = DateTime.Now,
                    AuditAction = actionEnum
                };

                var auditTrail = _auditTrailRepository.Add(audit);

                _log.Info("Audit trail created");

                return auditTrail;
            }
            catch (Exception ex)
            {
                _log.Error("Others", ex);

                return null;
            }
        }

        public bool DeleteLog(string id)
        {
            try
            {
                var auditTrail = _auditTrailRepository.GetById(id);
                _auditTrailRepository.Delete(auditTrail);
                return true;
            }
            catch (Exception ex)
            {
                _log.Error("Others", ex);

                return false;
            }
        }

        public bool DeleteTestLog(string log)
        {
            try
            {
                var auditTrail = _auditTrailRepository.Where(x => x.Details == log).ToList();

                auditTrail.ForEach(x => _auditTrailRepository.Delete(x));

                return true;
            }
            catch (Exception ex)
            {
                _log.Error("Others", ex);

                return false;
            }
        }
    }
}