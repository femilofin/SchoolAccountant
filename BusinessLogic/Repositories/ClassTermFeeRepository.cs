using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Constants;
using BusinessLogic.Entities;
using BusinessLogic.Interface;
using log4net;
using log4net.Config;
using MongoDB.Driver;
using MongoRepository;
using BusinessLogic.Utility;

namespace BusinessLogic.Repositories
{
    /// <summary>
    /// The class for adding the term fee items for each class
    /// </summary>
    public class ClassTermFeeRepository : IClassTermFeeRepository
    {
        private readonly MongoRepository<ClassTermFee> _classTermFees = new MongoRepository<ClassTermFee>();
        private readonly ILog _log = LogManager.GetLogger("BusinessLogic.ClassTermFeeRepository.cs");
        readonly IAuditTrailRepository _auditTrailRepository = new AuditTrailRepository();

        public ClassTermFeeRepository()
        {
            XmlConfigurator.Configure();
        }

        public List<ClassTermFee> GetActiveFees()
        {
            try
            {
                return _classTermFees.Where(x => x.Active).ToList();
            }
            catch (MongoConnectionException ex)
            {
                _log.Error("Mongodb", ex);
                return null;
            }
            catch (Exception ex)
            {
                _log.Error("Others", ex);
                return null;
            }
        }

        public ActivatedAndDeactivatedId AddClassTermFees(List<ClassTermFee> classTermFees, string username)
        {
            var activatedAndDeactivatedId = new ActivatedAndDeactivatedId();

            try
            {
                //If fee already exist, Get all active fees, disable and set end date

                var activeFees = GetActiveFees();

                if (activeFees != null)
                {
                    var deactivatedIds = new List<string>();

                    foreach (var fee in activeFees)
                    {
                        fee.Active = false;
                        fee.EndDate = DateTime.Now;

                        var deactivatedId = _classTermFees.Update(fee).Id;

                        deactivatedIds.Add(deactivatedId);
                    }

                    activatedAndDeactivatedId.DeActivatedIds = deactivatedIds;
                }
                else
                {
                    activatedAndDeactivatedId.DeActivatedIds = null;
                }

                // Add fees and return ids
                var ids = classTermFees.Select(x => _classTermFees.Add(x).Id).ToList();

                activatedAndDeactivatedId.ActivatedIds = ids;

                _auditTrailRepository.Log($"School fees created by {username}", AuditActionEnum.Created);

                _log.Info("Fees added");

                return activatedAndDeactivatedId;
            }
            catch (MongoConnectionException ex)
            {
                _log.Error("Mongodb", ex);
                return null;
            }
            catch (Exception ex)
            {
                _log.Error("Others", ex);
                return null;
            }

        }

        public bool DeleteClassTermFees(ActivatedAndDeactivatedId activatedAndDeactivatedId, string username)
        {
            try
            {
                // Reactivate the formally deactivated fees

                foreach (var id in activatedAndDeactivatedId.DeActivatedIds)
                {
                    var fee = _classTermFees.GetById(id);

                    fee.Active = true;
                    fee.EndDate = null;
                }

                _auditTrailRepository.Log($"School fees reactivated by {username}", AuditActionEnum.Created);

                _log.Info("Fees reactivated");


                // Delete the newly added fee

                foreach (var id in activatedAndDeactivatedId.ActivatedIds)
                {
                    _classTermFees.Delete(id);

                    _auditTrailRepository.Log($"School fees deleted by {username}", AuditActionEnum.Deleted);

                    _log.Info("Fees deleted");

                }

                // True if delete is successful

                return true;
            }
            catch (MongoConnectionException ex)
            {
                _log.Error("Mongodb", ex);
                return false;
            }
            catch (Exception ex)
            {
                _log.Error("Others", ex);
                return false;
            }
        }


    }
}
