using CommonHelpers.GuardClauses;
using PowerInputTester.Hardware.Events;
using PowerInputTester.UI.Commands;
using System.Windows.Input;

namespace PowerInputTester.UI.Models
{
    public class RangeSettingControl
    {
        #region Backing Fields

        private InstrumentEventHandler _handler;

        #endregion

        public ICommand DecreaseCommand { get; set; }

        public bool Enabled { get; set; }

        public ICommand IncreaseCommand { get; set; }

        public string Name { get; set; }

        public float Reading { get; set; }

        public float UserInputValue { get; set; }

        public RangeSettingControl(string name, InstrumentEventHandler handler)
        {
            GuardClause.EmptyString(name, "name");
            GuardClause.NullReference(handler, "handler");

            Name = name;
            _handler = handler;
            UserInputValue = 115;
            Reading = 115;
            _handler.OnSettingChanged += _handler_OnSettingChanged;
            _handler.OnSettingEnabledChanged += _handler_OnSettingEnabledChanged;
            DecreaseCommand = new RelayCommand(ExecuteDecreaseCommand, CanExecuteDecreaseCommand);
            IncreaseCommand = new RelayCommand(ExecuteIncreaseCommand, CanExecuteIncreaseCommand);
            Enabled = true;
        }

        private bool CanExecuteDecreaseCommand(object value)
        {
            return Enabled;
        }

        private bool CanExecuteIncreaseCommand(object value)
        {
            return Enabled;
        }

        private void ExecuteDecreaseCommand(object value)
        {
            float newValue = Reading - 1;
            _handler?.RaiseUserInput(new InstrumentSettingEventArgs(Name, newValue));
        }

        private void ExecuteIncreaseCommand(object value)
        {
            float newValue = Reading + 1;
            _handler?.RaiseUserInput(new InstrumentSettingEventArgs(Name, newValue));
        }

        private void _handler_OnSettingChanged(object sender, InstrumentSettingEventArgs e)
        {
            if (e.SettingName == Name)
            {
                Reading = (float)e.Value;
                UserInputValue = Reading;
            }
        }

        private void _handler_OnSettingEnabledChanged(object sender, SettingEnabledEventArgs e)
        {
            if (e.SettingName == Name)
            {
                Enabled = e.Enabled;
            }
        }
    }
}
