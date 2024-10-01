using Ivi.Visa;
using PowerInputTester.Hardware.Abstract;
using PowerInputTester.Hardware.Controls;
using PowerInputTester.Hardware.Events;
using PowerInputTester.Hardware.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PowerInputTester.HardwareTest
{
    public class InstrumentManagerMockUp
    {
        #region Backing Fields
        ICollection<IInstrument> _activeInstruments;
        #endregion
        public InstrumentManagerMockUp()
        {
            _activeInstruments = new Collection<IInstrument>();
        }
        public ICollection<InstrumentInfo> FindInstruments(InstrumentType instrumentType)
        {
            return new Collection<InstrumentInfo>()
            {
                new InstrumentInfo("GPIB::1::0::INSTR", HardwareInterfaceType.Gpib, instrumentType, "California Instruments",
                                   "CSW5000", "A389Z20", "Version 2.2a", null),
                new InstrumentInfo("GPIB::3::0::INSTR", HardwareInterfaceType.Gpib, instrumentType, "California Instruments",
                                   "3001ix", "A389Z20", "Version 2.2a", null)
        };
        }
        public InstrumentEventHandler GetInstrumentHandler(InstrumentInfo instrumentInfo)
        {
            InstrumentEventHandler handler = new InstrumentEventHandler();
            InstrumentFactory factory = new InstrumentFactory();

            IInstrument instrument = new CIPowerSupplyMockUp(instrumentInfo, handler);

            _activeInstruments.Add(instrument);
            return handler;
        }
        public void DisconnectDevice(InstrumentType instrumentType)
        {
            foreach (IInstrument instrument in _activeInstruments)
            {
                if (instrument.Info.InstrumentType == instrumentType)
                {
                    instrument.Dispose();
                    _activeInstruments.Remove(instrument);
                    break;
                }
            }
        }
    }
}
