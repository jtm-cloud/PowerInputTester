using CommonHelpers.GuardClauses;
using PowerInputTester.Hardware.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PowerInputTester.UI.Models
{
    public class DropdownListOption
    {
        #region Backing Fields

        private InstrumentEventHandler _handler;
        private string _optionsListName;
        private string _selectedOption;
        private Type _valueType;

        #endregion

        public bool Enabled { get; set; }

        public string Name { get; set; }

        public ICollection<string> Options { get; set; }

        public string SelectedOption
        {
            get { return _selectedOption; }
            set
            {
                if (value != _selectedOption)
                {
                    _selectedOption = value;
                    MessageBox.Show(value + " is selected!");
                    //PublishUserInput(value);
                }
            }
        }

        public DropdownListOption(string name, string optionsListName, Type valueType, InstrumentEventHandler handler)
        {
            GuardClause.EmptyString(name, "name");
            GuardClause.EmptyString(optionsListName, "optionsListName");
            GuardClause.NullReference(handler, "handler");

            Name = name;
            _optionsListName = optionsListName;
            _valueType = valueType;
            _handler = handler;
            _handler.OnSettingChanged += _handler_OnSettingChanged;
            _handler.OnSettingEnabledChanged += _handler_OnSettingEnabledChanged;

            Enabled = true;
        }

        private void _handler_OnSettingChanged(object sender, InstrumentSettingEventArgs e)
        {
            if (e.SettingName == Name)
            {
                if (_valueType == typeof(string))
                {
                    SelectedOption = (string)e.Value;
                }
                else if (_valueType == typeof(float))
                {
                    float value = (float)e.Value;
                    SelectedOption = value.ToString();
                }
            }
            else if (e.SettingName == _optionsListName)
            {
                if (_valueType == typeof(string))
                {
                    Options = (ICollection<string>)e.Value;
                }
                else if (_valueType == typeof(float))
                {
                    ICollection<float> floatList = (ICollection<float>)e.Value;
                    Options = floatList.Select(x => x.ToString()).ToList();
                }
            }
        }

        private void _handler_OnSettingEnabledChanged(object sender, SettingEnabledEventArgs e)
        {
            if (e.SettingName == Name)
            {
                Enabled = e.Enabled;
            }
        }

        private void PublishUserInput(string value)
        {
            if (_valueType == typeof(string))
            {
                _handler.RaiseUserInput(new InstrumentSettingEventArgs(Name, value));
            }
            else if (_valueType == typeof(float))
            {
                float floatValue = float.Parse(value);
                _handler.RaiseUserInput(new InstrumentSettingEventArgs(Name, floatValue));
            }
        }
    }
}
