using PowerInputTester.Hardware.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerInputTester.UI.Controls
{
    public static class InstrumentPanelFactory
    {
        public static ICollection<object> Create(InstrumentType instrumentType, ICollection<string> settings)
        {
            switch (instrumentType)
            {
                case InstrumentType.Oscilloscope:
                    return CreateOscilloscopeSettingPanels(settings);
                case InstrumentType.PowerSupply:
                    return CreatePowerSupplySettingPanels(settings);
                default:
                    return null;
            }
        }
        public static ICollection<object> CreatePowerSupplySettingPanels(ICollection<string> settings)
        {
            ICollection<object> panels = new Collection<object>();
            foreach(string setting in settings)
            {
                
            }
            return null;
        }
        public static ICollection<object> CreateOscilloscopeSettingPanels(ICollection<string> settings)
        {
            return null;
        }
    }
}
