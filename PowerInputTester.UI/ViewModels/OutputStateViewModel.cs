using CommonHelpers.GuardClauses;
using PowerInputTester.Hardware.Events;
using PowerInputTester.UI.Abstract;
using PowerInputTester.UI.Commands;
using System.Windows;
using System.Windows.Input;

namespace PowerInputTester.UI.ViewModels
{
    public class OutputStateViewModel : ViewModelBase, IInstrumentControlPanel
    {
        #region Backing Fields

        private bool _enabled;
        private InstrumentEventHandler _handler;
        private string _header;
        private string _name;
        private string _status;

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

        public ICommand OutputChangeCommand { get; set; }

        public OutputStateViewModel(string name, string header, InstrumentEventHandler handler)
        {
            GuardClause.EmptyString(name, "name");
            GuardClause.EmptyString(header, "header");
            GuardClause.NullReference(handler, "handler");

            _name = name;
            Header = header;
            Status = "OFF";
            _handler = handler;
            _handler.OnSettingEnabledChanged += _handler_OnSettingEnabledChanged;
            _handler.OnSettingChanged += _handler_OnSettingChanged;
            OutputChangeCommand = new RelayCommand(ExecuteOutputChange, CanExecuteOutputChange);

            Enabled = true;
        }

        private void _handler_OnSettingChanged(object sender, InstrumentSettingEventArgs e)
        {
            if (e.SettingName == _name)
            {
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

        private bool CanExecuteOutputChange(object value)
        {
            return _enabled;
        }

        private void ExecuteOutputChange(object value)
        {
            if (Status == "OFF")
            {
                Status = "ON";
                //_handler?.RaiseUserInput(new InstrumentSettingEventArgs(_name, true));
            }
            else if (Status == "ON")
            {
                Status = "OFF";
                //_handler?.RaiseUserInput(new InstrumentSettingEventArgs(_name, false));
            }
        }

        private void _handler_OnSettingEnabledChanged(object sender, SettingEnabledEventArgs e)
        {
            if (e.SettingName == _name)
            {
                Enabled = e.Enabled;
            }
        }
    }
}
