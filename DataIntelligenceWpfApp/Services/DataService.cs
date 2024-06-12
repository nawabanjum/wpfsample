using GovernanceLibrary.DTOs;
using GovernanceLibrary.Enums;
using GovernanceLibrary.Models;
using GovernanceLibrary.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntelligenceWpfApp.Services
{
    public class DataService
    {
        private readonly DbOperations _dbOperations;

        public DataService()
        {
            _dbOperations = new DbOperations(); // Use the stub for development
        }

        public async Task<Dictionary<string, Dictionary<DSARStatus, int>>> GetDSARStatusCountsAsync()
        {
            return await _dbOperations.GetDSARStatusCounts();
        }

        public async Task<int> GetTotalDSARsCountForAllCompaniesAsync()
        {
            return await _dbOperations.GetTotalDSARsCountForAllCompaniesAsync();
        }

        public async Task<JobOverviewDTO?> GetMI_JobOverview(int iCompanyID, int iComplianceUseCaseID, bool bIncludeDataControllers, int iUserID)
        {
            return await _dbOperations.GetMI_JobOverview(iCompanyID, iComplianceUseCaseID, bIncludeDataControllers, iUserID);
        }

        public async Task<ObservableCollection<JobsDueDTO>> GetMI_JobsDueIn(int iCompanyID, int iComplianceUseCaseID, bool bIncludeDataControllers, int iUserID, int iDaysDue = 7)
        {
            return await _dbOperations.GetMI_JobsDueIn(iCompanyID, iComplianceUseCaseID, bIncludeDataControllers, iUserID, iDaysDue);
        }

        public async Task<JobBatchSpecification> GetJobBatchSpecificationByClientJobBatchIDAsync(int clientJobBatchId)
        {
            return await _dbOperations.GetJobBatchSpecificationByClientJobBatchID(clientJobBatchId);
        }

        public async Task<bool> Licence_IsRegistrationActive(int iPersonID)
        {
            return await _dbOperations.Licence_IsRegistrationActive(iPersonID);
        }

        public async Task Heartbeat_LastLogin(int iPersonID, string? strListenerRevision, bool bUpdateDashboardDT = false, bool bUpdateDSARWizardDT = false, bool bUpdateDSARWorkbenchDT = false, bool bUpdateDSARReviewDT = false)
        {
            await _dbOperations.Heartbeat_LastLogin(iPersonID, strListenerRevision, bUpdateDashboardDT, bUpdateDSARWizardDT, bUpdateDSARWorkbenchDT, bUpdateDSARReviewDT);
        }

    }
}
