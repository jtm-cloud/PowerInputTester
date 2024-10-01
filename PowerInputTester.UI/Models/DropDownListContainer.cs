using CommonHelpers.GuardClauses;
using PowerInputTester.Hardware.Events;
using System.Collections.Generic;

namespace PowerInputTester.UI.Models
{
    public class DropDownListContainer
    {
        #region Backing Fields

        private string _enabledReferenceName;
        private InstrumentEventHandler _handler;

        #endregion

        public bool Enabled { get; set; }

        public string Header { get; set; }

        public ICollection<DropdownListOption> Options { get; set; }

        public DropDownListContainer(string header, ICollection<DropdownListOption> options, string enabledReferenceName, InstrumentEventHandler handler)
        {
            GuardClause.EmptyString(header, "header");
            GuardClause.EmptyString(enabledReferenceName, "enabledReferenceName");
            GuardClause.NullReference(handler, "handler");

            Header = header;
            Options = options;
            _enabledReferenceName = enabledReferenceName;
            _handler = handler;
            _handler.OnSettingEnabledChanged += _handler_OnSettingEnabledChanged;

            Enabled = true;
        }

        private void _handler_OnSettingEnabledChanged(object sender, SettingEnabledEventArgs e)
        {
            if (e.SettingName == _enabledReferenceName)
            {
                Enabled = e.Enabled;
            }
        }
    }
}
