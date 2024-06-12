using System;
using System.Collections.Generic;

namespace GovernanceLibrary.Models;

public partial class ClientJobBatch
{
    public int ClientJobBatchId { get; set; }

    public int? CompanyId { get; set; }

    public int? ComplianceUseCaseId { get; set; }

    public string? JobName { get; set; }

    public string? Status { get; set; }

    public DateTime? RequestDate { get; set; }

    public virtual ICollection<JobBatchSpecification> JobBatchSpecifications { get; } = new List<JobBatchSpecification>();

    public int StatusID { get; set; }
}
