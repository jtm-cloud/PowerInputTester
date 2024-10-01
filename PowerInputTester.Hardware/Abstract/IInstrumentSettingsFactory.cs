using System.Collections.Generic;

namespace PowerInputTester.Hardware.Abstract
{
    public interface IInstrumentSettingsFactory
    {
        IDictionary<string, ISetting> Create();
    }
}
