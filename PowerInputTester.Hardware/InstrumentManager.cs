using CommonHelpers.GuardClauses;
using Ivi.Visa;
using NationalInstruments.Visa;
using PowerInputTester.Hardware.Abstract;
using PowerInputTester.Hardware.Controls;
using PowerInputTester.Hardware.Events;
using PowerInputTester.Hardware.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PowerInputTester.Hardware
{
    public class InstrumentManager
    {
        #region Backing Fields
        ICollection<IInstrument> _activeInstruments;
        IResourceManager _manager;
        #endregion
        public InstrumentManager()
        {
            _manager = new ResourceManager();
            _activeInstruments = new Collection<IInstrument>();
        }
        public ICollection<InstrumentInfo> FindInstruments(InstrumentType instrumentType)
        {
            ICollection<string> addresses;
            try
            {
                addresses = _manager.Find("?*INSTR").ToList();
                if (addresses.Count != 0)
                {
                    ICollection<InstrumentInfo> instruments = new Collection<InstrumentInfo>();
                    InstrumentInfoFactory factory = new InstrumentInfoFactory();

                    foreach (string address in addresses)
                    {
                        InstrumentInfo info = factory.Create(_manager, address);
                        if ((info != null) && (info.InstrumentType == instrumentType))
                        {
                            instruments.Add(info);
                        }
                    }

                    return instruments;
                }
                else
                {
                    return null;
                }
            }
            catch (VisaException e)
            {
                string message = e.Message;
                return null;
            }
        }
        public InstrumentEventHandler GetInstrumentHandler(InstrumentInfo instrumentInfo)
        {
            GuardClause.NullReference(instrumentInfo, "instrumentInfo");

            InstrumentEventHandler handler = new InstrumentEventHandler();
            InstrumentFactory factory = new InstrumentFactory();

            IInstrument instrument = factory.Create(_manager, instrumentInfo, handler);
            GuardClause.NullReference(instrument, "instrument");

            _activeInstruments.Add(instrument);
            return handler;
        }
    }
}
