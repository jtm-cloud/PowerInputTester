using PowerInputTester.Models;
using System.Collections.Generic;

namespace PowerInputTester.Abstract
{
    public interface IInstrumentSubPanel
    {
        IList<Setting> Settings { get; set; }
    }
}
