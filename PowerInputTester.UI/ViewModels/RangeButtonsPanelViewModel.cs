using CommonHelpers.GuardClauses;
using PowerInputTester.Hardware.Events;
using PowerInputTester.UI.Abstract;
using PowerInputTester.UI.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PowerInputTester.UI.ViewModels
{
    public class RangeButtonsPanelViewModel : ViewModelBase, IInstrumentControlPanel
    {
        #region Backing Fields

        private bool _enabled;
        private InstrumentEventHandler _handler;
        private string _name;
        private ObservableCollection<RangeButtonsOption> _options;

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

        public ObservableCollection<RangeButtonsOption> Options
        {
            get { return _options; }
            set { SetProperty(ref _options, value); }
        }

        public RangeButtonsPanelViewModel(string name, ICollection<string> optionNames, InstrumentEventHandler handler)
        {
            GuardClause.EmptyString(name, "name");
            GuardClause.NullReference(optionNames, "optionNames");
            GuardClause.ZeroValue(optionNames.Count, "optionNames.Count");
            GuardClause.NullReference(handler, "handler");

            Name = name;
            Options = new ObservableCollection<RangeButtonsOption>();
            foreach (string optionName in optionNames)
            {
                char lastCharacter = optionName[optionName.Length - 1];
                Options.Add(new RangeButtonsOption(optionName, lastCharacter.ToString(), handler));
            }

            _handler = handler;
            _handler.OnSettingEnabledChanged += _handler_OnSettingEnabledChanged;

            Enabled = true;
        }

        private void _handler_OnSettingEnabledChanged(object sender, SettingEnabledEventArgs e)
        {
            if (e.SettingName == _options[0].Name)
            {
                Enabled = e.Enabled;
            }
        }
    }
}
