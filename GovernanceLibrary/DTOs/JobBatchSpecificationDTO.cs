using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovernanceLibrary.DTOs
{
    public class JobBatchSpecificationDTO
    {
        //public int JobBatchSpecificationID { get; set; }
        public int? ScheduleID { get; set; }
        public int? ClientJobBatchID { get; set; }
        public bool? IsDataSubject { get; set; }
        public bool? IsActingOnBehalf { get; set; }
        public string DataSubjectName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PostalAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string EmailAddressAliases { get; set; }
        public string DataSubjectAliases { get; set; }
        public string PhoneNumberAliases { get; set; }
        public bool? AccessToPersonalData { get; set; }
        public bool? ErasureRequest { get; set; }
        public DateTime? RequestDate { get; set; }
        public bool? ScopeCriteria { get; set; }
        public DateTime? CriteriaStartDate { get; set; }
        public DateTime? CriteriaEndDate { get; set; }
        public bool? SpecificKeywords { get; set; }
        public string SpecificKeywordsString { get; set; }
        public bool? MinutesOfMeetings { get; set; }
        public bool? SupplierCorrespondence { get; set; }
        public bool? SpecificIndividuals { get; set; }
        public string SpecificIndividualsString { get; set; }
        public bool? IsPassportSelected { get; set; }
        public bool? IsIdentityDocumentSelected { get; set; }
        public bool? IsDriversLicenceSelected { get; set; }
        public bool? IsSupportingDocumentsConfirmed { get; set; }
        public bool? IsOnlinePortalSelected { get; set; }
        public bool? IsSecureEmailSelected { get; set; }
        public bool? IsPostalMailSelected { get; set; }
        public string AdditionalInformation { get; set; }
        public bool? IsProofOfAddressSelected { get; set; }
    }
}
