using CommonHelpers.GuardClauses;
using PowerInputTester.Hardware.Events;
using PowerInputTester.UI.Abstract;
using PowerInputTester.UI.Events;
using PowerInputTester.UI.Models;
using System.Collections.ObjectModel;

namespace PowerInputTester.UI.ViewModels.PowerSupply
{
    public class FrequencyPanelViewModel : ViewModelBase, IInstrumentControlPanel
    {
        #region Backing Fields

        private bool _enabled;
        private InstrumentEventHandler _handler;
        private string _header;
        private ObservableCollection<FrequencySettingControl> _settings;
        private int _settingsCount;

        private string _outputNumber;
        private string _outputMode;

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
        public ObservableCollection<FrequencySettingControl> Settings
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

        public FrequencySettingControl TargetSetting { get; set; }
        public string OutputMode
        {
            get
            {
                return _outputMode;
            }
            set
            {
                if (value != _outputMode)
                {
                    _outputMode = value;
                    if ((value == "DC") || (value == string.Empty))
                    {
                        Settings[2].DisplayOffset = true;
                        TargetSetting = Settings[2];

                        Settings[1].DisplayOffset = true;
                        TargetSetting = Settings[1];

                        Settings[0].DisplayOffset = true;
                        TargetSetting = Settings[0];

                    }
                    else
                    {
                        if (OutputNumber == "ONE")
                        {
                            SettingsCount = 1;
                            Settings[0].DisplayOffset = false;
                        }
                        else if (OutputNumber == "THREE")
                        {
                            SettingsCount = 3;
                            Settings[0].DisplayOffset = false;
                            Settings[1].DisplayOffset = false;
                            Settings[2].DisplayOffset = false;
                        }
                    }
                }
            }
        }
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
                    if ((OutputMode == "DC") || (value == "FIXED") || (OutputMode == string.Empty) || (OutputMode == null))
                    {
                        _outputNumber = value;
                        Settings[2].DisplayOffset = true;
                        TargetSetting = Settings[2];

                        Settings[1].DisplayOffset = true;
                        TargetSetting = Settings[1];

                        Settings[0].DisplayOffset = true;
                        TargetSetting = Settings[0];

                    }
                    else
                    {
                        if (value == "ONE")
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
        }


        public FrequencyPanelViewModel(InstrumentEventHandler handler)
        {
            GuardClause.NullReference(handler, "handler");

            _handler = handler;
            _handler.OnSettingChanged += _handler_OnSettingChanged;

            Settings = new ObservableCollection<FrequencySettingControl>()
            {
                new FrequencySettingControl("FrequencyA", _handler),
                new FrequencySettingControl("FrequencyB", _handler),
                new FrequencySettingControl("FrequencyC", _handler)
            };

            Header = "Frequency (Hz)";
            SettingsCount = 0;
        }

        private void _handler_OnSettingChanged(object sender, InstrumentSettingEventArgs e)
        {
            switch (e.SettingName)
            {
                case "OutputMode":
                    OutputMode = e.Value.ToString();
                    break;
                case "OutputNumber":
                    OutputNumber = e.Value.ToString();
                    break;
            }
        }
    }
}
