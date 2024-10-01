using CommonHelpers.GuardClauses;
using Ivi.Visa;
using PowerInputTester.Hardware.Controls;

namespace PowerInputTester.Hardware.Models
{
    public class InstrumentInfo
    {
        public string Address { get; }
        public InstrumentType InstrumentType { get; }
        public HardwareInterfaceType InterfaceType { get; }
        public string Manufacturer { get; }
        public string Model { get; }
        public string SerialNumber { get; }
        public SerialPortConfig SerialConfig { get; }
        public string SoftwareVersion { get; }
        public InstrumentInfo(string address,
                              HardwareInterfaceType interfaceType,
                              InstrumentType instrumentType,
                              string manufacturer = null,
                              string model = null,
                              string serialNumber = null,
                              string softwareVersion = null,
                              SerialPortConfig serialConfig = null)
        {
            GuardClause.EmptyString(address, "address");
            GuardClause.ZeroValue((int)interfaceType, "interfaceType");

            Address = address;
            InterfaceType = interfaceType;
            InstrumentType = instrumentType;
            Manufacturer = manufacturer;
            Model = model.Replace(" ", "");
            SerialNumber = serialNumber.Replace(" ", "");
            SoftwareVersion = softwareVersion;
            SerialConfig = serialConfig;
        }
    }
}
