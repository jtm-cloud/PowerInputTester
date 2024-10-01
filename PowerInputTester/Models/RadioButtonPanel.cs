using PowerInputTester.Abstract;
using System.Collections.Generic;

namespace PowerInputTester.Models
{
    public class RadioButtonPanel : IInstrumentSubPanel
    {
        public string Header { get; }
        public IList<Setting> Settings { get; set; }
        public RadioButtonPanel(string header, IList<Setting> settings)
        {
            Header = header;
            Settings = settings;
        }
    }
}
