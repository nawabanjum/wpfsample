using GDPRUtilitiesLibrary.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovernanceLibrary.DTOs
{
    public class DiscoveryReviewItemDTO : INotifyPropertyChanged
    {
        public DiscoveryReviewItemDTO()
        {
                
        }
        // Cloning constructor
        public DiscoveryReviewItemDTO(DiscoveryReviewItemDTO other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other), "Cannot clone a null DiscoveryReviewItemDTO.");
            }

            // Copying all properties
            this.PK = other.PK;
            this.UniqueId = other.UniqueId;
            this.Candidate = other.Candidate;
            this.Probability = other.Probability;
            this.CountDiscovered = other.CountDiscovered;
            this.CountRedacted = other.CountRedacted;
            this.GDPRKeywordType = other.GDPRKeywordType;
            this.ActionTypeName = other.ActionTypeName;
            this.StatusName = other.StatusName;

            // Assuming all properties have been included
            // Add here any other properties that need to be cloned
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int? _iPK;

        public int? PK
        {
            get { return _iPK; }
            set { _iPK = value; }
        }

        private string? _strUniqueId;
        public string? UniqueId
        {
            get { return _strUniqueId; }
            set { _strUniqueId = value; }
        }


        private string? _strCandidate;

        public string? Candidate
        {
            get { return _strCandidate; }
            set { _strCandidate = value; }
        }

        private double? _dProbability;

        public double? Probability
        {
            get { return _dProbability; }
            set { _dProbability = value; }
        }

        private long? _lCountDiscovered;

        public long? CountDiscovered
        {
            get { return _lCountDiscovered; }
            set
            {
                if (_lCountDiscovered != value)
                {
                    _lCountDiscovered = value;
                    OnPropertyChanged(nameof(CountDiscovered));
                }
            }
        }

        private long _lCountRedacted;

        public long CountRedacted
        {
            get { return _lCountRedacted; }
            set 
            { 
                _lCountRedacted = value;
                OnPropertyChanged(nameof(CountRedacted));
            }
        }


        // the type of gdpr PII_Name etc...
        private GDPRKeywordType _oGDPRKeywordType;

        public GDPRKeywordType GDPRKeywordType
        {
            get { return _oGDPRKeywordType; }
            set { _oGDPRKeywordType = value; }
        }



        private string? _strSatusName;
        private string? _strActionTypeName;

        public string? ActionTypeName
        {
            get => _strActionTypeName;
            set
            {
                if (_strActionTypeName != value)
                {
                    _strActionTypeName = value;
                    OnPropertyChanged(nameof(ActionTypeName));
                }
            }
        }

        public string? StatusName
        {
            get => _strSatusName;
            set
            {
                if (_strSatusName != value)
                {
                    _strSatusName = value;
                    OnPropertyChanged(nameof(StatusName));
                }
            }
        }


    }
}
