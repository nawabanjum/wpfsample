using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovernanceLibrary.Enums
{
    public enum DSARStatus // https://js-ig.atlassian.net/browse/SAV-416 updated descriptions
    {
        [Description("New DSAR")]
        NewDSAR = 1,                                                    //  1
        [Description("Copy Data to Server")]
        CopyDataToServer,                                               //  2
        [Description("Ready for Processing")]
        ReadyForProcessing,                                             //  3
        [Description("Discovery in Progress")]
        DiscoveryInProgress,                                            //  4
        [Description("Discovery Completed")]
        DiscoveryCompleted,                                             //  5
        [Description("Redaction in Progress")]
        RedactionInProgress,                                            //  6
        [Description("Redaction Completed")]
        RedactionCompleted,                                             //  7
        [Description("Ready for DPO Review")]
        ReadyForDPOReview,                                              //  8
        [Description("DPO Review in Progress")]
        DPOReviewInProgress,                                            //  9
        [Description("DPO Review Performed")]
        DPOReviewPerformed,                                             //  10
        [Description("DPO Approved")]
        DPOApproved,                                                    //  11
        [Description("Queued for Dissemination")]
        QueuedForDissemination,                                         //  12
        [Description("Sent to Data Subject")]
        SentToDataSubject,                                              //  13
        [Description("Data Retention Active")]
        DataRetentionActive,                                            //  14
        [Description("DSAR Completed")]
        DSARCompleted, // https://js-ig.atlassian.net/browse/SAV-404        15
        [Description("Out of Scope")]
        OutOfScope,                                                      // 16
        [Description("File Error")]
        FileError,                                                      // 17
        [Description("File Protected")]
        FileProtected,                                                      // 18
        [Description("Data Retention Period Expired")]
        DataRetentionPeriodExpired                                        // 19
    }


    public enum GovernanceProcess
    {
        NotStarted = 1,
        OriginalFileRead,                // We opened the file and read the contents so that Discovery and DSAR (optional) can be performed
        OriginalFileProcessedDiscovery,  // The file was processed for Discovery against internal PII Keywords (all use cases have this)
        OriginalFileProcessedDataSubject,// The file was processed for Data Subject details (DSAR only)
        OriginalFileInScope,             // The file is in-scope and the original has been copied to the Original Candidates Directory
                                         // In-scope means:
                                         // - DSAR - the Data Subject was found
                                         // - +Scope Criteria if specified was found
                                         // - Non-DSAR
                                         // - + Discovery = internal PII Keywords found, in-scope for Data Mapping
        OriginalFilePasswordProtected,   // The file is password protected so we can't determine scope, copied to Password Protected Directory
        OriginalFileInError,             // The file couldn't be opened, copied to Error Files directory
        CandidateFileProcessedRedactions,// The Candidate File has had redactions applied (original copied from candidates directory to processed directory)
        ProcessedFileDPOReviewed,        // A DPO has reviewed the processed file - copy from processed candidates directory to processed DPO reviewed directory (stays in this directory and is data_time stamped for version control)
        ProcessedFinalOutputApproved,    // Approval of last DPO reviewed file. Copied latest timestamped file to the Processed Final Output Directory
        DataMappingCandidates,           // Data Mapping Performed and all natural person details have been extracted e.g. Suneil Curwen would be a natural person, but Suneil would not as we can't uniquely say who that is, at this stage candidates are displayed in the UX
        DataMappingCandidatesSaved       // The candidates for data mapping have been persisted to the database 
    }

}
