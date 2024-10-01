using PowerInputTester.Abstract;
using System;
using System.Collections.Generic;

namespace PowerInputTester.Controls
{
    public class InstrumentPanelVMFactory : IDisposable
    {
        public IList<IInstrumentSubPanel> Create(string instrumentType, object handler)
        {
            switch (instrumentType)
            {
                case "Power Supply":
                    return null;
                case "Oscilloscope":
                    return null;
                default:
                    return null;
            }
        }
        public IList<IInstrumentSubPanel> CreateOscilloscopeVMs(object handler)
        {
            return null;
        }
        public IList<IInstrumentSubPanel> CreatePowerSupplyVMs(object handler)
        {
            return null;
        }
        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }
    }
}
