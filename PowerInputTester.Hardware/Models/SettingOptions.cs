using PowerInputTester.Hardware.Abstract;
using System.Collections.Generic;

namespace PowerInputTester.Hardware.Models
{
    public class SettingOptions
    {
        public ICollection<SettingOption> Options { get; set; }
        public bool Predefined { get; }
        public string ReadCommand { get; }
        public SettingReadType ReadType { get; }
        public string SettingName { get; }
        public SettingOptions(string settingName,
                              bool predefined,
                              string readCommand = null,
                              SettingReadType readType = 0,
                              ICollection<SettingOption> options = null)
        {
            SettingName = settingName;
            Predefined = predefined;
            ReadCommand = readCommand;
            ReadType = readType;
            Options = options;
        }
    }
}
