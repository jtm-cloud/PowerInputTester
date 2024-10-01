using PowerInputTester.Hardware.Events;

namespace PowerInputTester.Hardware.Models
{
    public class DeviceConnectionPacket
    {
        private readonly InstrumentEventHandler _handler;
        private readonly InstrumentInfo _info;
        InstrumentEventHandler Handler { get { return _handler; } }
        InstrumentInfo Info { get { return _info; } }
        public DeviceConnectionPacket(InstrumentInfo info, InstrumentEventHandler handler)
        {
            _info = info;
            _handler = handler;
        }
    }
}
