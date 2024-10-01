using CommonHelpers.GuardClauses;
using PowerInputTester.Hardware.Events;
using PowerInputTester.UI.Abstract;
using PowerInputTester.UI.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PowerInputTester.UI.ViewModels
{
    public class DropdownListPanelViewModel : ViewModelBase, IInstrumentControlPanel
    {
        #region Backing Fields

        private bool _enabled;
        private string _enabledReferenceName;
        private InstrumentEventHandler _handler;
        private string _header;
        private ObservableCollection<DropDownListContainer> _containers;

        #endregion

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

        public ObservableCollection<DropDownListContainer> Containers
        {
            get { return _containers; }
            set { SetProperty(ref _containers, value); }
        }

        public DropdownListPanelViewModel(string header, ICollection<DropDownListContainer> containers, string enabledReferenceName, InstrumentEventHandler handler)
        {
            GuardClause.EmptyString(header, "header");
            GuardClause.EmptyString(enabledReferenceName, "enabledReferenceName");
            GuardClause.NullReference(containers, "containers");
            GuardClause.ZeroValue(containers.Count, "containers.Count");
            GuardClause.NullReference(handler, "handler");

            Header = header;
            _enabledReferenceName = enabledReferenceName;
            Containers = new ObservableCollection<DropDownListContainer>(containers);

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
