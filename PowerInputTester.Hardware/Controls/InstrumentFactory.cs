using CommonHelpers.GuardClauses;
using Ivi.Visa;
using NationalInstruments.Visa;
using PowerInputTester.Hardware.Abstract;
using PowerInputTester.Hardware.Events;
using PowerInputTester.Hardware.Instruments;
using PowerInputTester.Hardware.Models;
using System.Linq;

namespace PowerInputTester.Hardware.Controls
{
    public class InstrumentFactory
    {
        private DeviceSessionFactory _factory;
        public InstrumentFactory()
        {
            _factory = new DeviceSessionFactory();
        }
        public IInstrument Create(IResourceManager manager, InstrumentInfo info, InstrumentEventHandler handler)
        {
            string referenceString = string.Concat(info.Manufacturer.Where(c => !char.IsWhiteSpace(c))).ToUpper();
            if (referenceString.Contains("CALIFORNIA"))
            {
                return CreateCaliforniaInstrumentsDevice(manager, info, handler);
            }
            else if (referenceString.Contains("KEYSIGHT"))
            {
                return CreateKeysightDevice(manager, info, handler);
            }
            else if (referenceString.Contains("RIGOL"))
            {
                return CreateRigolDevice(manager, info, handler);
            }
            else if (referenceString.Contains("TEKTRONIX"))
            {
                return CreateTektronixDevice(manager, info, handler);
            }
            else
            {
                return null;
            }
        }
        private IInstrument CreateCaliforniaInstrumentsDevice(IResourceManager manager, InstrumentInfo info, InstrumentEventHandler handler)
        {
            string referenceString = string.Concat(info.Model.Where(c => !char.IsWhiteSpace(c))).ToUpper();
            if ((referenceString.Contains("CSW5550")) || (referenceString.Contains("3001IX")))
            {
                MessageBasedSession session = _factory.Create(manager, info);
                GuardClause.NullReference(session, "session");

                return new CIPowerSupply(session, info, handler);
            }
            else
            {
                return null;
            }
        }
        private IInstrument CreateKeysightDevice(IResourceManager manager, InstrumentInfo info, InstrumentEventHandler handler)
        {
            string referenceString = string.Concat(info.Model.Where(c => !char.IsWhiteSpace(c))).ToUpper();
            if (referenceString.Contains("N9010A"))
            {
                return null;
            }
            else if (referenceString.Contains("N9020A"))
            {
                return null;
            }
            else if (referenceString.Contains("DSOX3052T"))
            {
                return null;
            }
            else
            {
                return null;
            }
        }
        private IInstrument CreateRigolDevice(IResourceManager manager, InstrumentInfo info, InstrumentEventHandler handler)
        {
            string referenceString = string.Concat(info.Model.Where(c => !char.IsWhiteSpace(c))).ToUpper();
            if ((referenceString.Contains("DSG815")) || (referenceString.Contains("DSG-815")))
            {
                return null;
            }
            else if ((referenceString.Contains("DSA815")) || (referenceString.Contains("DSA-815")))
            {
                return null;
            }
            else
            {
                return null;
            }
        }
        private IInstrument CreateTektronixDevice(IResourceManager manager, InstrumentInfo info, InstrumentEventHandler handler)
        {
            string referenceString = string.Concat(info.Model.Where(c => !char.IsWhiteSpace(c))).ToUpper();
            if (referenceString.Contains("TDS2014B"))
            {
                return null;
            }
            else if (referenceString.Contains("TDS2024C"))
            {
                return null;
            }
            else
            {
                return null;
            }
        }
    }
}
