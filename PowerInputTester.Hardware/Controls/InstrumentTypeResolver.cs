using System.Linq;

namespace PowerInputTester.Hardware.Controls
{
    public enum InstrumentType
    {
        None,
        Oscilloscope,
        PowerSupply,
        SpectrumAnalyzer,
        SignalGenerator
    }
    public class InstrumentTypeResolver
    {
        public InstrumentType Resolve(string manufacturer, string model)
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
                return ResolveKeysightDevice(model);
            }
            else if (referenceString.Contains("TEKTRONIX"))
            {
                return ResolveKeysightDevice(model);
            }
            else
            {
                return InstrumentType.None;
            }
        }
        private InstrumentType ResolveCaliforniaInstrumentsDevice(string model)
        {
            string referenceString = string.Concat(model.Where(c => !char.IsWhiteSpace(c))).ToUpper();
            if (referenceString.Contains("CSW5550"))
            {
                return InstrumentType.PowerSupply;
            }
            else if (referenceString.Contains("3001IX"))
            {
                return InstrumentType.PowerSupply;
            }
            else
            {
                return InstrumentType.None;
            }
        }
        private InstrumentType ResolveKeysightDevice(string model)
        {
            string referenceString = string.Concat(model.Where(c => !char.IsWhiteSpace(c))).ToUpper();
            if (referenceString.Contains("N9010A"))
            {
                return InstrumentType.SpectrumAnalyzer;
            }
            else if (referenceString.Contains("N9020A"))
            {
                return InstrumentType.SpectrumAnalyzer;
            }
            else if (referenceString.Contains("DSOX3052T"))
            {
                return InstrumentType.Oscilloscope;
            }
            else
            {
                return InstrumentType.None;
            }
        }
        private InstrumentType ResolveRigolDevice(string model)
        {
            string referenceString = string.Concat(model.Where(c => !char.IsWhiteSpace(c))).ToUpper();
            if ((referenceString.Contains("DSG815")) || (referenceString.Contains("DSG-815")))
            {
                return InstrumentType.SignalGenerator;
            }
            else if ((referenceString.Contains("DSA815")) || (referenceString.Contains("DSA-815")))
            {
                return InstrumentType.SpectrumAnalyzer;
            }
            else
            {
                return InstrumentType.None;
            }
        }
        private InstrumentType ResolveTektronixDevice(string model)
        {
            string referenceString = string.Concat(model.Where(c => !char.IsWhiteSpace(c))).ToUpper();
            if (referenceString.Contains("TDS2014B"))
            {
                return InstrumentType.Oscilloscope;
            }
            else if (referenceString.Contains("TDS2024C"))
            {
                return InstrumentType.Oscilloscope;
            }
            else
            {
                return InstrumentType.None;
            }
        }
    }
}
