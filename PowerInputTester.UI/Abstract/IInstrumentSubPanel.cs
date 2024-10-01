using PowerInputTester.UI.Models;
using System.Collections.Generic;

namespace PowerInputTester.UI.Abstract
{
    public interface IInstrumentSubPanel
    {
        IList<Setting> Settings { get; set; }
    }
}
