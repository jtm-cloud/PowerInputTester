using PowerInputTester.Hardware.Models;
using System;

namespace PowerInputTester.UI.Models
{
    public class InstrumentSelectionEventArgs : EventArgs
    {
        private readonly InstrumentInfo _selectedInstrument;
        public InstrumentSelectionEventArgs(InstrumentInfo selectedInstrument)
        {
            _selectedInstrument = selectedInstrument;
        }
        public InstrumentInfo SelectedInstrument { get { return _selectedInstrument; } }
    }
}
