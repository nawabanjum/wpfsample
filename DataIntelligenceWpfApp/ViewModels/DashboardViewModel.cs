using DataIntelligenceWpfApp.Models;
using DataIntelligenceWpfApp.Services;
using GovernanceLibrary.DTOs;
using GovernanceLibrary.Enums;
using GovernanceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DataIntelligenceWpfApp.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        public ICommand ViewJobCommand { get; set; }

        public ObservableCollection<JobsDueDTO> JobsDue
        {
            get
            {

                if (_userSession.ManagementInformation.JobsDue == null)
                {
                    _userSession.ManagementInformation.JobsDue = new ObservableCollection<JobsDueDTO>();
                    // Optionally, load data into JobsDue here if appropriate
                }
                return _userSession.ManagementInformation.JobsDue;

            }

            set
            {
                if (_userSession.ManagementInformation.JobsDue != null && _userSession.ManagementInformation.JobsDue != value) 
                {
                    _userSession.ManagementInformation.JobsDue = value;
                    OnPropertyChanged(nameof(JobsDue));
                }
            }
        }

        public int LiveJobs
        {
            get
            {
                if (_userSession.ManagementInformation is not null)
                    return _userSession.ManagementInformation.JobOverview.LiveJobs;

                return 0;
            }
            set
            {
                if (_userSession.ManagementInformation != null && _userSession.ManagementInformation.JobOverview.LiveJobs != value)
                {
                    _userSession.ManagementInformation.JobOverview.LiveJobs = value;
                    OnPropertyChanged(nameof(LiveJobs));
                }
            }
        }

        public int JobsNotStarted
        {
            get
            {
                if (_userSession.ManagementInformation is not null)
                    return _userSession.ManagementInformation.JobOverview.NotStarted;

                return 0;
            }
            set
            {
                if (_userSession.ManagementInformation != null && _userSession.ManagementInformation.JobOverview.NotStarted != value)
                {
                    _userSession.ManagementInformation.JobOverview.NotStarted = value;
                    OnPropertyChanged(nameof(JobsNotStarted));
                }
            }
        }

        public int JobsForReview
        {
            get
            {
                if (_userSession.ManagementInformation is not null)
                    return _userSession.ManagementInformation.JobOverview.ForReview;

                return 0;
            }
            set
            {
                if (_userSession.ManagementInformation != null && _userSession.ManagementInformation.JobOverview.ForReview != value)
                {
                    _userSession.ManagementInformation.JobOverview.ForReview= value;
                    OnPropertyChanged(nameof(JobsForReview));
                }
            }
        }

        public int JobsInProgress
        {
            get
            {
                if (_userSession.ManagementInformation is not null)
                    return _userSession.ManagementInformation.JobOverview.InProgress;

                return 0;
            }
            set
            {
                if (_userSession.ManagementInformation != null && _userSession.ManagementInformation.JobOverview.InProgress!= value)
                {
                    _userSession.ManagementInformation.JobOverview.InProgress = value;
                    OnPropertyChanged(nameof(JobsInProgress));
                }
            }
        }


        //private ObservableCollection<ChartItem> _totalDsars;
        //private ObservableCollection<ChartItem> _dsarsByStatus;
        private readonly UserSession _userSession; //https://js-ig.atlassian.net/browse/SAV-292
        
        // not req'd for stub - kept for context
        //public INavigationService NavigationService { get; }
        //private IDialogService _dialogService;  // https://js-ig.atlassian.net/browse/SAV-447 - use IDialogService

        public UserSession UserSession
        {
            get { return _userSession; }
        }

        private readonly DataService _dataService;
        
        // not req'd for stub - only for context
        //private TaskManager _taskManager = null;

        //public ObservableCollection<ChartItem> TotalDsars
        //{
        //    get { return _totalDsars; }
        //    set { SetProperty(ref _totalDsars, value); }
        //}

        //public ObservableCollection<ChartItem> DsarsByStatus
        //{
        //    get { return _dsarsByStatus; }
        //    set { SetProperty(ref _dsarsByStatus, value); }
        //}
        public ICommand LoadDataCommand { get; }
        public ICommand LoadLiveJobsCommand { get; }
        public ICommand LoadJobsNotStartedCommand { get; }
        public ICommand LoadJobsInProgressCommand { get; }
        public ICommand LoadJobsForReviewCommand { get; }


        public DashboardViewModel(
            UserSession userSession, 
            DataService dataService)

            /* Not required for Stub - provided for context
            //INavigationService navigationService,
            //IDialogService dialogService,
            //TaskManager taskManager)
            */
        {
            _userSession = userSession; //https://js-ig.atlassian.net/browse/SAV-292
            _dataService = dataService;
            // not req'd for stub - only for context
            //NavigationService = navigationService;
            //_dialogService = dialogService;
            //_taskManager = taskManager;

            LoadDataCommand = new RelayCommand(async obj => await LoadData());
            
            // 10-06-2024 these are for actually loading the data intot the details view on the dashboard - to be implemented
            LoadLiveJobsCommand = new RelayCommand(async obj => await LoadLiveJobs());
            LoadJobsNotStartedCommand = new RelayCommand(async obj => await LoadJobsNotStarted());
            LoadJobsInProgressCommand = new RelayCommand(async obj => await LoadJobsInProgress());
            LoadJobsForReviewCommand = new RelayCommand(async obj => await LoadJobsForReview());

            // not req'd for stub - only for context
            //ViewJobCommand = new RelayCommand(async obj => await ViewJob(obj));


            // 10-06-2024 simulate loading the data
            // Call LoadData to initialize data
            Task.Run(async () => await LoadData()).ConfigureAwait(false);
        }

        private async Task LoadLiveJobs()
        {
            // some biz logic


            await Task.CompletedTask;
        }
        private async Task LoadJobsNotStarted()
        {
            // some biz logic


            await Task.CompletedTask;
        }
        private async Task LoadJobsInProgress()
        {
            // some biz logic


            await Task.CompletedTask;
        }
        private async Task LoadJobsForReview()
        {
            // some biz logic


            await Task.CompletedTask;
        }

        // Not required for Stub - included for context

        //private async Task ViewJob(object job)
        //{
        //    if (job is JobsDueDTO oJobToView)
        //    {
        //        //// new code
        //        ///// Load specific job details using JobBatchSpecificationID
        //        JobBatchSpecification oJobBatchSpecificationToLoad = await _dataService.GetJobBatchSpecificationByClientJobBatchIDAsync(oJobToView.ClientJobBatchID);
        //        ClientJobBatchDetail jobBatchDetail = new ClientJobBatchDetail();
        //        jobBatchDetail.ClientJobBatchID = (int)oJobBatchSpecificationToLoad.ClientJobBatchId;
        //        jobBatchDetail.DataSubjectName = oJobBatchSpecificationToLoad.DataSubjectName;
        //        jobBatchDetail.RequestDate = (DateTime)oJobBatchSpecificationToLoad.RequestDate;

        //        _userSession.SetUserSessionFilename(oJobToView.ClientJobBatchID);
        //        _userSession.ClientJobToReview = jobBatchDetail;

        //        _userSession.ClientJobToReview.DaysLeft = oJobToView.DaysLeft;
        //        _userSession.ClientJobToReview.StatusID = oJobToView.StatusID;

        //        //// update the database so that it reflects this is the last client job batch file we were working on
        //        await _dataService.UpdatePersonSessionAsync(new GovernanceLibrary.DTOs.PersonSessionDTO { PersonID = _userSession.PersonID, LastClientJobBatchSessionFile = _userSession.SessionFileName });
        //        //// Load the batch session file for this id into the _userSession
        //        SessionManagementService oSMS = new SessionManagementService(_userSession.SessionFileName);
        //        bool bSessionDataPopulated = false;
        //        _userSession.ClientJobScheduleDetails?.Clear(); // clear down any previous details that might be saved, https://js-ig.atlassian.net/browse/SAV-434
        //        if (oSMS.LoadSessionFromSessionFile(_userSession))
        //        {
        //            // session updated - should have review and content loaded
        //            bSessionDataPopulated = true;
        //            //_userSession.ClientJobToReview = _selectedItem;

        //            await NavigationService.NavigateTo<DSARReviewViewModel>();

        //        }
        //        else
        //        {
        //            if (_userSession.ClientJobToReview != null)
        //            {
        //                await NavigationService.NavigateTo<DSARReviewViewModel>();
        //            }
        //        }

        //        await Task.CompletedTask;
        //    }
        //}

        /// <summary>
        /// Loads the Data for the Dashboard
        /// 
        /// Version History
        /// 
        /// 4-MAR-2024
        /// - https://js-ig.atlassian.net/browse/SAV-438 - Dashboard Overview by User ID
        /// 
        /// 5-MAR-2024  - // https://js-ig.atlassian.net/browse/SAV-448 - Licence Check
        /// 
        /// </summary>
        /// <returns></returns>
        private async Task LoadData()
        {
            await _dataService.Heartbeat_LastLogin(_userSession.PersonID, null, true);

            // Check if the licence is active
            if (await _dataService.Licence_IsRegistrationActive(_userSession.PersonID))
            {
                if (_userSession.ManagementInformation is null)
                    _userSession.ManagementInformation = new ManagementInformation(_dataService, _userSession.CompanyID, (int)GovernanceLibrary.Enums.ComplianceUseCase.GDPRDSAR, true);
                else
                {
                    if (_userSession.ManagementInformation.CompanyID == -1)
                    {
                        // uninitialised MI
                        _userSession.ManagementInformation.CompanyID = _userSession.CompanyID;
                        _userSession.ManagementInformation.ComplianceUseCaseID = (int)GovernanceLibrary.Enums.ComplianceUseCase.GDPRDSAR;
                        if (_userSession.ManagementInformation.DataService == null)
                            _userSession.ManagementInformation.DataService = _userSession.DataService;
                    }
                }
                _userSession.ManagementInformation.JobOverview = await _dataService.GetMI_JobOverview(_userSession.CompanyID, (int)GovernanceLibrary.Enums.ComplianceUseCase.GDPRDSAR, true, _userSession.PersonID); // all clients, for this ticker code
                _userSession.ManagementInformation.JobsDue = await _dataService.GetMI_JobsDueIn(_userSession.CompanyID, (int)GovernanceLibrary.Enums.ComplianceUseCase.GDPRDSAR, true, _userSession.PersonID, 7); // Get the jobs that are due in the next n days

                OnPropertyChanged(nameof(LiveJobs)); // Ensure this is called after data is loaded
                OnPropertyChanged(nameof(JobsInProgress)); // Ensure this is called after data is loaded
                OnPropertyChanged(nameof(JobsNotStarted)); // Ensure this is called after data is loaded
                OnPropertyChanged(nameof(JobsForReview)); // Ensure this is called after data is loaded
                OnPropertyChanged(nameof(JobsDue));

            }
            else
            {
                LiveJobs = 0;
                JobsInProgress = 0;
                JobsNotStarted = 0;
                JobsForReview = 0;
                JobsDue?.Clear();
                OnPropertyChanged(nameof(LiveJobs)); // Ensure this is called after data is loaded
                OnPropertyChanged(nameof(JobsInProgress)); // Ensure this is called after data is loaded
                OnPropertyChanged(nameof(JobsNotStarted)); // Ensure this is called after data is loaded
                OnPropertyChanged(nameof(JobsForReview)); // Ensure this is called after data is loaded
                OnPropertyChanged(nameof(JobsDue));

                // https://js-ig.atlassian.net/browse/SAV-448 - Licence Check
                
                // not req'd for stub, kept for context
                //_dialogService.ShowInformationMessage("Your licence is not active - please contact 'savannah@js-ig.com'","Licence Check");
                Application.Current.Shutdown();
            }
        }




    }
}
