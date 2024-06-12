using GovernanceLibrary.Email;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovernanceLibrary.DTOs
{
    public class ClientJobScheduleDetailsDTO
    {
        public DateTime? SpecificationRequestDate { get; set; }

        #region ClientJobBatch Table
        public int? cjb_PK { get; set; }

        public int ClientJobBatchID { get; set; }
        public string? JobName { get; set; }
        public DateTime? RequestDate { get; set; }
        public string JobStatus { get; set; }
        public int? ScheduleCompanyID { get; set; } // this populates the CompanyID field in the table

        #endregion

        #region JobBatchSpecification Table
        // includes Request Date
        // missing AccessToPersonalData, ErasureRequest, IsDataSubject and IsActingOnBehalf
        public int? jbs_PK { get; set; }
        public int? ScheduleID { get; set; }            // Also Tables: Schedule
        public string? DataSubjectName { get; set; }    // Also Tables: 
        public DateTime? DateOfBirth { get; set; }
        public string? PostalAddress { get; set; }      // Also Tables:
        public string? PhoneNumber { get; set; }
        public string? EmailAddress { get; set; }
        public string? EmailAddressAliases { get; set; }
        public string? DataSubjectAliases { get; set; }
        public string? PhoneNumberAliases { get; set; }
        public bool? ScopeCriteria { get; set; }
        public DateTime? CriteriaStartDate { get; set; }
        public DateTime? CriteriaEndDate { get; set; }
        public bool? SpecificKeywords { get; set; }
        public string? SpecificKeywordsString { get; set; }
        public bool? MinutesOfMeetings { get; set; }
        public bool? SupplierCorrespondence { get; set; }
        public bool? SpecificIndividuals { get; set; }
        public string? SpecificIndividualsString { get; set; }
        public bool? IsPassportSelected { get; set; }
        public bool? IsIdentityDocumentSelected { get; set; }
        public bool? IsDriversLicenceSelected { get; set; }
        public bool? IsSupportingDocumentsConfirmed { get; set; }
        public bool? IsOnlinePortalSelected { get; set; }
        public bool? IsSecureEmailSelected { get; set; }
        public bool? IsPostalMailSelected { get; set; }
        public string? AdditionalInformation { get; set; }
        public bool? IsProofOfAddressSelected { get; set; }
        #endregion

        #region Schedule Table
        // includes ScheduleID
        public int? RegistrationID { get; set; }
        public int? ProcessID { get; set; }
        public int? ScheduleOwnerID { get; set; }
        public DateTime? ScheduleStartDateTime { get; set; }
        public int? ScheduleRepeatsInterval { get; set; }
        public DateTime? ScheduleLastRunDateTime { get; set; }
        public DateTime? ScheduleNextRunDateTime { get; set; }
        public int? ScheduleActive { get; set; }
        public int? ScheduleDPOID { get; set; }
        #endregion

        #region ScheduleParameter Table
        // includes ScheduleID, ScheduleCompanyID (which is the ClientID for this table)
        public int? sp_PK { get; set; }
        public int? EmailSecurityMarker { get; set; }
        public int? SupportedFileType { get; set; }
        public byte? ResultsToLocalStore { get; set; }
        #endregion

        #region ScheduleParameterFileLocation Link Table
        // includes sp_PK which is the the ScheduleParameterID
        public int? FileLocationID { get; set; }
        #endregion

        #region FileLocation Table
        // includes FileLocationID
        public int? fl_PK { get; set; }
        public string? FileLocationToSearchPath { get; set; }
        public string? FileLocationToSearchFilename { get; set; }
        public int? SubdirectorySearch { get; set; }
        #endregion

        #region ScheduleResult Table
        // includes ScheduleID
        public int? sr_PK { get; set; }
        public int? ScheduleResultID { get; set; }
        public int? ResultTypeID { get; set; }
        public int? ScheduleResultHeaderID { get; set; }
        public int? ScheduleResultReviewedByDPO { get; set; }
        public int? ScheduleResultReviewedDPOID { get; set; }
        public int? ScheduleResultArchived { get; set; }
        public string? ScheduleResultArchiveFile { get; set; }
        #endregion

        #region ScheduleResultHeader Table
        // includes ScheduleResultHeaderID, 
        public int? srh_PK { get; set; }
        public int? ResultHeaderComplianceUseCaseID { get; set; } // maps to ComplianceUseCaseID
        public long TotalFound { get; set; }
        public long? TotalUnique { get; set; }
        public long? AddressTotalCount { get; set; }
        public long? AddressUniqueCount { get; set; }
        public long? NameTotalCount { get; set; }
        public long? NameUniqueCount { get; set; }
        public long? EmailTotalCount { get; set; }
        public long? EmailUniqueCount { get; set; }
        public long? TelephoneTotalCount { get; set; }
        public long? TelephoneUniqueCount { get; set; }
        public long? DOBTotalCount { get; set; }
        public long? DOBUniqueCount { get; set; }
        public long? NatInsuranceTotalCount { get; set; }
        public long? NatInsuranceUniqueCount { get; set; }
        public long? PassportTotalCount { get; set; }
        public long? PassportUniqueCount { get; set; }
        public long? DriversLicenceTotalCount { get; set; }
        public long? DriversLicenceUniqueCount { get; set; }
        public long? BankAccountNumberTotalCount { get; set; }
        public long? BankAccountNumberUniqueCount { get; set; }
        public long? BankAccountSortCodeTotalCount { get; set; }
        public long? BankAccountSortCodeUniqueCount { get; set; }
        public long? CreditCardNumberTotalCount { get; set; }
        public long? CreditCardNumberUniqueCount { get; set; }
        public long? MonetaryAmountTotalCount { get; set; }
        public long? MonetaryAmountUniqueCount { get; set; }
        public long? LoginDetailsTotalCount { get; set; }
        public long? LoginDetailsUniqueCount { get; set; }
        public long? SC_RacialOriginTotalCount { get; set; }
        public long? SC_RacialOriginUniqueCount { get; set; }
        public long? SC_BiometricDataTotalCount { get; set; }
        public long? SC_BiometricDataUniqueCount { get; set; }
        public long? SC_EthnicityTotalCount { get; set; }
        public long? SC_EthnicityUniqueCount { get; set; }
        public long? SC_PoliticalOpinionsTotalCount { get; set; }
        public long? SC_PoliticalOpinionsUniqueCount { get; set; }
        public long? SC_TradeUnionMembershipTotalCount { get; set; }
        public long? SC_TradeUnionMembershipUniqueCount { get; set; }
        public long? SC_ReligiousBeliefsTotalCount { get; set; }
        public long? SC_ReligiousBeliefsUniqueCount { get; set; }
        public long? SC_PhilosophicalBeliefsTotalCount { get; set; }
        public long? SC_PhilosophicalBeliefsUniqueCount { get; set; }
        public long? SC_GeneticDataTotalCount { get; set; }
        public long? SC_GeneticDataUniqueCount { get; set; }
        public long? SC_SexualOrientationTotalCount { get; set; }
        public long? SC_SexualOrientationUniqueCount { get; set; }
        public long? SC_SexLifeTotalCount { get; set; }
        public long? SC_SexLifeUniqueCount { get; set; }
        public long? SC_HealthInformationTotalCount { get; set; }
        public long? SC_HealthInformationUniqueCount { get; set; }
        #endregion


        #region ScheduleResultDetail Table
        // includes ComplianceUseCaseID (maps as ResultHeaderComplianceUseCaseID)
        public int? srd_PK { get; set; }
        public int? DetailHeaderID { get; set; }  // 
        public int? StatusID { get; set; }        // maps to enum FileStatusEnum
        public string? FileName { get; set; }
        public int? FileTypeID { get; set; }
        public string? FileDirectory { get; set; }
        public int? ContainsPII { get; set; }
        public int? ContainsSC { get; set; }
        public int? ContainsCompanyKeyword { get; set; }
        public int? ContainsOffensiveLanguage { get; set; }
        public DateTime? FileCreationDate { get; set; }
        public DateTime? FileLastUpdatedDate { get; set; }
        public int? AgeOfFile { get; set; }
        public int? AgeOfFileMonths { get; set; }
        public int? ActionTypeID { get; set; }
        public string? RecoveryFileDetails { get; set; }
        public DateTime? ActionDate { get; set; }
        public string? FileTypeDescription { get; set; }
        public string? StatusName { get; set; }
        public string? StatusDescription { get; set; }
        public string? ActionTypeName { get; set; }
        public string? ActionTypeDescription { get; set; }
        public string? FileNameClearText { get; set; }         // used to determine the redacted text was i.e. line 123, word 15 equals "Adam"
        public string? FileNameRedactedText { get; set; }     // used to enable review and if DSAR back to DS. Also inconjunction with ClearText we can understand the orignal word
        #endregion


        #region REVIEW ITEMS found for this file https://js-ig.atlassian.net/browse/SAV-404
        public ObservableCollection<DiscoveryReviewItemDTO> _reviewItems;
        #endregion

        #region EMAILS found for this file https://js-ig.atlassian.net/browse/SAV-404
        public List<EmailDetails> _emailsFound;
        #endregion


        #region Text-based Items
        public string[] _oFileContentsText; // relevant to text files processed
        public int _iTextLinesRead;
        public int _iTextLinesProcessed;
        #endregion


        /* start File Item fields */
        //    e.g <R_123_15> store this in a dictionary
        // TODO recovery drive








        /* end of File Item fields */


        // Primary keys
        public int? js_PK { get; set; } // ??




    }

}
