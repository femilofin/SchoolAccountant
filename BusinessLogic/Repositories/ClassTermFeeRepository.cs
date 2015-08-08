using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Constants;
using BusinessLogic.Entities;
using BusinessLogic.Interface;
using BusinessLogic.Utility;
using log4net;
using log4net.Config;
using MongoRepository;

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

        public void Example()
        {
            throw new Exception();
        }

        /// <summary>
        /// Gets the currently activated fees
        /// </summary>
        /// <returns>A list of the fees (i.e jss - sss)</returns>
        public List<ClassTermFee> GetCurrentFees()
        {
            try
            {
                var currentFees = _classTermFees.Where(x => x.Active).ToList();

                return currentFees.Any() ? currentFees : new List<ClassTermFee>();
            }
            catch (Exception ex)
            {
                _log.Error("Error", ex);
                return null;
            }
        }

        /// <summary>
        /// Adds and activates new set of fees
        /// </summary>
        /// <param name="classTermFees">A list of fees (i.e jss - sss)</param>
        /// <param name="username">The user performing this action, for audit trail.</param>
        /// <returns>A list of ids of the newly added fees and the ones deactivated </returns>
        public ActivatedAndDeactivatedId AddClassTermFees(IList<ClassTermFee> classTermFees, string username)
        {

            var currentFees = GetCurrentFees();

            var deActivatedIds = DeactivateFeesAndGetIds(currentFees);

            // Add fees and return ids
            try
            {
                var activatedIds = classTermFees.Select(x => _classTermFees.Add(x).Id).ToList();

                var activatedAndDeactivatedId = new ActivatedAndDeactivatedId
                {
                    DeActivatedIds = deActivatedIds,
                    ActivatedIds = activatedIds
                };


                _auditTrailRepository.Log($"School fees created by {username}", AuditActionEnum.Created);

                _log.Info("Fees added");

                return activatedAndDeactivatedId;

            }
            catch (Exception ex)
            {
                _log.Error("Error", ex);
                return null;
            }
        }

        /// <summary>
        /// Used to deactivates the fees and return their ids
        /// </summary>
        /// <param name="currentFees">A list of the current fees to deactivate.</param>
        /// <returns>A list of ids for the deactivated fees</returns>
        private List<string> DeactivateFeesAndGetIds(List<ClassTermFee> currentFees)
        {
            if (!currentFees.Any()) return new List<string>();

            var deactivatedIds = new List<string>();

            try
            {
                foreach (var fee in currentFees)
                {
                    fee.Active = false;
                    fee.EndDate = DateTime.Now;

                    var deactivatedId = _classTermFees.Update(fee).Id;

                    deactivatedIds.Add(deactivatedId);
                }

                return deactivatedIds;

            }
            catch (Exception ex)
            {
                _log.Error("Error", ex);
                return null;
            }

        }

        /// <summary>
        /// Deletes the current fees and activate the last deactivated fees
        /// </summary>
        /// <param name="activatedAndDeactivatedId">A list containing the current fee ids and previous deactivated fee ids</param>
        /// <param name="username">The user performing this action, for audit trail.</param>
        /// <returns>True if success, else false</returns>
        public bool DeleteCurrentFeesAndActivatePreviousFees(ActivatedAndDeactivatedId activatedAndDeactivatedId, string username)
        {
            try
            {
                // Reactivate the formally deactivated fees

                var success = ReactivatePreviousFees(activatedAndDeactivatedId.DeActivatedIds, username);

                if (!success)
                {
                    return false;
                }

                // Delete the newly added fees

                foreach (var id in activatedAndDeactivatedId.ActivatedIds)
                {
                    _classTermFees.Delete(id);

                    _auditTrailRepository.Log($"School fees deleted by {username}", AuditActionEnum.Deleted);

                    _log.Info("Fees deleted");
                }

                // True if delete is successful

                return true;
            }
            catch (Exception ex)
            {
                _log.Error("Error", ex);
                return false;
            }
        }

        /// <summary>
        /// Reactivates the previous deactivated fee
        /// </summary>
        /// <param name="deActivatedIds">A list of ids for the deactivated fees</param>
        /// <param name="username">The user performing this action, for audit trail.</param>
        /// <returns>True if success else false</returns>
        private bool ReactivatePreviousFees(IEnumerable<string> deActivatedIds, string username)
        {
            try
            {
                foreach (var fee in deActivatedIds.Select(id => _classTermFees.GetById(id)))
                {
                    fee.Active = true;
                    fee.EndDate = null;

                    _classTermFees.Update(fee);
                }

                _auditTrailRepository.Log($"School fees reactivated by {username}", AuditActionEnum.Created);

                _log.Info("Fees reactivated");

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
