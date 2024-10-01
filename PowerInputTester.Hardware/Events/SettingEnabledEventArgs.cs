using System;

namespace PowerInputTester.Hardware.Events
{
    public class SettingEnabledEventArgs : EventArgs
    {
        public string SettingName { get; }
        public bool Enabled { get; }
        public SettingEnabledEventArgs(string settingName, bool enabled)
        {
            SettingName = settingName;
            Enabled = enabled;
        }
    }
}
