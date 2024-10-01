using CommonHelpers.GuardClauses;
using PowerInputTester.Hardware.Events;
using PowerInputTester.UI.Commands;
using System.Windows;
using System.Windows.Input;

namespace PowerInputTester.UI.Models
{
    public class RangeButtonsOption
    {
        #region Backing Fields

        private InstrumentEventHandler _handler;

        #endregion

        public ICommand DecreaseCommand { get; set; }

        public bool Enabled { get; set; }

        public ICommand IncreaseCommand { get; set; }

        public string Label { get; set; }

        public string Name { get; set; }

        public float Reading { get; set; }

        public float UserInputValue { get; set; }

        public RangeButtonsOption(string name, string label, InstrumentEventHandler handler)
        {
            GuardClause.EmptyString(name, "name");
            GuardClause.NullReference(handler, "handler");

            Name = name;
            Label = label;
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
            return true;
        }

        private bool CanExecuteIncreaseCommand(object value)
        {
            return true;
        }

        private void ExecuteDecreaseCommand(object value)
        {
            MessageBox.Show(Name + " Decreased!");
        }

        private void ExecuteIncreaseCommand(object value)
        {
            MessageBox.Show(Name + " Increased!");
        }

        private void _handler_OnSettingChanged(object sender, InstrumentSettingEventArgs e)
        {
            if (e.SettingName == Name)
            {
                Reading = (float)e.Value;
                UserInputValue = (float)e.Value;
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
