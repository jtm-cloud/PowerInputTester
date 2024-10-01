using PowerInputTester.Hardware.Abstract;
using System.Collections.Generic;

namespace PowerInputTester.Hardware.Models
{
    public class Setting
    {
        public string Name { get; }
        public List<SettingChangeTrigger> Prerequisites { get; }
        public string ReadCommand { get; }
        public SettingReadType ReadType { get; }
        public string SetCommand { get; }
        public List<SettingChangeTrigger> SubsequentActions { get; }
        public object Value { get; set; }
        public Setting(string name, string readCommand, SettingReadType readType, string setCommand = null,
                       List<SettingChangeTrigger> prerequisites = null,
                       List<SettingChangeTrigger> subsequentActions = null)
        {
            Name = name;
            ReadCommand = readCommand;
            ReadType = readType;
            SetCommand = setCommand;
            Prerequisites = prerequisites;
            SubsequentActions = subsequentActions;
        }
    }
}
