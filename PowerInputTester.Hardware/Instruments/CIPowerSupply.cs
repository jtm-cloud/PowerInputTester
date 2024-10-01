using CommonHelpers.GuardClauses;
using NationalInstruments.Visa;
using PowerInputTester.Hardware.Abstract;
using PowerInputTester.Hardware.Events;
using PowerInputTester.Hardware.Models;
using PowerInputTester.Hardware.Settings;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PowerInputTester.Hardware.Instruments
{
    public class CIPowerSupply : IInstrument
    {
        #region Backing Fields

        Dictionary<string, int> _disabledSettings;
        ICollection<string> _mainSettings;
        InstrumentEventHandler _handler;
        MessageBasedSession _session;

        #endregion
        public InstrumentInfo Info { get; set; }
        public IPowerSupplySettings Settings { get; set; }
        public CIPowerSupply(MessageBasedSession session, InstrumentInfo info, InstrumentEventHandler handler)
        {
            GuardClause.NullReference(session, "session");

            _session = session;
            Info = info;
            _handler = handler;
            _handler.OnUserInput += _handler_OnUserInput;
            _handler.OnAllSettingsRequested += _handler_OnAllSettingsRequested;
            InstrumentMessagingBase messagingBase = new InstrumentMessagingBase(_session);
            Settings = new CIPowerSupplySettings(messagingBase);
            _disabledSettings = new Dictionary<string, int>();

            _mainSettings = new Collection<string>()
            {
                "OutputNumber", "OutputCoupling", "VoltageRangeList", "OutputMode", "OutputState",
                "ClipLevelList", "WaveformShapeList", "VoltageRange", "CurrentLimit",
                "FrequencyA", "FrequencyB", "FrequencyC",
                "ClipLevelA", "ClipLevelB", "ClipLevelC",
                "VoltageA", "VoltageB", "VoltageC",
                "WaveformShapeA", "WaveformShapeB", "WaveformShapeC"
            };
        }

        private void _handler_OnAllSettingsRequested(object sender, System.EventArgs e)
        {
            PublishAllSettingEnabledStatuses();
            PublishAllSettingValues();
        }

        private void _handler_OnUserInput(object sender, InstrumentSettingEventArgs e)
        {
            GuardClause.EmptyString(e.SettingName, "Argument Setting Name");
            if (IsDisabled(e.SettingName) == false)
            {
                UpdateSetting(e.SettingName, e.Value);
                RefreshDisabledSettingsList();
                PublishAllSettingEnabledStatuses();
                PublishAllSettingValues();
            }
        }

        private void AddToDisabledList(string settingName)
        {
            if (IsDisabled(settingName) == false)
            {
                _disabledSettings.Add(settingName, 1);
            }
        }
        public void Dispose()
        {
            Settings.Dispose();
            _handler = null;
            _session.Dispose();
        }
        private bool IsDisabled(string settingName)
        {
            return _disabledSettings.ContainsKey(settingName);
        }
        private void PublishAllSettingEnabledStatuses()
        {
            foreach (string setting in _mainSettings)
            {
                PublishSettingEnabledStatus(setting);
            }
        }
        private void PublishAllSettingValues()
        {
            foreach (string setting in _mainSettings)
            {
                if (IsDisabled(setting) == false)
                {
                    PublishSettingValue(setting);
                }
            }
        }
        private void PublishSettingEnabledStatus(string settingName)
        {
            _handler.RaiseSettingEnabledChanged(new SettingEnabledEventArgs(settingName, !IsDisabled(settingName)));
        }
        private void PublishSettingValue(string settingName)
        {
            switch (settingName)
            {
                case "ClipLevelA":
                    _handler.RaiseSettingChanged(new InstrumentSettingEventArgs(settingName, Settings.ClipLevelA));
                    break;
                case "ClipLevelB":
                    _handler.RaiseSettingChanged(new InstrumentSettingEventArgs(settingName, Settings.ClipLevelB));
                    break;
                case "ClipLevelC":
                    _handler.RaiseSettingChanged(new InstrumentSettingEventArgs(settingName, Settings.ClipLevelC));
                    break;
                case "ClipLevelList":
                    _handler.RaiseSettingChanged(new InstrumentSettingEventArgs(settingName, Settings.ClipLevelList));
                    break;
                case "CurrentLimit":
                    _handler.RaiseSettingChanged(new InstrumentSettingEventArgs(settingName, Settings.CurrentLimit));
                    break;
                case "FrequencyA":
                    _handler.RaiseSettingChanged(new InstrumentSettingEventArgs(settingName, Settings.FrequencyA));
                    break;
                case "FrequencyB":
                    _handler.RaiseSettingChanged(new InstrumentSettingEventArgs(settingName, Settings.FrequencyB));
                    break;
                case "FrequencyC":
                    _handler.RaiseSettingChanged(new InstrumentSettingEventArgs(settingName, Settings.FrequencyC));
                    break;
                case "OutputCoupling":
                    _handler.RaiseSettingChanged(new InstrumentSettingEventArgs(settingName, Settings.OutputCoupling));
                    break;
                case "OutputMode":
                    _handler.RaiseSettingChanged(new InstrumentSettingEventArgs(settingName, Settings.OutputMode));
                    break;
                case "OutputNumber":
                    _handler.RaiseSettingChanged(new InstrumentSettingEventArgs(settingName, Settings.OutputNumber));
                    break;
                case "OutputState":
                    _handler.RaiseSettingChanged(new InstrumentSettingEventArgs(settingName, Settings.OutputState));
                    break;
                case "VoltageA":
                    _handler.RaiseSettingChanged(new InstrumentSettingEventArgs(settingName, Settings.VoltageA));
                    break;
                case "VoltageB":
                    _handler.RaiseSettingChanged(new InstrumentSettingEventArgs(settingName, Settings.VoltageB));
                    break;
                case "VoltageC":
                    _handler.RaiseSettingChanged(new InstrumentSettingEventArgs(settingName, Settings.VoltageC));
                    break;
                case "VoltageRange":
                    _handler.RaiseSettingChanged(new InstrumentSettingEventArgs(settingName, Settings.VoltageRange));
                    break;
                case "VoltageRangeList":
                    _handler.RaiseSettingChanged(new InstrumentSettingEventArgs(settingName, Settings.VoltageRangeList));
                    break;
                case "WaveformShapeA":
                    _handler.RaiseSettingChanged(new InstrumentSettingEventArgs(settingName, Settings.WaveformShapeA));
                    break;
                case "WaveformShapeB":
                    _handler.RaiseSettingChanged(new InstrumentSettingEventArgs(settingName, Settings.WaveformShapeB));
                    break;
                case "WaveformShapeC":
                    _handler.RaiseSettingChanged(new InstrumentSettingEventArgs(settingName, Settings.WaveformShapeC));
                    break;
                case "WaveformShapeList":
                    _handler.RaiseSettingChanged(new InstrumentSettingEventArgs(settingName, Settings.WaveformShapeList));
                    break;
                default: break;
            }
        }
        private void RefreshDisabledSettingsList()
        {
            _disabledSettings.Clear();
            if (Settings.OutputNumber == "FIXED")
            {
                AddToDisabledList("OutputNumber");
                AddToDisabledList("ClipLevelB");
                AddToDisabledList("ClipLevelC");
                AddToDisabledList("FrequencyB");
                AddToDisabledList("FrequencyC");
                AddToDisabledList("VoltageB");
                AddToDisabledList("VoltageC");
                AddToDisabledList("WaveformShapeB");
                AddToDisabledList("WaveformShapeC");
            }
            if (Settings.OutputNumber == "ONE")
            {
                AddToDisabledList("ClipLevelB");
                AddToDisabledList("ClipLevelC");
                AddToDisabledList("FrequencyB");
                AddToDisabledList("FrequencyC");
                AddToDisabledList("VoltageB");
                AddToDisabledList("VoltageC");
                AddToDisabledList("WaveformShapeB");
                AddToDisabledList("WaveformShapeC");
            }
            if (Settings.OutputMode == "DC")
            {
                AddToDisabledList("ClipLevelA");
                AddToDisabledList("ClipLevelList");
                AddToDisabledList("FrequencyA");
                AddToDisabledList("WaveformShapeA");
                AddToDisabledList("WaveformShapeList");
            }
        }
        private void UpdateSetting(string settingName, object value)
        {
            switch (settingName)
            {
                case "ClipLevelA": Settings.ClipLevelA = (float)value; break;
                case "ClipLevelB": Settings.ClipLevelB = (float)value; break;
                case "ClipLevelC": Settings.ClipLevelC = (float)value; break;
                case "CurrentLimit": Settings.CurrentLimit = (float)value; break;
                case "FrequencyA": Settings.FrequencyA = (float)value; break;
                case "FrequencyB": Settings.FrequencyB = (float)value; break;
                case "FrequencyC": Settings.FrequencyC = (float)value; break;
                case "OutputCoupling": Settings.OutputCoupling = (string)value; break;
                case "OutputMode": Settings.OutputMode = (string)value; break;
                case "OutputNumber": Settings.OutputNumber = (string)value; break;
                case "OutputState": Settings.OutputState = (bool)value; break;
                case "VoltageA": Settings.VoltageA = (float)value; break;
                case "VoltageB": Settings.VoltageB = (float)value; break;
                case "VoltageC": Settings.VoltageC = (float)value; break;
                case "VoltageRange": Settings.VoltageRange = (float)value; break;
                case "WaveformShapeA": Settings.WaveformShapeA = (string)value; break;
                case "WaveformShapeB": Settings.WaveformShapeB = (string)value; break;
                case "WaveformShapeC": Settings.WaveformShapeC = (string)value; break;
                default: break;
            }
        }

    }
}
