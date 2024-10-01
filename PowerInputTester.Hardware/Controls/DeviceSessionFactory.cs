using CommonHelpers.GuardClauses;
using Ivi.Visa;
using NationalInstruments.Visa;
using PowerInputTester.Hardware.Models;

namespace PowerInputTester.Hardware.Controls
{
    public class DeviceSessionFactory
    {
        public MessageBasedSession Create(IResourceManager manager, InstrumentInfo info)
        {
            GuardClause.NullReference(manager, "manager");
            GuardClause.NullReference(info, "info");
            SerialSession session;

            switch (info.InterfaceType)
            {

                case HardwareInterfaceType.Serial:
                    session = (SerialSession)manager.Open(info.Address);
                    session.BaudRate = info.SerialConfig.BaudRate;
                    session.DataBits = info.SerialConfig.DataBits;
                    session.StopBits = info.SerialConfig.StopBits;
                    session.FlowControl = info.SerialConfig.FlowControl;
                    return (MessageBasedSession)session;

                default:
                    return (MessageBasedSession)manager.Open(info.Address);
            }
        }
    }
}
