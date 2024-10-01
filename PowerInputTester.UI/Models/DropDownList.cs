using CommonHelpers.GuardClauses;
using PowerInputTester.Hardware.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PowerInputTester.UI.Models
{
    public class DropdownList
    {
        #region Backing Fields

        private InstrumentEventHandler _handler;
        private string _listSettingName;
        private string _selectedItem;
        private Type _valueType;

        #endregion

        public bool Enabled { get; set; }

        public string Name { get; set; }

        public ICollection<string> Items { get; set; }

        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (value != _selectedItem)
                {
                    _selectedItem = value;
                    MessageBox.Show(value + " is selected!");
                    //PublishUserInput(value);
                }
            }
        }

        public DropdownList(string name, string listSettingName, Type valueType, InstrumentEventHandler handler)
        {
            GuardClause.EmptyString(name, "name");
            GuardClause.EmptyString(listSettingName, "listSettingName");
            GuardClause.NullReference(handler, "handler");

            Name = name;
            _listSettingName = listSettingName;
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
                    SelectedItem = (string)e.Value;
                }
                else if (_valueType == typeof(float))
                {
                    float value = (float)e.Value;
                    SelectedItem = value.ToString();
                }
            }
            else if (e.SettingName == _listSettingName)
            {
                if (_valueType == typeof(string))
                {
                    Items = (ICollection<string>)e.Value;
                }
                else if (_valueType == typeof(float))
                {
                    ICollection<float> floatList = (ICollection<float>)e.Value;
                    Items = floatList.Select(x => x.ToString()).ToList();
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
