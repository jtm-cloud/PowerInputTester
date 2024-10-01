using PowerInputTester.Hardware.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace PowerInputTester.Hardware.Controls
{
    public static class DeviceSettingsFactory
    {
        public static ICollection<ISetting> Create(string manufacturer, string model)
        {
            string referenceString = string.Concat(manufacturer.Where(c => !char.IsWhiteSpace(c))).ToUpper();
            if (referenceString.Contains("CALIFORNIA"))
            {
                return ResolveCaliforniaInstrumentsDevice(model);
            }
            else if (referenceString.Contains("KEYSIGHT"))
            {
                return ResolveKeysightDevice(model);
            }
            else if (referenceString.Contains("RIGOL"))
            {
                return ResolveRigolDevice(model);
            }
            else if (referenceString.Contains("TEKTRONIX"))
            {
                return ResolveTektronixDevice(model);
            }
            else
            {
                return null;
            }
        }
        private static ICollection<ISetting> ResolveCaliforniaInstrumentsDevice(string model)
        {
            string referenceString = string.Concat(model.Where(c => !char.IsWhiteSpace(c))).ToUpper();
            if ((referenceString.Contains("CSW5550")) || (referenceString.Contains("CSW5550")))
            {
                CIPowerSupplySettingsFactory factory = new CIPowerSupplySettingsFactory();
                return factory.Create();
            }
            else
            {
                return null;
            }
        }
        private static ICollection<ISetting> ResolveKeysightDevice(string model)
        {
            string referenceString = string.Concat(model.Where(c => !char.IsWhiteSpace(c))).ToUpper();
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
        private static ICollection<ISetting> ResolveRigolDevice(string model)
        {
            string referenceString = string.Concat(model.Where(c => !char.IsWhiteSpace(c))).ToUpper();
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
        private static ICollection<ISetting> ResolveTektronixDevice(string model)
        {
            string referenceString = string.Concat(model.Where(c => !char.IsWhiteSpace(c))).ToUpper();
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
