using CommonHelpers.GuardClauses;
using PowerInputTester.Hardware.Events;
using PowerInputTester.UI.Abstract;
using PowerInputTester.UI.Commands;
using System.Windows.Input;

namespace PowerInputTester.UI.ViewModels.PowerSupply
{
    public class CurrentLimitPanelViewModel : ViewModelBase, IInstrumentControlPanel
    {
        #region Backing Fields

        private bool _displayOffset;
        private bool _enabled;
        private InstrumentEventHandler _handler;
        private string _header;
        private string _name;
        private float _reading;
        private float _userInput;

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
        public float Reading
        {
            get { return _reading; }
            set
            {
                SetProperty(ref _reading, value);
                UserInput = value;
            }
        }
        public float UserInput
        {
            get { return _userInput; }
            set { SetProperty(ref _userInput, value); }
        }

        public ICommand DecreaseCommand { get; set; }
        public ICommand IncreaseCommand { get; set; }
        public ICommand UserInputCommand { get; set; }

        public CurrentLimitPanelViewModel(InstrumentEventHandler handler)
        {
            GuardClause.NullReference(handler, "handler");

            _name = "CurrentLimit";

            _handler = handler;
            _handler.OnSettingChanged += _handler_OnSettingChanged;

            DecreaseCommand = new RelayCommand(ExecuteDecreaseCommand, CanExecuteCommands);
            IncreaseCommand = new RelayCommand(ExecuteIncreaseCommand, CanExecuteCommands);
            UserInputCommand = new RelayCommand(ExecuteUserInputCommand, CanExecuteCommands);

            Header = "Current Limit (A)";
            Reading = 0;
            UserInput = 0;
            Enabled = false;

        }
        private bool CanExecuteCommands(object value)
        {
            return true;
        }
        private void ExecuteDecreaseCommand(object value)
        {
            float newValue = Reading - 1;
            _handler?.RaiseUserInput(new InstrumentSettingEventArgs(_name, newValue));
        }
        private void ExecuteIncreaseCommand(object value)
        {
            float newValue = Reading + 1;
            _handler?.RaiseUserInput(new InstrumentSettingEventArgs(_name, newValue));
        }
        private void ExecuteUserInputCommand(object value)
        {
            _handler?.RaiseUserInput(new InstrumentSettingEventArgs(_name, float.Parse(value as string)));
        }
        private void _handler_OnSettingChanged(object sender, InstrumentSettingEventArgs e)
        {
            if (e.SettingName == _name)
            {
                if (Enabled == false)
                {
                    Enabled = true;
                }
                Reading = (float)e.Value;
            }
        }
    }
}
