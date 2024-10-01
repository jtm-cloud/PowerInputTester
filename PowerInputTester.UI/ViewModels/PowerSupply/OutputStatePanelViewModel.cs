using CommonHelpers.GuardClauses;
using PowerInputTester.Hardware.Events;
using PowerInputTester.UI.Abstract;
using PowerInputTester.UI.Commands;
using System.Windows.Input;

namespace PowerInputTester.UI.ViewModels.PowerSupply
{
    public class OutputStatePanelViewModel : ViewModelBase, IInstrumentControlPanel
    {
        #region Backing Fields

        private bool _displayOffset;
        private bool _enabled;
        private InstrumentEventHandler _handler;
        private string _header;
        private string _name;
        private string _status;

        #endregion

        public bool DisplayOffset
        {
            get { return _displayOffset; }
            set { SetProperty(ref _displayOffset, value); }
        }
        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                if (value != _enabled)
                {
                    if (value == true)
                    {
                        SetProperty(ref _enabled, value);
                        DisplayOffset = false;
                    }
                    else
                    {
                        DisplayOffset = true;
                    }
                }
            }
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
        public ICommand OutputChangeCommand { get; set; }
        public OutputStatePanelViewModel(InstrumentEventHandler handler)
        {
            GuardClause.NullReference(handler, "handler");

            _name = "OutputState";
            _handler = handler;
            _handler.OnSettingChanged += _handler_OnSettingChanged;
            OutputChangeCommand = new RelayCommand(ExecuteOutputChange, CanExecuteOutputChange);

            Header = "Output State";
            Status = "OFF";
            Enabled = false;
        }

        private bool CanExecuteOutputChange(object value)
        {
            return true;
        }
        private void ExecuteOutputChange(object value)
        {
            if (Status == "OFF")
            {
                _handler?.RaiseUserInput(new InstrumentSettingEventArgs(_name, true));
            }
            else if (Status == "ON")
            {
                _handler?.RaiseUserInput(new InstrumentSettingEventArgs(_name, false));
            }
        }
        private void _handler_OnSettingChanged(object sender, InstrumentSettingEventArgs e)
        {
            if (e.SettingName == _name)
            {
                if (Enabled == false)
                {
                    Enabled = true;
                }
                if ((bool)e.Value == false)
                {
                    Status = "OFF";
                }
                else if ((bool)e.Value == true)
                {
                    Status = "ON";
                }
            }
        }
    }
}
