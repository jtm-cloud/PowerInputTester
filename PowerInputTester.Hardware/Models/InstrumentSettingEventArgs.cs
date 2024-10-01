﻿using System;

namespace PowerInputTester.Hardware.Models
{
    public class InstrumentSettingEventArgs : EventArgs
    {
        public string SettingName { get; }
        public object Value { get; }
        public InstrumentSettingEventArgs(string settingName, object value)
        {
            SettingName = settingName;
            Value = value;
        }
    }
}