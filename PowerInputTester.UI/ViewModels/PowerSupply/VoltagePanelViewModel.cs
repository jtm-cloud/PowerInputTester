using CommonHelpers.GuardClauses;
using PowerInputTester.Hardware.Events;
using PowerInputTester.UI.Abstract;
using PowerInputTester.UI.Models;
using System.Collections.ObjectModel;

namespace PowerInputTester.UI.ViewModels.PowerSupply
{
    public class VoltagePanelViewModel : ViewModelBase, IInstrumentControlPanel
    {
        #region Backing Fields

        private bool _enabled;
        private InstrumentEventHandler _handler;
        private string _header;
        private string _outputNumber;
        private ObservableCollection<VoltageSettingControl> _settings;
        private int _settingsCount;

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
        public ObservableCollection<VoltageSettingControl> Settings
        {
            get { return _settings; }
            set { SetProperty(ref _settings, value); }
        }
        public int SettingsCount
        {
            get { return _settingsCount; }
            set
            {
                SetProperty(ref _settingsCount, value);
                if (_settingsCount == 0)
                {
                    Enabled = false;
                }
                else
                {
                    Enabled = true;
                }
            }
        }

        public VoltageSettingControl TargetSetting { get; set; }
        public string OutputNumber
        {
            get
            {
                return _outputNumber;
            }
            set
            {
                if (value != _outputNumber)
                {
                    if ((value == "ONE") || (value == "FIXED"))
                    {
                        if (_outputNumber == "THREE")
                        {
                            _outputNumber = value;
                            Settings[2].DisplayOffset = true;
                            TargetSetting = Settings[2];

                            Settings[1].DisplayOffset = true;
                            TargetSetting = Settings[1];
                        }
                        else
                        {
                            _outputNumber = value;
                            SettingsCount = 1;
                            Settings[0].DisplayOffset = false;
                        }
                    }
                    else if (value == "THREE")
                    {
                        _outputNumber = value;
                        SettingsCount = 3;
                        Settings[0].DisplayOffset = false;
                        Settings[1].DisplayOffset = false;
                        Settings[2].DisplayOffset = false;
                    }
                }
            }
        }

        public VoltagePanelViewModel(InstrumentEventHandler handler)
        {
            GuardClause.NullReference(handler, "handler");

            _handler = handler;
            _handler.OnSettingChanged += _handler_OnSettingChanged;

            Settings = new ObservableCollection<VoltageSettingControl>()
            {
                new VoltageSettingControl("VoltageA", _handler),
                new VoltageSettingControl("VoltageB", _handler),
                new VoltageSettingControl("VoltageC", _handler)
            };

            Header = "Amplitude (V):";
            SettingsCount = 0;
        }

        private void _handler_OnSettingChanged(object sender, InstrumentSettingEventArgs e)
        {
            if (e.SettingName == "OutputNumber")
            {
                OutputNumber = e.Value.ToString();
            }
        }
    }
}
