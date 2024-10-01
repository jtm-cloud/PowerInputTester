using PowerInputTester.UI.Abstract;
using PowerInputTester.UI.Events;
using PowerInputTester.UI.ViewModels.PowerSupply;
using PowerInputTester.UI.ViewModels.Oscilloscope;

namespace PowerInputTester.UI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Backing Fields

        private PowerSupplyControlViewModel _powerSupplyControl;
        private OscilloscopeControlViewModel _oscilloscopeControl;
        private UIEventHandler _handler;
        private object _leftDock;
        private object _menuBar;
        private object _rightDock;

        #endregion
        public object MenuBar
        {
            get { return _menuBar; }
            set { SetProperty(ref _menuBar, value); }
        }
        public object LeftDock
        {
            get { return _leftDock; }
            set { SetProperty(ref _leftDock, value); }
        }
        public object RightDock
        {
            get { return _rightDock; }
            set { SetProperty(ref _rightDock, value); }
        }
        public PowerSupplyControlViewModel PowerSupplyControl
        {
            get { return _powerSupplyControl; }
            set { SetProperty(ref _powerSupplyControl, value); }
        }
        public OscilloscopeControlViewModel OscilloscopeControl
        {
            get { return _oscilloscopeControl; }
            set { SetProperty(ref _oscilloscopeControl, value); }
        }
        public MainWindowViewModel(UIEventHandler handler)
        {
            _handler = handler;
            MenuBar = new MenuBarViewModel(_handler);
            LeftDock = new SideDockViewModel("Left", _handler);
            RightDock = new SideDockViewModel("Right", _handler);

            OscilloscopeControl = new OscilloscopeControlViewModel(_handler);
            PowerSupplyControl = new PowerSupplyControlViewModel(_handler);

        }
    }
}
