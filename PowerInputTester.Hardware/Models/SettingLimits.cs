
namespace PowerInputTester.Hardware.Models
{
    public class SettingLimits
    {
        public object Max { get; set; }
        public string MaxReadCommand { get; }
        public object Min { get; set; }
        public string MinReadCommand { get; }
        public string SettingName { get; }
        public SettingLimits(string settingName, string maxReadCommand, string minReadCommand)
        {
            SettingName = settingName;
            MaxReadCommand = maxReadCommand;
            MinReadCommand = minReadCommand;
        }
    }
}
