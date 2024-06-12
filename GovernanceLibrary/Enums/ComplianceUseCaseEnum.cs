using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovernanceLibrary.Enums
{
    public enum ComplianceUseCase
    {
        GDPRGapAnalysis = 3,               // Gap Analysis for the UK GDPR
        ISO27001GapAnalysis = 4,           // Gap Analysis for UK ISO 27001
        GDPRDiscovery = 5,                 // Produce Exposure Report Risk Assessment against UK GDPR
        GDPRDSAR = 6                       // Data Subject Access Request - UK GDPR
    }
}
