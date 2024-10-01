using CommonHelpers.GuardClauses;
using PowerInputTester.Hardware.Controls;
using PowerInputTester.UI.Abstract;
using PowerInputTester.UI.Events;
using PowerInputTester.UI.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PowerInputTester.UI.ViewModels.PowerSupply
{
    public class PowerSupplyControlViewModel : ViewModelBase, IInstrumentControlContainer
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
        public PowerSupplyControlViewModel(UIEventHandler handler)
        {
            GuardClause.NullReference(handler, "handler");

            _instrumentType = InstrumentType.PowerSupply;
            _handler = handler;
            _handler.OnInstrumentConnected += _handler_OnInstrumentConnected;
            _handler.OnInstrumentDisconnected += _handler_OnInstrumentDisconnected;
            _handler.OnInstrumentControlViewChanged += _handler_OnInstrumentControlViewChanged;
            _handler.OnSideDockItemSelected += _handler_OnSideDockItemSelected;

            ControlPanelDefault();
            Enabled = false;
        }

        private void _handler_OnSideDockItemSelected(object sender, UISelectionEventArgs e)
        {
            if (e.Name == "Power Supply")
            {
                if (_enabled == false)
                {
                    Enabled = true;
                }
                else
                {
                    Enabled = false;
                }
            }
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
                _handler.RequestInstallHandler(new InstallHandlerEventArgs(e.Handler));

                ICollection<WaveformShapeOptionsContainer> wfContainers = new Collection<WaveformShapeOptionsContainer>()
            {
                new WaveformShapeOptionsContainer("A", "WaveformA", e.Handler),
                new WaveformShapeOptionsContainer("B", "WaveformA", e.Handler),
                new WaveformShapeOptionsContainer("C", "WaveformA", e.Handler)
            };

                ControlPanels.Add(new PhasePanelViewModel(e.Handler));
                ControlPanels.Add(new OutputModePanelViewModel(e.Handler));
                ControlPanels.Add(new VoltageRangePanelViewModel(e.Handler));
                ControlPanels.Add(new OutputCouplingPanelViewModel(e.Handler));
                ControlPanels.Add(new VoltagePanelViewModel(e.Handler));
                ControlPanels.Add(new FrequencyPanelViewModel(e.Handler));
                ControlPanels.Add(new CurrentLimitPanelViewModel(e.Handler));
                ControlPanels.Add(new WaveformShapePanelViewModel("Waveform Function", wfContainers, "WaveformA", e.Handler));
                ControlPanels.Add(new OutputStatePanelViewModel(e.Handler));
                e.Handler.RequestAllSettings(new System.EventArgs());
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
