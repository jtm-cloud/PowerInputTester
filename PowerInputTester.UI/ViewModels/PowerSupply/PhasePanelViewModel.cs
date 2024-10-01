using CommonHelpers.GuardClauses;
using PowerInputTester.Hardware.Events;
using PowerInputTester.UI.Abstract;
using PowerInputTester.UI.Commands;
using System.Windows.Input;

namespace PowerInputTester.UI.ViewModels.PowerSupply
{
    public class PhasePanelViewModel : ViewModelBase, IInstrumentControlPanel
    {
        #region Backing Fields

        private bool _displayOffset;
        private bool _enabled;
        private InstrumentEventHandler _handler;
        private string _header;
        private string _name;
        private string _outputNumber;
        private bool _singlePhaseSelected;
        private bool _threePhaseSelected;

        #endregion

        public bool DisplayOffset
        {
            get { return _displayOffset; }
            set { SetProperty(ref _displayOffset, value); }
        }
        public bool Enabled
        {
            get { return _enabled; }
            set {  SetProperty(ref _enabled, value); }
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
        public string OutputNumber
        {
            get { return _outputNumber; }
            set
            {
                if (value != _outputNumber)
                {
                    _outputNumber = value;
                    if (value == "FIXED")
                    {
                        DisplayOffset = true;
                    }
                    else
                    {
                        Enabled = true;
                        DisplayOffset = false;
                        if (value == "ONE")
                        {
                            SinglePhaseSelected = true;
                        }
                        else if (value == "THREE")
                        {
                            ThreePhaseSelected = true;
                        }
                    }
                }
            }
        }
        public bool SinglePhaseSelected
        {
            get { return _singlePhaseSelected; }
            set { SetProperty(ref _singlePhaseSelected, value); }
        }
        public bool ThreePhaseSelected
        {
            get { return _threePhaseSelected; }
            set { SetProperty(ref _threePhaseSelected, value); }
        }

        public ICommand SinglePhaseCommand { get; set; }
        public ICommand ThreePhaseCommand { get; set; }
        public PhasePanelViewModel(InstrumentEventHandler handler)
        {
            GuardClause.NullReference(handler, "handler");

            Name = "OutputNumber";
            _handler = handler;
            _handler.OnSettingChanged += _handler_OnSettingChanged;

            SinglePhaseCommand = new RelayCommand(ExecuteSinglePhaseCommand, CanExecuteCommands);
            ThreePhaseCommand = new RelayCommand(ExecuteThreePhaseCommand, CanExecuteCommands);

            Header = "Phase Setting";
            DisplayOffset = true;
        }

        private bool CanExecuteCommands(object value)
        {
            return _enabled;
        }
        private void ExecuteSinglePhaseCommand(object value)
        {
            _handler?.RaiseUserInput(new InstrumentSettingEventArgs(_name, "ONE"));
        }
        private void ExecuteThreePhaseCommand(object value)
        {
            _handler?.RaiseUserInput(new InstrumentSettingEventArgs(_name, "THREE"));
        }
        private void _handler_OnSettingChanged(object sender, InstrumentSettingEventArgs e)
        {
            if (e.SettingName == "OutputNumber")
            {
                OutputNumber = e.Value.ToString();
            }
        }
    }
}
