using PowerInputTester.Hardware.Abstract;
using PowerInputTester.Hardware.Models;
using System.Collections.Generic;

namespace PowerInputTester.Hardware.SettingTypes
{
    public class ListTypeSetting : ISetting
    {
        public bool Disabled { get; set; }
        public string ListProviderName { get; }
        public string Name { get; }
        public SettingOptions Options { get; set; }
        public ICollection<SettingChangeTrigger> PreTriggers { get; }
        public bool ReadAllRequired { get; }
        public string ReadCommand { get; }
        public SettingReadType ReadType { get; }
        public string SetCommand { get; }
        public ICollection<SettingChangeTrigger> PostTriggers { get; }
        public object Value { get; set; }
        public string ValueListReadCommand { get; }
        public ListTypeSetting(string name,
                               string readCommand,
                               SettingReadType readType,
                               SettingOptions options,
                               string setCommand = null,
                               bool readAllRequired = false,
                               ICollection<SettingChangeTrigger> preTriggers = null,
                               ICollection<SettingChangeTrigger> postTriggers = null)
        {
            Name = name;
            ReadCommand = readCommand;
            ReadType = readType;
            Options = options;
            SetCommand = setCommand;
            ReadAllRequired = readAllRequired;
            PreTriggers = preTriggers;
            PostTriggers = postTriggers;
        }
    }

}
