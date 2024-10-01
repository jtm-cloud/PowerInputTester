using PowerInputTester.Hardware.Controls;
using PowerInputTester.UI.Abstract;
using PowerInputTester.UI.Commands;
using PowerInputTester.UI.Events;
using System.Windows.Input;

namespace PowerInputTester.UI.ViewModels.Oscilloscope
{
    public class ConnectionPanelViewModel : ViewModelBase, IInstrumentControlPanel
    {
        #region Backing Fields

        private bool _enabled;
        private string _header;
        private UIEventHandler _handler;
        private string _status;
        private string _buttonCaption;

        #endregion

        public string ButtonCaption
        {
            get { return _buttonCaption; }
            set { SetProperty(ref _buttonCaption, value); }
        }
        public bool Enabled
        {
            get { return _enabled; }
            set { SetProperty(ref _enabled, value); }
        }
        public string Header
        {
            get { return _header; }
            set { SetProperty(ref _header, value); }
        }
        public InstrumentType InstrumentType { get; set; }
        public string Status
        {
            get { return _status; }
            set
            {
                SetProperty(ref _status, value);
                switch (value)
                {
                    case "DISCONNECTED":
                        ButtonCaption = "Connect";
                        break;
                    case "CONNECTED":
                        ButtonCaption = "Disconnect";
                        break;
                    default:
                        break;
                }
            }
        }
        public ICommand ConnectionChangeCommand { get; set; }

        public ConnectionPanelViewModel(UIEventHandler handler)
        {
            _handler = handler;
            _handler.OnInstrumentConnected += _handler_OnInstrumentConnected;
            _handler.OnInstrumentDisconnected += _handler_OnInstrumentDisconnected;

            ConnectionChangeCommand = new RelayCommand(ExecuteConnectionChange, CanExecuteConnectionChange);

            Header = "Oscilloscope";
            Status = "DISCONNECTED";
            InstrumentType = InstrumentType.Oscilloscope;
            Enabled = true;
        }
        private void _handler_OnInstrumentConnected(object sender, InstrumentConnectedEventArgs e)
        {
            if (e.InstrumentType == InstrumentType)
            {
                Status = "CONNECTED";
            }
        }
        private void _handler_OnInstrumentDisconnected(object sender, DeviceConnectRequestEventArgs e)
        {
            if (e.InstrumentType == InstrumentType)
            {
                Status = "DISCONNECTED";
            }
        }
        private bool CanExecuteConnectionChange(object value)
        {
            return Enabled;
        }
        private void ExecuteConnectionChange(object value)
        {
            if (Status == "DISCONNECTED")
            {
                _handler.RequestInstrumentConnect(new DeviceConnectRequestEventArgs(InstrumentType));
            }
            else if (Status == "CONNECTED")
            {
                _handler.RequestInstrumentDisconnect(new DeviceConnectRequestEventArgs(InstrumentType));
            }
        }
    }
}
