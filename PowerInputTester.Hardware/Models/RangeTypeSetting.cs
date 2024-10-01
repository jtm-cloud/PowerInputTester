using PowerInputTester.Hardware.Abstract;
using System.Collections.Generic;

namespace PowerInputTester.Hardware.Models
{
    public class RangeTypeSetting : ISetting
    {
        public bool IsVisible { get; }
        public object Max { get; set; }
        public object Min { get; set; }
        public string Name { get; }
        public ICollection<SettingChangeTrigger> Prerequisites { get; }
        public string RangeLimitProviderName { get; }
        public bool ReadAllRequired { get; }
        public string ReadCommand { get; }
        public SettingReadType ReadType { get; }
        public string SetCommand { get; }
        public ICollection<SettingChangeTrigger> SubsequentActions { get; }
        public object Value { get; set; }
        public RangeTypeSetting(string name,
                                string readCommand,
                                SettingReadType readType,
                                bool isVisible,
                                string rangeLimitProviderName,
                                string setCommand = null,
                                bool readAllRequired = false,
                                ICollection<SettingChangeTrigger> prerequisites = null,
                                ICollection<SettingChangeTrigger> subsequentActions = null)
        {
            Name = name;
            ReadCommand = readCommand;
            ReadType = readType;
            IsVisible = isVisible;
            RangeLimitProviderName = rangeLimitProviderName;
            SetCommand = setCommand;
            ReadAllRequired = readAllRequired;
            Prerequisites = prerequisites;
            SubsequentActions = subsequentActions;
        }
    }
}
