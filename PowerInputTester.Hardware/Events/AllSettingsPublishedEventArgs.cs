using PowerInputTester.Hardware.Abstract;
using System;
using System.Collections.Generic;

namespace PowerInputTester.Hardware.Events
{
    public class AllSettingsPublishedEventArgs : EventArgs
    {
        private readonly ICollection<ISetting> _settings;
        public ICollection<ISetting> Settings { get; }
        public AllSettingsPublishedEventArgs(ICollection<ISetting> settings)
        {
            _settings = settings;
        }
    }
}
