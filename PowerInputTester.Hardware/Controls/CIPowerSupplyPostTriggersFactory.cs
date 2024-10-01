using PowerInputTester.Hardware.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PowerInputTester.Hardware.Controls
{
    public class CIPowerSupplyPostTriggersFactory
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
            ICollection<SettingChangeTrigger> postTriggers = new Collection<SettingChangeTrigger>()
            {
                new SettingChangeTrigger("OutputMode", "DC", "Voltage", 28, false),
                new SettingChangeTrigger("OutputMode", "AC", "Voltage", 115, false),
                new SettingChangeTrigger("OutputMode", "ACDC", "Voltage", 115, false)
            };
            return postTriggers;
        }
        private ICollection<SettingChangeTrigger> CreateOutputModeTriggers()
        {
            ICollection<SettingChangeTrigger> postTriggers = new Collection<SettingChangeTrigger>()
            {
                new SettingChangeTrigger("OutputMode", "DC", "Voltage", 28, false),
                new SettingChangeTrigger("OutputMode", "AC", "Voltage", 115, false),
                new SettingChangeTrigger("OutputMode", "ACDC", "Voltage", 115, false)
            };
            return postTriggers;
        }
        private ICollection<SettingChangeTrigger> CreateVoltageRangeTriggers()
        {
            ICollection<SettingChangeTrigger> postTriggers = new Collection<SettingChangeTrigger>()
            {
                new SettingChangeTrigger("OutputMode", "DC", "Voltage", 28, false),
                new SettingChangeTrigger("OutputMode", "AC", "Voltage", 115, false),
                new SettingChangeTrigger("OutputMode", "ACDC", "Voltage", 115, false)
            };
            return postTriggers;
        }
        private ICollection<SettingChangeTrigger> CreateOutputCouplingTriggers()
        {
            return null;
        }
        private ICollection<SettingChangeTrigger> CreateVoltageATriggers()
        {
            ICollection<SettingChangeTrigger> postTriggers = new Collection<SettingChangeTrigger>()
            {
                new SettingChangeTrigger("OutputCoupling", "ALL", "VoltageB", null, true),
                new SettingChangeTrigger("OutputCoupling", "ALL", "VoltageC", null, true),
            };
            return postTriggers;
        }
        private ICollection<SettingChangeTrigger> CreateVoltageBTriggers()
        {
            ICollection<SettingChangeTrigger> postTriggers = new Collection<SettingChangeTrigger>()
            {
                new SettingChangeTrigger("OutputCoupling", "ALL", "VoltageA", null, true),
                new SettingChangeTrigger("OutputCoupling", "ALL", "VoltageC", null, true),
            };
            return postTriggers;
        }
        private ICollection<SettingChangeTrigger> CreateVoltageCTriggers()
        {
            ICollection<SettingChangeTrigger> postTriggers = new Collection<SettingChangeTrigger>()
            {
                new SettingChangeTrigger("OutputCoupling", "ALL", "VoltageA", null, true),
                new SettingChangeTrigger("OutputCoupling", "ALL", "VoltageB", null, true),
            };
            return postTriggers;
        }
        private ICollection<SettingChangeTrigger> CreateFrequencyATriggers()
        {
            return null;
        }
        private ICollection<SettingChangeTrigger> CreateFrequencyBTriggers()
        {
            return null;
        }
        private ICollection<SettingChangeTrigger> CreateFrequencyCTriggers()
        {
            return null;
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
            ICollection<SettingChangeTrigger> postTriggers = new Collection<SettingChangeTrigger>()
            {
                new SettingChangeTrigger("ClipLevel", "Any", "Voltage", "Current", false)
            };
            return postTriggers;
        }
    }
}
