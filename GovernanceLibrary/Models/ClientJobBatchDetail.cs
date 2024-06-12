using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace GovernanceLibrary.Models
{
    public class ClientJobBatchDetail
    {
        public int ClientJobBatchID { get; set; }
        public string? DataSubjectName { get; set; }
        public DateTime RequestDate { get; set; }
        public int DaysLeft { get; set; }
        public double? OverallProgress { get; set; }
        public int? FilesReviewedCount { get; set; }
        public int? FilesToReviewCount { get; set; }
        public int? StatusID {get; set; } // https://js-ig.atlassian.net/browse/SAV-416
        public string StatusName { get; set; }
        public int CompanyID { get; set; }
        public string JobName { get; set; }
    }
}
