using PowerInputTester.Controls;
using PowerInputTester.Events;
using System.Windows;

namespace PowerInputTester.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Private Fields

        private UIEventManager _handler;
        private SideDockViewModel _leftDock;
        private MenuBarViewModel _menuBar;
        private SideDockViewModel _rightDock;

        #endregion
        public MenuBarViewModel MenuBar
        {
            get { return _menuBar; }
            set { SetProperty(ref _menuBar, value); }
        }
        public SideDockViewModel LeftDock
        {
            get { return _leftDock; }
            set { SetProperty(ref _leftDock, value); }
        }
        public SideDockViewModel RightDock
        {
            get { return _rightDock; }
            set { SetProperty(ref _rightDock, value); }
        }
        public MainWindowViewModel(UIEventManager handler)
        {
            _handler = handler;
            _handler.MenuBarItemSelected += _handler_MenuBarItemSelected;
            _handler.SideDockItemSelected += _handler_SideDockItemSelected;
            MenuBar = new MenuBarViewModel(handler);
            LeftDock = new SideDockViewModel("Left", handler);
            RightDock = new SideDockViewModel("Right", handler);
        }

        private void _handler_SideDockItemSelected(object sender, UISelectionEventArgs e)
        {
            MessageBox.Show(e.Name, "Dock Item Selected");
        }

        private void _handler_MenuBarItemSelected(object sender, UISelectionEventArgs e)
        {
            MessageBox.Show(e.Name, "Menu Item Selected");
        }
    }
}
