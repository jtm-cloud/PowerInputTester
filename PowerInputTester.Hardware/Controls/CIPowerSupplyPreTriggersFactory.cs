using PowerInputTester.Hardware.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PowerInputTester.Hardware.Controls
{
    public class CIPowerSupplyPreTriggersFactory
    {
        public ICollection<SettingChangeTrigger> Create(string settingName)
        {
            switch (settingName)
            {
                case "OutputNumber":
                    return CreateOutputNumberTriggers();
                case "OutputMode":
                    return CreateOutputModeTriggers();
                case "VoltageRange":
                    return CreateVoltageRangeTriggers();
                case "OutputCoupling":
                    return CreateOutputCouplingTriggers();
                case "VoltageA":
                    return CreateVoltageATriggers();
                case "VoltageB":
                    return CreateVoltageBTriggers();
                case "VoltageC":
                    return CreateVoltageCTriggers();
                case "FrequencyA":
                    return CreateFrequencyATriggers();
                case "FrequencyB":
                    return CreateFrequencyBTriggers();
                case "FrequencyC":
                    return CreateFrequencyCTriggers();
                case "CurrentLimit":
                    return CreateCurrentLimitTriggers();
                case "WaveformShape":
                    return CreateWaveformShapeTriggers();
                case "ClipLevel":
                    return CreateClipLevelTriggers();
                default:
                    return null;
            }
        }
        private ICollection<SettingChangeTrigger> CreateOutputNumberTriggers()
        {
            ICollection<SettingChangeTrigger> preTriggers = new Collection<SettingChangeTrigger>()
            {
                new SettingChangeTrigger("OutputNumber", "Any", "OutputState", false, false)
            };
            return preTriggers;
        }
        private ICollection<SettingChangeTrigger> CreateOutputModeTriggers()
        {
            ICollection<SettingChangeTrigger> preTriggers = new Collection<SettingChangeTrigger>()
            {
                new SettingChangeTrigger("OutputMode", "Any", "OutputState", false, false)
            };
            return preTriggers;
        }
        private ICollection<SettingChangeTrigger> CreateVoltageRangeTriggers()
        {
            ICollection<SettingChangeTrigger> preTriggers = new Collection<SettingChangeTrigger>()
            {
                new SettingChangeTrigger("VoltageRange", "Any", "OutputState", false, false)
            };
            return preTriggers;
        }
        private ICollection<SettingChangeTrigger> CreateOutputCouplingTriggers()
        {
            return null;
        }
        private ICollection<SettingChangeTrigger> CreateVoltageATriggers()
        {
            ICollection<SettingChangeTrigger> preTriggers = new Collection<SettingChangeTrigger>()
            {
                new SettingChangeTrigger("VoltageA", "Any", "PhaseSelection", 1, true)
            };
            return preTriggers;
        }
        private ICollection<SettingChangeTrigger> CreateVoltageBTriggers()
        {
            ICollection<SettingChangeTrigger> preTriggers = new Collection<SettingChangeTrigger>()
            {
                new SettingChangeTrigger("VoltageB", "Any", "PhaseSelection", 2, true)
            };
            return preTriggers;
        }
        private ICollection<SettingChangeTrigger> CreateVoltageCTriggers()
        {
            ICollection<SettingChangeTrigger> preTriggers = new Collection<SettingChangeTrigger>()
            {
                new SettingChangeTrigger("VoltageC", "Any", "PhaseSelection", 3, true)
            };
            return preTriggers;
        }
        private ICollection<SettingChangeTrigger> CreateFrequencyATriggers()
        {
            ICollection<SettingChangeTrigger> preTriggers = new Collection<SettingChangeTrigger>()
            {
                new SettingChangeTrigger("FrequencyA", "Any", "PhaseSelection", 1, true)
            };
            return preTriggers;
        }
        private ICollection<SettingChangeTrigger> CreateFrequencyBTriggers()
        {
            ICollection<SettingChangeTrigger> preTriggers = new Collection<SettingChangeTrigger>()
            {
                new SettingChangeTrigger("FrequencyB", "Any", "PhaseSelection", 2, true)
            };
            return preTriggers;
        }
        private ICollection<SettingChangeTrigger> CreateFrequencyCTriggers()
        {
            ICollection<SettingChangeTrigger> preTriggers = new Collection<SettingChangeTrigger>()
            {
                new SettingChangeTrigger("FrequencyC", "Any", "PhaseSelection", 3, true)
            };
            return preTriggers;
        }
        private ICollection<SettingChangeTrigger> CreateCurrentLimitTriggers()
        {
            return null;
        }
        private ICollection<SettingChangeTrigger> CreateWaveformShapeTriggers()
        {
            return null;
        }
        private ICollection<SettingChangeTrigger> CreateClipLevelTriggers()
        {
            return null;
        }
    }
}
