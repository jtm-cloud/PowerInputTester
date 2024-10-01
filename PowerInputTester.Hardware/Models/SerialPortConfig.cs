using Ivi.Visa;

namespace PowerInputTester.Hardware.Models
{
    public class SerialPortConfig
    {
        public int BaudRate { get; }
        public short DataBits { get; }
        public SerialFlowControlModes FlowControl { get; }
        public SerialParity Parity { get; }
        public SerialStopBitsMode StopBits { get; }
        public SerialPortConfig(int baudRate,
                                short dataBits = 8,
                                SerialStopBitsMode stopBits = SerialStopBitsMode.One,
                                SerialFlowControlModes flowControl = SerialFlowControlModes.None)
        {
            BaudRate = baudRate;
            DataBits = dataBits;
            StopBits = stopBits;
            FlowControl = flowControl;
        }
    }
}
