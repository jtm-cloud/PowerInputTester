using PowerInputTester.Hardware.Abstract;
using PowerInputTester.Hardware.Models;
using System.Collections.Generic;

namespace PowerInputTester.Hardware.SettingTypes
{
    public class RangeTypeSetting : ISetting
    {
        public bool Disabled { get; set; }
        public SettingLimits Limits { get; set; }
        public string Name { get; }
        public ICollection<SettingChangeTrigger> PreTriggers { get; }
        public bool ReadAllRequired { get; }
        public string ReadCommand { get; }
        public SettingReadType ReadType { get; }
        public string SetCommand { get; }
        public ICollection<SettingChangeTrigger> PostTriggers { get; }
        public object Value { get; set; }
        public RangeTypeSetting(string name,
                                string readCommand,
                                SettingReadType readType,
                                SettingLimits limits,
                                string setCommand = null,
                                bool readAllRequired = false,
                                ICollection<SettingChangeTrigger> preTriggers = null,
                                ICollection<SettingChangeTrigger> postTriggers = null)
        {
            Name = name;
            ReadCommand = readCommand;
            ReadType = readType;
            Limits = limits;
            SetCommand = setCommand;
            ReadAllRequired = readAllRequired;
            PreTriggers = preTriggers;
            PostTriggers = postTriggers;
        }
    }

}
