using CommonHelpers.GuardClauses;
using PowerInputTester.Hardware.Events;
using PowerInputTester.UI.Abstract;
using PowerInputTester.UI.Commands;
using System.Windows.Input;

namespace PowerInputTester.UI.Models
{
    public class VoltageSettingControl : ViewModelBase
    {
        #region Backing Fields

        private bool _displayOffset;
        private bool _enabled;
        private InstrumentEventHandler _handler;
        private string _name;
        private string _phase;
        private float _reading;
        private float _userInput;

        #endregion

        public bool DisplayOffset
        {
            get { return _displayOffset; }
            set
            {
                if (value != _displayOffset)
                {
                    if (value == true)
                    {
                        SetProperty(ref _displayOffset, value);
                    }
                    else
                    {
                        Enabled = true;
                        SetProperty(ref _displayOffset, value);
                    }
                }
            }
        }
        public bool Enabled
        {
            get { return _enabled; }
            set { SetProperty(ref _enabled, value); }
        }
        public string Phase
        {
            get { return _phase; }
            set { SetProperty(ref _phase, value); }
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

        public VoltageSettingControl(string name, InstrumentEventHandler handler)
        {
            GuardClause.EmptyString(name, "name");
            GuardClause.NullReference(handler, "handler");

            _name = name;

            _handler = handler;
            _handler.OnSettingChanged += _handler_OnSettingChanged;

            DecreaseCommand = new RelayCommand(ExecuteDecreaseCommand, CanExecuteCommands);
            IncreaseCommand = new RelayCommand(ExecuteIncreaseCommand, CanExecuteCommands);
            UserInputCommand = new RelayCommand(ExecuteUserInputCommand, CanExecuteCommands);


            Phase = name[name.Length - 1].ToString();
            Reading = 0;
            UserInput = 0;

            DisplayOffset = true;
        }
        private bool CanExecuteCommands(object value)
        {
            return Enabled;
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
                Reading = (float)e.Value;
            }
        }
    }
}
