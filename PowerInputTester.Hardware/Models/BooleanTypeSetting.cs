using PowerInputTester.Hardware.Abstract;
using System.Collections.Generic;

namespace PowerInputTester.Hardware.Models
{
    public class BooleanTypeSetting : ISetting
    {
        public bool IsVisible { get; }
        public string FalseValueName { get; }
        public string Name { get; }
        public ICollection<SettingChangeTrigger> Prerequisites { get; }
        public bool ReadAllRequired { get; }
        public string ReadCommand { get; }
        public SettingReadType ReadType { get; }
        public string SetCommand { get; }
        public ICollection<SettingChangeTrigger> SubsequentActions { get; }
        public string TrueValueName { get; }
        public object Value { get; set; }
        public BooleanTypeSetting(string name,
                                  string readCommand,
                                  bool isVisible,
                                  string trueValueName,
                                  string falseValueName,
                                  string setCommand = null,
                                  bool readAllRequired = false,
                                  ICollection<SettingChangeTrigger> prerequisites = null,
                                  ICollection<SettingChangeTrigger> subsequentActions = null)
        {
            Name = name;
            ReadCommand = readCommand;
            ReadType = SettingReadType.Boolean;
            IsVisible = isVisible;
            TrueValueName = trueValueName;
            FalseValueName = falseValueName;
            SetCommand = setCommand;
            ReadAllRequired = readAllRequired;
            Prerequisites = prerequisites;
            SubsequentActions = subsequentActions;
        }
    }
}
