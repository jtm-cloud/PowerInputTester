using PowerInputTester.Hardware.Abstract;
using System.Collections.Generic;

namespace PowerInputTester.Hardware.Models
{
    public class OptionTypeSetting : ISetting
    {
        public bool IsVisible { get; }
        public string Name { get; }
        public ICollection<SettingOption> Options { get; set; }
        public string OptionsProviderName { get; }
        public ICollection<SettingChangeTrigger> Prerequisites { get; }
        public bool ReadAllRequired { get; }
        public string ReadCommand { get; }
        public SettingReadType ReadType { get; }
        public string SetCommand { get; }
        public ICollection<SettingChangeTrigger> SubsequentActions { get; }
        public object Value { get; set; }
        public OptionTypeSetting(string name,
                                 string readCommand,
                                 SettingReadType readType,
                                 bool isVisible,
                                 string optionsProviderName,
                                 string setCommand = null,
                                 bool readAllRequired = false,
                                 ICollection<SettingChangeTrigger> prerequisites = null,
                                 ICollection<SettingChangeTrigger> subsequentActions = null)
        {
            Name = name;
            ReadCommand = readCommand;
            ReadType = readType;
            IsVisible = isVisible;
            OptionsProviderName = optionsProviderName;
            SetCommand = setCommand;
            ReadAllRequired = readAllRequired;
            Prerequisites = prerequisites;
            SubsequentActions = subsequentActions;
        }
    }
}
