
namespace PowerInputTester.Hardware.Models
{
    public class SettingChangeTrigger
    {
        public bool Exposed { get; }
        public string ReferenceName { get; }
        public string TargetName { get; }
        public object TargetValue { get; }
        public object TriggerValue { get; }
        public SettingChangeTrigger(string referenceName, object triggerValue, string targetName, object targetValue,
                                    bool exposed)
        {
            ReferenceName = referenceName;
            TriggerValue = triggerValue;
            TargetName = targetName;
            TargetValue = targetValue;
            Exposed = exposed;
        }
    }
}
