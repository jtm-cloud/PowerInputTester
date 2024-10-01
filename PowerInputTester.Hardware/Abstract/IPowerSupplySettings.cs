using PowerInputTester.Hardware.Models;
using System;
using System.Collections.Generic;

namespace PowerInputTester.Hardware.Abstract
{
    public interface IPowerSupplySettings : IDisposable
    {
        float ClipLevelA { get; set; }
        float ClipLevelB { get; set; }
        float ClipLevelC { get; set; }
        ICollection<float> ClipLevelList { get; }
        float CurrentLimit { get; set; }
        SettingRange CurrentLimitRange { get; }
        float FrequencyA { get; set; }
        float FrequencyB { get; set; }
        float FrequencyC { get; set; }
        SettingRange FrequencyRange { get; }
        string OutputCoupling { get; set; }
        string OutputMode { get; set; }
        string OutputNumber { get; set; }
        bool OutputState { get; set; }
        string PhaseSelection { get; set; }
        float VoltageA { get; set; }
        float VoltageB { get; set; }
        float VoltageC { get; set; }
        float VoltageRange { get; set; }
        SettingRange VoltageRangeList { get; }
        string WaveformShapeA { get; set; }
        string WaveformShapeB { get; set; }
        string WaveformShapeC { get; set; }
        ICollection<string> WaveformShapeList { get; }
    }
}
