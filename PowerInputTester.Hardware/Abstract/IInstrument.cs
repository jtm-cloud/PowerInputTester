using PowerInputTester.Hardware.Models;
using System;

namespace PowerInputTester.Hardware.Abstract
{
    public interface IInstrument : IDisposable
    {
        InstrumentInfo Info { get; }
    }
}
