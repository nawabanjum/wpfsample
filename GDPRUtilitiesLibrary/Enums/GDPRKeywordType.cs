using System.ComponentModel;

namespace GDPRUtilitiesLibrary.Enums
{
    using System.ComponentModel;

    [Flags] // Indicates that the enum is intended to be used as a bit field
    public enum GDPRKeywordType
    {
        [Description("Not Set")]
        None = 0,
        [Description("PII Full Name")]
        PII_Name = 1 << 0,
        [Description("PII Postal Address")]
        PII_Address = 1 << 1,
        [Description("PII Email Address")]
        PII_Email = 1 << 2,
        [Description("PII Social Security Number")]
        PII_SSN = 1 << 3,
        [Description("PII Passport Information")]
        PII_Passport = 1 << 4,
        [Description("PII Drivers Licence Details")]
        PII_DriversLicence = 1 << 5,
        [Description("PII Credit Card Details")]
        PII_CreditCard = 1 << 6,
        [Description("PII Date of Birth Information")]
        PII_DOB = 1 << 7,
        [Description("PII Telephone Information")]
        PII_Telephone = 1 << 8,
        [Description("PII Login Details")]
        PII_Login = 1 << 9,
        [Description("PII Bank Details - AC No")]
        PII_BankDetails_Account_Number = 1 << 10,
        [Description("PII Bank Details - Sort Code")]
        PII_BankDetails_SortCode = 1 << 11,
        [Description("PII Bank Details - Monetary Amount")]
        PII_BankDetails_MonetaryAmount = 1 << 12,
        // Special Categories
        [Description("SC Racial Origin")]
        SPECCAT_RacialOrigin = 1 << 13,
        [Description("SC Biometric Data")]
        SPECCAT_BiometricData = 1 << 14,
        [Description("SC Ethnicity")]
        SPECCAT_Ethnicity = 1 << 15,
        [Description("SC Political Opinions")]
        SPECCAT_PoliticalOpinions = 1 << 16,
        [Description("SC Trade Union Membership")]
        SPECCAT_TradeUnionMembership = 1 << 17,
        [Description("SC Religious Beliefs")]
        SPECCAT_ReligiousBeliefs = 1 << 18,
        [Description("SC Philosophical Beliefs")]
        SPECCAT_PhilosophicalBeliefs = 1 << 19,
        [Description("SC Genetic Data")]
        SPECCAT_GeneticData = 1 << 20,
        [Description("SC Sexual Orientation")]
        SPECCAT_SexualOrientation = 1 << 21,
        [Description("SC Sex Life")]
        SPECCAT_SexLife = 1 << 22,
        [Description("SC Health Information")]
        SPECCAT_HealthInformation = 1 << 23,
        [Description("Data Subject AND Alias")]
        PII_DataSubject_AND_Alias = 1 << 24,
        [Description("Data Subject")]
        PII_DataSubject = 1 << 25,
        [Description("Data Subject Alias")]
        PII_DataSubject_Alias = 1 << 26,
        [Description("Domain-specific Keyword")]
        DomainSpecificKeyword = 1 << 27
    }

}