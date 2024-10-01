using CommonHelpers.GuardClauses;
using PowerInputTester.Hardware.Events;
using PowerInputTester.Hardware.Models;
using PowerInputTester.UI.Abstract;
using PowerInputTester.UI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PowerInputTester.UI.ViewModels
{
    public class RadioButtonPanelViewModel : ViewModelBase, IInstrumentControlPanel
    {
        #region Backing Fields

        private bool _enabled;
        private InstrumentEventHandler _handler;
        private string _name;
        private ObservableCollection<SettingOption> _options;
        private string _optionListName;

        #endregion

        public bool Enabled
        {
            get { return _enabled; }
            set { SetProperty(ref _enabled, value); }
        }

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public ObservableCollection<SettingOption> Options
        {
            get { return _options; }
            set { SetProperty(ref _options, value); }
        }

        public RadioButtonPanelViewModel(string name, ICollection<string> optionNames, InstrumentEventHandler handler, string optionListName = null)
        {
            GuardClause.EmptyString(name, "name");
            GuardClause.NullReference(optionNames, "optionNames");
            GuardClause.ZeroValue(optionNames.Count, "optionNames.Count");
            GuardClause.NullReference(handler, "handler");

            Name = name;
            _optionListName = optionListName;
            Options = new ObservableCollection<SettingOption>();
            foreach (string optionName in optionNames)
            {
                Options.Add(new SettingOption(optionName, name, handler));
            }

            _handler = handler;
            _handler.OnSettingEnabledChanged += _handler_OnSettingEnabledChanged;
            _handler.OnSettingChanged += _handler_OnSettingChanged;

            Enabled = true;
        }

        private void _handler_OnSettingEnabledChanged(object sender, SettingEnabledEventArgs e)
        {
            if (e.SettingName == _name)
            {
                Enabled = e.Enabled;
            }
        }

        private void _handler_OnSettingChanged(object sender, InstrumentSettingEventArgs e)
        {
            if (e.SettingName == _optionListName)
            {
                Type referenceType = typeof(SettingRange);
                if (referenceType == e.Value.GetType())
                {
                    SettingRange value = (SettingRange)e.Value;
                    Options = new ObservableCollection<SettingOption>()
                    {
                        new SettingOption(value.Min.ToString(), _name, _handler),
                        new SettingOption(value.Max.ToString(), _name, _handler)
                    };
                }
            }
        }
    }
}
