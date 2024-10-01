using CommonHelpers.GuardClauses;
using PowerInputTester.Hardware.Events;
using PowerInputTester.UI.Abstract;
using PowerInputTester.UI.Commands;
using System;
using System.Windows.Input;

namespace PowerInputTester.UI.ViewModels
{
    public class RangeSettingControlViewModel : ViewModelBase, IInstrumentControlPanel
    {
        #region Backing Fields

        private bool _enabled;
        private InstrumentEventHandler _handler;
        private string _header;
        private string _name;
        private Type _valueType;

        #endregion

        public ICommand DecreaseCommand { get; set; }

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

        public ICommand IncreaseCommand { get; set; }

        public float Reading { get; set; }

        public float UserInputValue { get; set; }

        public RangeSettingControlViewModel(string name, string header, Type valueType, InstrumentEventHandler handler)
        {
            GuardClause.EmptyString(name, "name");
            GuardClause.EmptyString(header, "header");
            GuardClause.NullReference(handler, "handler");
            GuardClause.NullReference(valueType, "valueType");

            _name = name;
            _handler = handler;
            _valueType = valueType;
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
            _handler?.RaiseUserInput(new InstrumentSettingEventArgs(_name, newValue));
        }

        private void ExecuteIncreaseCommand(object value)
        {
            float newValue = Reading + 1;
            _handler?.RaiseUserInput(new InstrumentSettingEventArgs(_name, newValue));
        }

        private void _handler_OnSettingChanged(object sender, InstrumentSettingEventArgs e)
        {
            if (e.SettingName == _name)
            {
                Reading = (float)e.Value;
                UserInputValue = Reading;
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
