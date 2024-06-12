using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovernanceLibrary.DTOs
{
    public class JobsDueDTO : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Interface
        // Implement the OnPropertyChanged method and the PropertyChanged event.
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion

        private int _iClientJobBatchID;
        private string _strJobName;
        private string _strJobStatus;
        private DateTime _dtRequestDate;
        private int _iStatusID;
        private int _iDaysLeft;

        public int DaysLeft 
        {  
            get => _iDaysLeft;
            set
            {
                if (_iDaysLeft != value)
                {
                    _iDaysLeft = value;
                    OnPropertyChanged(nameof(DaysLeft));
                }
            }
        }
        public int StatusID 
        { 
            get => _iStatusID;
            set
            {
                if (_iStatusID != value)
                {
                    _iStatusID = value;
                    OnPropertyChanged(nameof(StatusID));
                }
            }
        }
        public DateTime RequestDate 
        { 
            get => _dtRequestDate;
            set
            {
                if (_dtRequestDate != value)
                {
                    _dtRequestDate = value;
                    OnPropertyChanged(nameof(RequestDate));
                }
            }
        }
        public string JobStatus
        {
            get => _strJobStatus;
            set
            {
                if (_strJobStatus != value)
                {
                    _strJobStatus = value;
                    OnPropertyChanged(nameof(JobStatus));
                }
            }
        }
        public string JobName 
        { 
            get => _strJobName;
            set
            {
                if (_strJobName != value)
                {
                    _strJobName = value;
                    OnPropertyChanged(nameof(JobName));
                }
            }
        }
        public int ClientJobBatchID 
        { 
            get => _iClientJobBatchID;
            set
            {
                if (_iClientJobBatchID != value)
                {
                    _iClientJobBatchID = value;
                    OnPropertyChanged(nameof(ClientJobBatchID));
                }
            }
        }

    }
}
