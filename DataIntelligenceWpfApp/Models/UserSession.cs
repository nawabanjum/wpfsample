using DataIntelligenceWpfApp.Services;
using GovernanceLibrary.DTOs;
using GovernanceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntelligenceWpfApp.Models
{
    /// <summary>
    /// 20/6/2023
    /// User Sessio to store session data that is needed across
    /// all views and view models
    /// 
    /// satisfies: https://js-ig.atlassian.net/browse/SAV-292
    /// 
    /// </summary>
    public class UserSession
    {
        public string SessionFileName { get; set; } // https://js-ig.atlassian.net/browse/SAV-404
        public void SetUserSessionFilename(int iClientJobBatchID)
        {

            try
            {
                string cwd = UserDataDirectory; //Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DataIntelligenceWpfApp");//System.IO.Directory.GetCurrentDirectory();
                string strTickerToUse = CompanyTickerCode;
                if (!String.IsNullOrEmpty(DataController))
                    strTickerToUse = DataControllerTickerCode;

                string directoryPath = Path.Combine(cwd, "Clients", strTickerToUse, "Users", PersonID.ToString());
                // Ensure that the directory exists
                System.IO.Directory.CreateDirectory(directoryPath);

                // Construct the file name
                SessionFileName = Path.Combine(directoryPath, $"{PersonID}_UserSession_{iClientJobBatchID}.json");

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DoesSessionFileExist()
        {
            if (string.IsNullOrEmpty(SessionFileName))
            {
                throw new InvalidOperationException("Session file name has not been set.");
            }

            return System.IO.File.Exists(SessionFileName);
        }
        public DataService DataService { get { return _oDataService; } }

        private DataService _oDataService = null;

        public UserSession(DataService oDataService)
        {
            this.PersonSalutation = "";
            this.PersonFirstname = "";
            this.PersonSurname = "";
            this.PersonEmail = "";
            this.PersonCompanyPhoneNumber = "";
            this.PersonCompanyEmail = "";
            this.RoleDescription = "";
            this.DepartmentName = "";
            this.CompanyName = "";
            this.CompanyDescription = "";
            this.CompanyTickerCode = "";
            this.DataController = "";
            this.DataControllerTickerCode = "";
            this.CurrentSAVID = -1;
            this.LastJobBatchName = "";
            this.ClientJobBatchID = -1;
            this.ClientJobScheduleDetails = null;
            _oDataService = oDataService;
            this.ManagementInformation = new ManagementInformation(_oDataService);
        }

        public void Reset()
        {
            this.CurrentSAVID = -1;
            this.LastJobBatchName = "";
            this.ClientJobBatchID = -1;
            this.ClientJobScheduleDetails = null;
        }

        public int CurrentVersion { get; set; }
        public string UserDataDirectory { get; set; }

        /// <summary>
        /// DSAR Related session data
        /// </summary>
        public int CompanyID { get; set; }                      // Tables: ClientJobBatch
        public int RegistrationID { get; set; }                 // Tables: ScheduleParameter

        /*
        * User Session updates to store the progress for the current DSAR Review being performed
        * 
        * https://js-ig.atlassian.net/browse/SAV-404
        * 
        */
        public List<ClientJobScheduleDetailsDTO> ClientJobScheduleDetails { get; set; } // contains all the data that specifies the files relevant to the current DSAR being processed




        /// <summary>
        /// These fields are for who's logged on, company, department, licence etc...
        /// </summary>

        public int PersonID { get; set; }
        public int RoleID { get; set; }
        public int DepartmentID { get; set; }
        public int RoleTypeID { get; set; }
        public int DataControllerID { get; set; }
        public int CompanyComplianceAccessLevel { get; set; }
        public int CurrentSAVID { get; set; }
        public int ClientJobBatchID { get; set; } // set by the DSAR Wizard, used in workflow to DSARWorkbench


        public string PersonEmail { get; set; }
        public string PersonFirstname { get; set; }
        public string CompanyName { get; set; }
        public string PersonSalutation { get; set; }
        public string PersonSurname { get; set; }
        public string PersonCompanyPhoneNumber { get; set; }
        public string PersonCompanyEmail { get; set; }
        public string RoleDescription { get; set; }
        public string DepartmentName { get; set; }
        public string CompanyDescription { get; set; }
        public string CompanyTickerCode { get; set; }
        public string DataController { get; set; }
        public string DataControllerTickerCode { get; set; }
        public string LastJobBatchName { get; set; }
        public ClientJobBatchDetail ClientJobToReview { get; set; } // set by DSAR Workbench for use in the DSAR Review
        public bool ActiveRegistration { get; set; }


        /// <summary>
        /// System related session data
        /// </summary>

        private string _clientFileDirectory = "";
        private string _clientRedactionOutputDirectory = "";
        ///
        public string ClientFileDriveLetter { get; set; } = "E";
        public string SavannahInstallationDriveLetter { get; set; } = "E";
        public string AllNamesUTF8 { get; } = "";

        //#region REVIEW ITEMS found for this file https://js-ig.atlassian.net/browse/SAV-404
        //public ObservableCollection<DiscoveryReviewItemDTO> _reviewItems;
        //#endregion

        //#region EMAILS found for this file https://js-ig.atlassian.net/browse/SAV-404
        //public List<EmailDetails> _emailsFound;
        //#endregion


        public int ReviewItemsCounter { get; set; } // stores the counter that is used to generate a unique id for the redactions
        public int CurrentEmailIndex { get; set; } // stores the current index to emails in the EmailsFound container

        // Management Information
        public ManagementInformation ManagementInformation { get; set; }


    }
}
