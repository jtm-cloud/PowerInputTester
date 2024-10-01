using PowerInputTester.Hardware.Controls;

namespace PowerInputTester.UI.Events
{
    public class InstrumentControlViewChangeEventArgs
    {
        #region Backing Fields

        private readonly bool _enabled;
        private readonly InstrumentType _instrumentType;

        #endregion

        public bool Enabled { get { return _enabled; } }
        public InstrumentType InstrumentType { get { return _instrumentType; } }

        public InstrumentControlViewChangeEventArgs(InstrumentType instrumentType, bool enabled)
        {
            _instrumentType = instrumentType;
            _enabled = enabled;
        }
    }
}
