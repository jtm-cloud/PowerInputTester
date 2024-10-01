
namespace PowerInputTester.Hardware.Models
{
    public class SettingOption
    {
        public string Name { get; set; }
        public string SettingName { get; set; }
        public SettingOption(string name, string settingName)
        {
            Name = name;
            SettingName = settingName;
        }
    }
}
