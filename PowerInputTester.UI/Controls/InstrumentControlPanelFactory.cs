using PowerInputTester.Hardware.Abstract;
using PowerInputTester.Hardware.Controls;
using PowerInputTester.Hardware.Models;
using PowerInputTester.UI.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerInputTester.UI.Controls
{
    public class InstrumentControlPanelFactory
    {
        public ICollection<IInstrumentControlPanel> Create(InstrumentType instrumentType, ICollection<ISetting> settings)
        {
            switch (instrumentType)
            {
                case InstrumentType.None:
                    return null;
                case InstrumentType.Oscilloscope:
                    return null;
                case InstrumentType.PowerSupply:
                    return null;
                case InstrumentType.SignalGenerator:
                    return null;
                case InstrumentType.SpectrumAnalyzer:
                    return null;
                default:
                    return null;
            }
        }
        private ICollection<IInstrumentControlPanel> CreatePowerSupplyPanels(ICollection<ISetting> settings)
        {
            foreach(ISetting setting in settings)
            {

            }
            return null;
        }
    }
}
