using PowerInputTester.Hardware.Controls;
using PowerInputTester.UI.Abstract;
using PowerInputTester.UI.Commands;
using PowerInputTester.UI.Events;
using System.Windows.Input;

namespace PowerInputTester.UI.ViewModels
{
    public class ConnectionControlViewModel : ViewModelBase, IInstrumentControlPanel
    {
        #region Backing Fields
        
        bool _enabled;
        string _header;
        UIEventHandler _handler;
        string _status;
        readonly InstrumentType _instrumentType;

        #endregion
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
        public string Status
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }
        public InstrumentType InstrumentType { get; }
        public ICommand ConnectionChangeCommand { get; set; }
        public ConnectionControlViewModel(InstrumentType instrumentType, UIEventHandler handler)
        {
            _instrumentType = instrumentType;
            _handler = handler;
            handler.OnInstrumentConnected += HandleInstrumentConnected;
            handler.OnInstrumentDisconnected += HandleInstrumentDisconnected;
            Status = "DISCONNECTED";
            ConnectionChangeCommand = new RelayCommand(ExecuteConnectionChange, CanExecuteConnectionChange);
            Header = ResolveHeader(instrumentType);
        }
        private bool CanExecuteConnectionChange(object value)
        {
            return true;
        }
        private void ExecuteConnectionChange(object value)
        {
            if (_status == "DISCONNECTED")
            {
                _handler.RequestInstrumentConnect(new DeviceConnectRequestEventArgs(_instrumentType));
            }
            else
            {
                _handler.RequestInstrumentDisconnect(new DeviceConnectRequestEventArgs(_instrumentType));
            }
        }
        private void HandleInstrumentConnected(object sender, InstrumentConnectedEventArgs e)
        {
            if (e.InstrumentType == _instrumentType)
            {
                Status = "CONNECTED";
            }
        }
        private void HandleInstrumentDisconnected(object sender, DeviceConnectRequestEventArgs e)
        {
            if (e.InstrumentType == _instrumentType)
            {
                Status = "DISCONNECTED";
            }
        }
        private string ResolveHeader(InstrumentType instrumentType)
        {
            switch (instrumentType)
            {
                case InstrumentType.Oscilloscope:
                    return "OSCILLOSCOPE";
                case InstrumentType.PowerSupply:
                    return "POWER SUPPLY";
                default:
                    return "ERROR";
            }
        }
    }
}
