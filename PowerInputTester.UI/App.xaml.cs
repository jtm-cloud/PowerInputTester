using PowerInputTester.UI.Controls;
using PowerInputTester.UI.Events;
using PowerInputTester.UI.ViewModels;
using PowerInputTester.UI.Views;
using System.Windows;

namespace PowerInputTester.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            UIEventHandler handler = new UIEventHandler();
            UserControlViewService viewService = new UserControlViewService(handler);
            ServiceProvider provider = new ServiceProvider(handler);
            MainWindowViewModel viewModel = new MainWindowViewModel(handler);
            MainWindow mainWindow = new MainWindow();
            mainWindow.DataContext = viewModel;
            mainWindow.Show();
        }
    }
}
