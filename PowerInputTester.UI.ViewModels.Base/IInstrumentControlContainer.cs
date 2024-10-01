using PowerInputTester.Hardware.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerInputTester.UI.ViewModels.Base
{
    public interface IInstrumentControlContainer
    {
        InstrumentType InstrumentType { get; }
        bool Enabled { get; }
    }
}
