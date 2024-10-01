using PowerInputTester.Hardware.Abstract;
using PowerInputTester.Hardware.Models;
using PowerInputTester.Hardware.SettingTypes;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PowerInputTester.Hardware.Controls
{
    public class CIPowerSupplySettingsFactory : IInstrumentSettingsFactory
    {
        #region Backing Fields
        CIPowerSupplyOptionsFactory _optionsFactory;
        CIPowerSupplyPreTriggersFactory _preTriggerFactory;
        CIPowerSupplyPostTriggersFactory _postTriggerFactory;
        #endregion
        public CIPowerSupplySettingsFactory()
        {
            _preTriggerFactory = new CIPowerSupplyPreTriggersFactory();
            _postTriggerFactory = new CIPowerSupplyPostTriggersFactory();
            _optionsFactory = new CIPowerSupplyOptionsFactory();
        }
        public IDictionary<string, ISetting> Create()
        {
            IDictionary<string, ISetting> settings = new Dictionary<string, ISetting>()
            {
                { "OutputNumber", CreateOutputNumberSetting() },
                { "OutputMode", CreateOutputModeSetting() },
                { "VoltageRange", CreateVoltageRangeSetting() },
                { "OutputCoupling", CreateOutputCouplingSetting() },
                { "PhaseSelection", CreatePhaseSelectionSetting() },
                { "VoltageA", CreateVoltageASetting() },
                { "VoltageB", CreateVoltageBSetting() },
                { "VoltageC", CreateVoltageCSetting() },
                { "FrequencyA", CreateFrequencyASetting() },
                { "FrequencyB", CreateFrequencyBSetting() },
                { "FrequencyC", CreateFrequencyCSetting() },
                { "CurrentLimit", CreateCurrentLimitSetting() },
                { "WaveformShape", CreateWaveformShapeSetting() },
                { "ClipLevel", CreateClipLevelSetting() },
                { "OutputState", CreateOutputStateSetting() },
            };
            return settings;
        }
        private ISetting CreateOutputNumberSetting()
        {
            return CreateOptionsSetting("OutputNumber", "SYST:CONF:NOUT", SettingReadType.String, true);
        }
        private ISetting CreateOutputModeSetting()
        {
            return CreateOptionsSetting("OutputMode", "MODE", SettingReadType.String, true);
        }
        private ISetting CreateVoltageRangeSetting()
        {
            SettingLimits limits = CreateLimits("VoltageRange", "VOLT:RANG");
            ICollection<SettingChangeTrigger> preTriggers = _preTriggerFactory.Create("VoltageRange");
            ICollection<SettingChangeTrigger> postTriggers = _postTriggerFactory.Create("VoltageRange");
            return new OptionMinMaxTypeSetting("VoltageRange",
                                               "VOLT:RANG?",
                                               SettingReadType.Integer,
                                               limits,
                                               "VOLT:RANG ",
                                               true,
                                               preTriggers,
                                               postTriggers);
        }
        private ISetting CreateOutputCouplingSetting()
        {
            return CreateOptionsSetting("OutputCoupling", "INST:COUP", SettingReadType.String, false);
        }
        private ISetting CreatePhaseSelectionSetting()
        {
            SettingOptions options = _optionsFactory.Create("PhaseSelection");
            return new OptionTypeSetting("PhaseSelection",
                                         "INST:NSEL?",
                                         SettingReadType.Integer,
                                         options,
                                         "INST:NSEL ",
                                         false,
                                         null,
                                         null);
        }
        private ISetting CreateVoltageASetting()
        {
            return CreateRangeSetting("VoltageA", "VOLT", SettingReadType.Float);
        }
        private ISetting CreateVoltageBSetting()
        {
            return CreateRangeSetting("VoltageB", "VOLT", SettingReadType.Float);
        }
        private ISetting CreateVoltageCSetting()
        {
            return CreateRangeSetting("VoltageC", "VOLT", SettingReadType.Float);
        }
        private ISetting CreateFrequencyASetting()
        {
            return CreateRangeSetting("FrequencyA", "FREQ", SettingReadType.Float);
        }
        private ISetting CreateFrequencyBSetting()
        {
            return CreateRangeSetting("FrequencyB", "FREQ", SettingReadType.Float);
        }
        private ISetting CreateFrequencyCSetting()
        {
            return CreateRangeSetting("FrequencyC", "FREQ", SettingReadType.Float);
        }
        private ISetting CreateCurrentLimitSetting()
        {
            return CreateRangeSetting("CurrentLimit", "CURR", SettingReadType.Float);
        }
        private ISetting CreateWaveformShapeSetting()
        {
            return CreateListSetting("WaveformShape", "FUNC", SettingReadType.String, false);
        }
        private ISetting CreateClipLevelSetting()
        {
            return CreateListSetting("ClipLevel", "FUNC:CSIN", SettingReadType.Float, true);
        }
        private ISetting CreateOutputStateSetting()
        {
            return new BooleanTypeSetting("OutputState",
                                          "OUTP?",
                                          "ON",
                                          "OFF",
                                          "OUTP ",
                                          false,
                                          null,
                                          null);
        }
        private ISetting CreateRangeSetting(string name, string commandPrefix, SettingReadType readType)
        {
            SettingLimits limits = CreateLimits(name, commandPrefix);
            ICollection<SettingChangeTrigger> preTriggers = _preTriggerFactory.Create(name);
            ICollection<SettingChangeTrigger> postTriggers = _postTriggerFactory.Create(name);
            return new RangeTypeSetting(name,
                                        commandPrefix += "?",
                                        readType,
                                        limits,
                                        commandPrefix += " ",
                                        false,
                                        preTriggers,
                                        postTriggers);
        }
        private ISetting CreateOptionsSetting(string name, string commandPrefix, SettingReadType readType, bool readAllRequired)
        {
            ICollection<SettingChangeTrigger> preTriggers = _preTriggerFactory.Create(name);
            ICollection<SettingChangeTrigger> postTriggers = _postTriggerFactory.Create(name);
            SettingOptions options = _optionsFactory.Create(name);
            return new OptionTypeSetting(name,
                                         commandPrefix += "?",
                                         SettingReadType.String,
                                         options,
                                         commandPrefix += " ",
                                         readAllRequired,
                                         preTriggers,
                                         postTriggers);
        }
        private ISetting CreateListSetting(string name, string commandPrefix, SettingReadType readType, bool readAllRequired)
        {
            ICollection<SettingChangeTrigger> preTriggers = _preTriggerFactory.Create(name);
            ICollection<SettingChangeTrigger> postTriggers = _postTriggerFactory.Create(name);
            SettingOptions options = _optionsFactory.Create(name);
            return new ListTypeSetting(name,
                                       commandPrefix += "?",
                                       readType,
                                       options,
                                       commandPrefix += " ",
                                       readAllRequired,
                                       preTriggers,
                                       postTriggers);
        }
        private SettingLimits CreateLimits(string settingName, string commandPrefix)
        {
            return new SettingLimits(settingName, commandPrefix += "?MAX", commandPrefix += "?MIN");
        }
    }
}
