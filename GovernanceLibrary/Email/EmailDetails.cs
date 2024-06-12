using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovernanceLibrary.Email
{
    public class EmailDetails
    {
        public string Sender { get; set; }
        public List<string> To { get; set; }
        public List<string> CC { get; set; }
        public List<string> BCC { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string BodyALT { get; set; }

        public int Index { get; set; }

        public EmailDetails()
        {
            Index = 0;
            Sender = "";
            Subject = "";
            Body = "";
            BodyALT = "";
            To = new List<string>();
            CC = new List<string>();
            BCC = new List<string>();
        }

        // Cloning constructor
        public EmailDetails(EmailDetails other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other), "Cannot clone a null EmailDetails.");
            }

            // Copying all properties
            this.Index = other.Index;
            this.Sender = other.Sender;
            this.Subject = other.Subject;
            this.Body = other.Body;
            this.To = other.To;
            this.CC = other.CC;
            this.BCC = other.BCC;
            this.BodyALT = other.BodyALT;

            // Assuming all properties have been included
            // Add here any other properties that need to be cloned
        }



        // Method to check if a PII candidate is present in any element of the email
        public bool ContainsPIICandidate(string candidate)
        {
            // not req'd for stub - here for context
            //// Check if the candidate is present in any of the email's elements
            //// You can use string.Contains, Regex, or any other appropriate method
            //// For example:

            //if ((BodyALT != null && (HTMLHelper.ExtractTextFromHtml(BodyALT)).Contains(candidate)) ||
            //    (Body != null && Body.Contains(candidate)) ||
            //    (Subject != null && Subject.Contains(candidate)) ||
            //    (Sender != null && Sender.Contains(candidate)) ||
            //    To.Any(recipient => recipient.Contains(candidate)) ||
            //    CC.Any(recipient => recipient.Contains(candidate)) ||
            //    BCC.Any(recipient => recipient.Contains(candidate)))
            //{
            //    return true;
            //}

            return false;
        }
    }

}
