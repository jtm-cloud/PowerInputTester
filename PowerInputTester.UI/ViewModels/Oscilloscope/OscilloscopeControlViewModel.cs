using CommonHelpers.GuardClauses;
using PowerInputTester.Hardware.Controls;
using PowerInputTester.Hardware.Events;
using PowerInputTester.UI.Abstract;
using PowerInputTester.UI.Events;
using PowerInputTester.UI.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace PowerInputTester.UI.ViewModels.Oscilloscope
{
    public class OscilloscopeControlViewModel : ViewModelBase, IInstrumentControlContainer
    {
        #region Backing Fields

        private ObservableCollection<IInstrumentControlPanel> _controlPanels;
        private bool _enabled;
        private UIEventHandler _handler;
        private InstrumentType _instrumentType;

        #endregion
        public ObservableCollection<IInstrumentControlPanel> ControlPanels
        {
            get { return _controlPanels; }
            set { SetProperty(ref _controlPanels, value); }
        }
        public bool Enabled
        {
            get { return _enabled; }
            set { SetProperty(ref _enabled, value); }
        }
        public InstrumentType InstrumentType { get { return _instrumentType; } }
        public OscilloscopeControlViewModel(UIEventHandler handler)
        {
            GuardClause.NullReference(handler, "handler");

            _instrumentType = InstrumentType.Oscilloscope;
            _handler = handler;
            _handler.OnInstrumentConnected += _handler_OnInstrumentConnected;
            _handler.OnInstrumentDisconnected += _handler_OnInstrumentDisconnected;
            _handler.OnInstrumentControlViewChanged += _handler_OnInstrumentControlViewChanged;

            ControlPanelDefault();
        }

        private void _handler_OnInstrumentControlViewChanged(object sender, InstrumentControlViewChangeEventArgs e)
        {
            if (e.InstrumentType == InstrumentType)
            {
                Enabled = e.Enabled;
            }
        }

        private void _handler_OnInstrumentConnected(object sender, InstrumentConnectedEventArgs e)
        {
            if (e.InstrumentType == _instrumentType)
            {
                MessageBox.Show("Work In-Progress!");
            }
        }
        private void _handler_OnInstrumentDisconnected(object sender, DeviceConnectRequestEventArgs e)
        {
            if (e.InstrumentType == InstrumentType)
            {
                ControlPanelDefault();
            }
        }
        private void ControlPanelDefault()
        {
            if (ControlPanels == null)
            {
                ControlPanels = new ObservableCollection<IInstrumentControlPanel>()
                {
                    new ConnectionPanelViewModel(_handler)
                };
            }
            else
            {
                ControlPanels.Clear();
                ControlPanels.Add(new ConnectionPanelViewModel(_handler));
            }
        }
    }
}
