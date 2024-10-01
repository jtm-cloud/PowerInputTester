using PowerInputTester.Hardware.Controls;

namespace PowerInputTester.UI.Events
{
    public class DeviceConnectRequestEventArgs
    {
        private readonly InstrumentType _instrumentType;
        public DeviceConnectRequestEventArgs(InstrumentType instrumentType)
        {
            _instrumentType = instrumentType;
        }
        public InstrumentType InstrumentType { get { return _instrumentType; } }
    }
}
