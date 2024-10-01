using PowerInputTester.Hardware.Controls;

namespace PowerInputTester.UI.Abstract
{
    public interface IInstrumentControlContainer
    {
        InstrumentType InstrumentType { get; }
        bool Enabled { get; }
    }
}
