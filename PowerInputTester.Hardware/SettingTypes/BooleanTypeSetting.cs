using PowerInputTester.Hardware.Abstract;
using PowerInputTester.Hardware.Models;
using System.Collections.Generic;

namespace PowerInputTester.Hardware.SettingTypes
{
    public class BooleanTypeSetting : ISetting
    {
        public bool Disabled { get; set; }
        public string FalseValueName { get; }
        public string Name { get; }
        public ICollection<SettingChangeTrigger> PreTriggers { get; }
        public bool ReadAllRequired { get; }
        public string ReadCommand { get; }
        public SettingReadType ReadType { get; }
        public string SetCommand { get; }
        public ICollection<SettingChangeTrigger> PostTriggers { get; }
        public string TrueValueName { get; }
        public object Value { get; set; }
        public BooleanTypeSetting(string name,
                                  string readCommand,
                                  string trueValueName,
                                  string falseValueName,
                                  string setCommand = null,
                                  bool readAllRequired = false,
                                  ICollection<SettingChangeTrigger> preTriggers = null,
                                  ICollection<SettingChangeTrigger> postTriggers = null)
        {
            Name = name;
            ReadCommand = readCommand;
            ReadType = SettingReadType.Boolean;
            TrueValueName = trueValueName;
            FalseValueName = falseValueName;
            SetCommand = setCommand;
            ReadAllRequired = readAllRequired;
            PreTriggers = preTriggers;
            PostTriggers = postTriggers;
        }
    }
}
