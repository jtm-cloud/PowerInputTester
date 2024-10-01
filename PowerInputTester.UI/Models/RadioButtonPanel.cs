using System.Collections.Generic;

namespace PowerInputTester.UI.Models
{
    public class RadioButtonPanel
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
