
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GovernanceLibrary.Enums;
using GovernanceLibrary.DTOs;
using GovernanceLibrary.Models;

namespace GovernanceLibrary.Database
{
    public class DbOperations
    {
        public async Task<Dictionary<string, Dictionary<DSARStatus, int>>> GetDSARStatusCounts()
        {
            var mockData = new Dictionary<string, Dictionary<DSARStatus, int>>
            {
                { "JSIG", new Dictionary<DSARStatus, int>
                    {
                        { DSARStatus.DSARCompleted, 5 },
                        { DSARStatus.NewDSAR, 10 }
                    }
                },
                { "Tesla", new Dictionary<DSARStatus, int>
                    {
                        { DSARStatus.DSARCompleted, 3 },
                        { DSARStatus.NewDSAR, 7 }
                    }
                }
            };

            return await Task.FromResult(mockData);
        }

        public async Task<int> GetTotalDSARsCountForAllCompaniesAsync()
        {
            return await Task.FromResult(25);
        }

        public async Task<JobOverviewDTO?> GetMI_JobOverview(int iCompanyID, int iComplianceUseCaseID, bool bIncludeDataControllers, int iUserID)
        {
            return await Task.FromResult(new JobOverviewDTO
            {
                LiveJobs = 5,
                NotStarted = 3,
                ForReview = 2,
                InProgress = 7
            });
        }

        public async Task<ObservableCollection<JobsDueDTO>> GetMI_JobsDueIn(int iCompanyID, int iComplianceUseCaseID, bool bIncludeDataControllers, int iUserID, int iDaysDue = 7)
        {
            var jobsDue = new ObservableCollection<JobsDueDTO>
            {
                new JobsDueDTO { ClientJobBatchID = 1, JobName = "M_Povey", DaysLeft = 5, StatusID = 1, RequestDate=DateTime.Now, JobStatus = "New DSAR" },
                new JobsDueDTO { ClientJobBatchID = 2, JobName = "S_Curwen", DaysLeft = 2, StatusID = 2, RequestDate=DateTime.Now, JobStatus = "Ready for DPO Review" }
            };
            return await Task.FromResult(jobsDue);
        }

        public async Task<JobBatchSpecification> GetJobBatchSpecificationByClientJobBatchID(int clientJobBatchId)
        {
            var spec = new JobBatchSpecification
            {
                ClientJobBatchId = clientJobBatchId,
                DataSubjectName = "M_Povey",
                RequestDate = DateTime.Now
            };
            return await Task.FromResult(spec);
        }

        public async Task<bool> Licence_IsRegistrationActive(int iPersonID)
        {
            // Return true for the sake of this stub.
            return await Task.FromResult(true);
        }

        public async Task Heartbeat_LastLogin(int iPersonID, string? strListenerRevision, bool bUpdateDashboardDT = false, bool bUpdateDSARWizardDT = false, bool bUpdateDSARWorkbenchDT = false, bool bUpdateDSARReviewDT = false)
        {
            // Stubbed implementation; just complete the task.
            await Task.CompletedTask;
        }
    }
}
