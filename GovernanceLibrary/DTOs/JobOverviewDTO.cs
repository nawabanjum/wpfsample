using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovernanceLibrary.DTOs
{
    public class JobOverviewDTO : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Interface
        // Implement the OnPropertyChanged method and the PropertyChanged event.
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion

        private int _notStarted;
        private int _inProgress;
        private int _forReview;
        private int _liveJobs;

        public int LiveJobs
        {
            get => _liveJobs;
            set
            {
                if (_liveJobs != value)
                {
                    _liveJobs = value;
                    OnPropertyChanged(nameof(LiveJobs));
                }
            }
        }

        public int NotStarted
        {
            get => _notStarted;
            set
            {
                if (_notStarted != value)
                {
                    _notStarted = value;
                    OnPropertyChanged(nameof(NotStarted));
                }
            }
        }

        public int InProgress
        {
            get => _inProgress;
            set
            {
                if (_inProgress != value)
                {
                    _inProgress = value;
                    OnPropertyChanged(nameof(InProgress));
                }
            }
        }

        public int ForReview
        {
            get => _forReview;
            set
            {
                if (_forReview != value)
                {
                    _forReview = value;
                    OnPropertyChanged(nameof(ForReview));
                }
            }
        }
    }
}
