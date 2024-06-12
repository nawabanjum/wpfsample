using DataIntelligenceWpfApp.Services;
using GovernanceLibrary.DTOs;
using GovernanceLibrary.Enums;
using GovernanceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntelligenceWpfApp.Models
{
    public class ManagementInformation // https://js-ig.atlassian.net/browse/SAV-414
    {
        private JobOverviewDTO? _oJobOverview;
        private ObservableCollection<JobsDueDTO> _oJobsDue;

        public JobOverviewDTO? JobOverview
        {
            get { return _oJobOverview; }
            set { _oJobOverview = value; }
        }

        public ObservableCollection<JobsDueDTO> JobsDue
        {
            get { return _oJobsDue; }
            set { _oJobsDue = value; }
        }

        private int _iCompanyID;

        public int CompanyID
        {
            get { return _iCompanyID; }
            set { _iCompanyID = value; }
        }

        private int _iComplianceUseCaseID;

        public int ComplianceUseCaseID
        {
            get { return _iComplianceUseCaseID; }
            set { _iComplianceUseCaseID = value; }
        }

        private bool _bIncludeDataControllers;

        public bool IncludeDataControllers
        {
            get { return _bIncludeDataControllers; }
            set { _bIncludeDataControllers = value; }
        }

        private DataService _oDataService;
        public DataService DataService { get { return _oDataService; } set { _oDataService = value; } }

        public ManagementInformation(DataService oDataService)
        {
            _oDataService = oDataService;
            ComplianceUseCaseID = -1;
            CompanyID = -1; // default to JSIG
            IncludeDataControllers = true;
            JobsDue = new ObservableCollection<JobsDueDTO>();
            JobOverview = new JobOverviewDTO();
        }

        public ManagementInformation(
            DataService oDataService,
            int iCompanyID,
            int iComplianceUseCaseID = (int)GovernanceLibrary.Enums.ComplianceUseCase.GDPRDSAR,
            bool bIncludeDataControllers = false)
        {
            _oDataService = oDataService; // ensures we can call the data service
            // Ensures that the MI class will return data for the correct company and Use Case
            ComplianceUseCaseID = iComplianceUseCaseID;
            CompanyID = iCompanyID;
            IncludeDataControllers = bIncludeDataControllers; // if set this will return data for the company as well as their data controllers
            JobsDue = new ObservableCollection<JobsDueDTO>();
            JobOverview = new JobOverviewDTO();
        }


        public bool LoadDataJobOverView()
        {
            bool bLoaded = false;
            try
            {

            }
            catch (Exception ex)
            {
                // TODO Audit
            }
            return bLoaded;
        }

    }
}
