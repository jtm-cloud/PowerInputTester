using CommonHelpers.GuardClauses;
using PowerInputTester.Hardware.Events;

namespace PowerInputTester.UI.Models
{
    public class WaveformShapeOptionsContainer
    {
        #region Backing Fields

        private string _enabledReferenceName;
        private InstrumentEventHandler _handler;

        #endregion

        public bool Enabled { get; set; }

        public string Phase { get; set; }

        public DropdownList WaveformShape { get; set; }

        public DropdownList ClipLevel { get; set; }

        public WaveformShapeOptionsContainer(string phase, string enabledReferenceName, InstrumentEventHandler handler)
        {
            GuardClause.EmptyString(phase, "phase");
            GuardClause.EmptyString(enabledReferenceName, "enabledReferenceName");
            GuardClause.NullReference(handler, "handler");

            Phase = phase;
            _enabledReferenceName = enabledReferenceName;
            _handler = handler;
            _handler.OnSettingEnabledChanged += _handler_OnSettingEnabledChanged;

            Enabled = true;
        }

        private void _handler_OnSettingEnabledChanged(object sender, SettingEnabledEventArgs e)
        {
            if (e.SettingName == _enabledReferenceName)
            {
                Enabled = e.Enabled;
            }
        }
    }
}
