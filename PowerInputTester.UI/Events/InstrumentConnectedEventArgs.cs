using PowerInputTester.Hardware.Controls;
using PowerInputTester.Hardware.Events;
using System;

namespace PowerInputTester.UI.Events
{
    public class InstrumentConnectedEventArgs : EventArgs
    {
        private readonly InstrumentEventHandler _handler;
        private readonly InstrumentType _instrumentType;
        public InstrumentConnectedEventArgs(InstrumentType instrumentType, InstrumentEventHandler handler)
        {
            _instrumentType = instrumentType;
            _handler = handler;
        }
        public InstrumentEventHandler Handler { get { return _handler; } }
        public InstrumentType InstrumentType { get { return _instrumentType; } }
    }
}
