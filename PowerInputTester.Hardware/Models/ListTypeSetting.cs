using PowerInputTester.Hardware.Abstract;
using System.Collections.Generic;

namespace PowerInputTester.Hardware.Models
{
    public class ListTypeSetting : ISetting
    {
        public bool IsVisible { get; }
        public string ListProviderName { get; }
        public string Name { get; }
        public ICollection<object> ValueList { get; set; }
        public ICollection<SettingChangeTrigger> Prerequisites { get; }
        public bool ReadAllRequired { get; }
        public string ReadCommand { get; }
        public SettingReadType ReadType { get; }
        public string SetCommand { get; }
        public ICollection<SettingChangeTrigger> SubsequentActions { get; }
        public object Value { get; set; }
        public ListTypeSetting(string name,
                               string readCommand,
                               SettingReadType readType,
                               bool isVisible,
                               string listProviderName,
                               string setCommand = null,
                               bool readAllRequired = false,
                               ICollection<SettingChangeTrigger> prerequisites = null,
                               ICollection<SettingChangeTrigger> subsequentActions = null)
        {
            Name = name;
            ReadCommand = readCommand;
            ReadType = readType;
            IsVisible = isVisible;
            ListProviderName = listProviderName;
            SetCommand = setCommand;
            ReadAllRequired = readAllRequired;
            Prerequisites = prerequisites;
            SubsequentActions = subsequentActions;
        }
    }
}
