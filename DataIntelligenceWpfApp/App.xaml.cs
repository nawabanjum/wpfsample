using DataIntelligenceWpfApp.Models;
using DataIntelligenceWpfApp.Services;
using DataIntelligenceWpfApp.ViewModels;
using DataIntelligenceWpfApp.Views;

using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Navigation;

namespace DataIntelligenceWpfApp
{


    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private UserSession _oUserSession;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            this.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            // Initialize services and view models
            DataService dataService = new DataService();
            UserSession userSession = new UserSession(dataService);
            DashboardViewModel dashboardViewModel = new DashboardViewModel(userSession, dataService);

            MainViewModel mainViewModel = new MainViewModel(dashboardViewModel);

            // Create and show MainWindow
            MainWindow mainWindow = new MainWindow(mainViewModel);
            mainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }

    }

}
