using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataIntelligenceWpfApp.ViewModels;
using DataIntelligenceWpfApp.Views;

namespace DataIntelligenceWpfApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _currentViewModel;
        public DashboardViewModel DashboardViewModel { get; }

        public BaseViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(DashboardViewModel dashboardViewModel)
        {
            DashboardViewModel = dashboardViewModel;
            //CurrentViewModel = dashboardViewModel;
            
        }
    }
}
