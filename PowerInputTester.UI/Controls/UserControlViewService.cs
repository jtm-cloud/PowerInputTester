using CommonHelpers.GuardClauses;
using PowerInputTester.Hardware.Events;
using PowerInputTester.UI.Events;
using System.Windows;

namespace PowerInputTester.UI.Controls
{
    public class UserControlViewService
    {
        #region Backing Fields

        private UIEventHandler _handler;
        private InstrumentEventHandler _instrumentHandler;
        

        #endregion

        public UserControlViewService(UIEventHandler handler)
        {
            GuardClause.NullReference(handler, "handler");

            _handler = handler;
            _handler.OnMenuBarItemSelected += _handler_OnMenuBarItemSelected;
            //_handler.OnSideDockItemSelected += _handler_OnSideDockItemSelected;
            _handler.OnInstallHandlerRequested += _handler_OnInstallHandlerRequested;
        }

        private void _handler_OnInstallHandlerRequested(object sender, InstallHandlerEventArgs e)
        {
            _instrumentHandler = (InstrumentEventHandler)e.Handler;
        }

        //private void _handler_OnSideDockItemSelected(object sender, UISelectionEventArgs e)
        //{
        //    switch (e.Name)
        //    {
        //        case "Test Info":
        //            _instrumentHandler?.RaiseSettingEnabledChanged(new SettingEnabledEventArgs("CurrentLimit", false));
        //            break;
        //        case "EUT Configuration":
        //            _instrumentHandler?.RaiseSettingEnabledChanged(new SettingEnabledEventArgs("CurrentLimit", true));
        //            break;
        //        case "Subtests":
        //            break;
        //        case "Power Supply":
        //            _handler?.RaiseInstrumentControlViewChanged(new InstrumentControlViewChangeEventArgs(Hardware.Controls.InstrumentType.Oscilloscope, false));
        //            _handler?.RaiseInstrumentControlViewChanged(new InstrumentControlViewChangeEventArgs(Hardware.Controls.InstrumentType.PowerSupply, true));
        //            break;
        //        case "Oscilloscope":
        //            _handler?.RaiseInstrumentControlViewChanged(new InstrumentControlViewChangeEventArgs(Hardware.Controls.InstrumentType.PowerSupply, false));
        //            _handler?.RaiseInstrumentControlViewChanged(new InstrumentControlViewChangeEventArgs(Hardware.Controls.InstrumentType.Oscilloscope, true));
        //            break;
        //        default:
        //            break;
        //    }
        //}

        private void _handler_OnMenuBarItemSelected(object sender, UISelectionEventArgs e)
        {
            MessageBox.Show(e.Name + " was selected!");
        }
    }

}
