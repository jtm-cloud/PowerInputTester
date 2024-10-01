using CommonHelpers.GuardClauses;
using PowerInputTester.Hardware.Events;
using PowerInputTester.UI.Abstract;
using PowerInputTester.UI.Commands;
using System.Windows.Input;

namespace PowerInputTester.UI.ViewModels.PowerSupply
{
    public class OutputModePanelViewModel : ViewModelBase, IInstrumentControlPanel
    {
        #region Backing Fields

        private bool _displayOffset;
        private bool _enabled;
        private InstrumentEventHandler _handler;
        private string _header;
        private string _name;
        private bool _acSelected;
        private bool _acdcSelected;
        private bool _dcSelected;

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
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        public bool ACSelected
        {
            get { return _acSelected; }
            set { SetProperty(ref _acSelected, value); }
        }
        public bool ACDCSelected
        {
            get { return _acdcSelected; }
            set { SetProperty(ref _acdcSelected, value); }
        }
        public bool DCSelected
        {
            get { return _dcSelected; }
            set { SetProperty(ref _dcSelected, value); }
        }

        public ICommand ACCommand { get; set; }
        public ICommand ACDCCommand { get; set; }
        public ICommand DCCommand { get; set; }
        public OutputModePanelViewModel(InstrumentEventHandler handler)
        {
            GuardClause.NullReference(handler, "handler");

            Name = "OutputMode";
            _handler = handler;
            _handler.OnSettingChanged += _handler_OnSettingChanged;

            ACCommand = new RelayCommand(ExecuteACCommand, CanExecuteCommands);
            ACDCCommand = new RelayCommand(ExecuteACDCCommand, CanExecuteCommands);
            DCCommand = new RelayCommand(ExecuteDCCommand, CanExecuteCommands);

            Header = "Output Mode";
            Enabled = false;
        }

        private bool CanExecuteCommands(object value)
        {
            return true;
        }
        private void ExecuteACCommand(object value)
        {
            _handler?.RaiseUserInput(new InstrumentSettingEventArgs(_name, "AC"));
        }
        private void ExecuteACDCCommand(object value)
        {
            _handler?.RaiseUserInput(new InstrumentSettingEventArgs(_name, "ACDC"));
        }
        private void ExecuteDCCommand(object value)
        {
            _handler?.RaiseUserInput(new InstrumentSettingEventArgs(_name, "DC"));
        }
        private void _handler_OnSettingChanged(object sender, InstrumentSettingEventArgs e)
        {
            if (e.SettingName == _name)
            {
                if (Enabled == false)
                {
                    Enabled = true;
                }
                if (e.Value.ToString() == "AC")
                {
                    ACSelected = true;
                }
                else if (e.Value.ToString() == "ACDC")
                {
                    ACDCSelected = true;
                }
                else if (e.Value.ToString() == "DC")
                {
                    DCSelected = true;
                }
            }
        }
    }
}
