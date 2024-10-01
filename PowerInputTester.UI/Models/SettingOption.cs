using CommonHelpers.GuardClauses;
using PowerInputTester.Hardware.Events;
using PowerInputTester.UI.Commands;
using System;
using System.Windows;
using System.Windows.Input;

namespace PowerInputTester.UI.Models
{
    public class SettingOption
    {
        #region Backing Fields

        private InstrumentEventHandler _handler;

        #endregion

        public bool IsChecked { get; set; }

        public string Name { get; set; }

        public string SettingName { get; set; }

        public ICommand UserInputCommand { get; set; }

        public SettingOption(string name, string settingName, InstrumentEventHandler handler)
        {
            GuardClause.EmptyString(name, "name");
            GuardClause.EmptyString(settingName, "settingName");
            GuardClause.NullReference(handler, "handler");

            Name = name;
            SettingName = settingName;
            _handler = handler;
            _handler.OnSettingChanged += _handler_OnSettingChanged;
            UserInputCommand = new RelayCommand(ExecuteUserInputCommand, CanExecuteUserInputCommand);
        }

        private bool CanExecuteUserInputCommand(object value)
        {
            return true;
        }

        private void ExecuteUserInputCommand(object value)
        {
            MessageBox.Show(Name);
        }

        private void _handler_OnSettingChanged(object sender, InstrumentSettingEventArgs e)
        {
            if (e.SettingName == SettingName)
            {
                Type valueType = e.Value.GetType();

                if (valueType == typeof(string))
                {
                    if ((string)e.Value == Name)
                    {
                        IsChecked = true;
                    }
                }
                else if (valueType == typeof(float))
                {
                    float value = (float)e.Value;
                    if (value.ToString() == Name)
                    {
                        IsChecked = true;
                    }
                }
            }
        }
    }
}
