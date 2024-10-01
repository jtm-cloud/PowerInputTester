using CommonHelpers.GuardClauses;
using PowerInputTester.Hardware.Controls;
using PowerInputTester.Hardware.Events;
using PowerInputTester.UI.Abstract;
using PowerInputTester.UI.Events;
using PowerInputTester.UI.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PowerInputTester.UI.ViewModels
{
    public class ControlPanelContainerViewModel : ViewModelBase, IInstrumentControlContainer
    {
        #region Backing Fields

        ObservableCollection<IInstrumentControlPanel> _controlPanels;
        UIEventHandler _handler;
        bool _enabled;

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
        public InstrumentType InstrumentType { get; }
        public ControlPanelContainerViewModel(InstrumentType instrumentType, UIEventHandler handler)
        {
            GuardClause.NullReference(handler, "handler");
            GuardClause.ZeroValue((int)instrumentType, "instrumentType");

            InstrumentType = instrumentType;
            _handler = handler;
            handler.OnInstrumentDisconnected += HandleInstrumentDisconnected;

            InstrumentEventHandler newHandler = new InstrumentEventHandler();
            ICollection<string> channelNames = new Collection<string>()
            {
                "VoltageA", "VoltageB", "VoltageC"
            };

            ICollection<string> optionNames = new Collection<string>()
            {
                "AC", "DC", "ACDC"
            };

            ICollection<WaveformShapeOptionsContainer> wfContainers = new Collection<WaveformShapeOptionsContainer>()
            {
                new WaveformShapeOptionsContainer("A", "WaveformA", newHandler),
                new WaveformShapeOptionsContainer("B", "WaveformA", newHandler),
                new WaveformShapeOptionsContainer("C", "WaveformA", newHandler)
            };
            ControlPanels = new ObservableCollection<IInstrumentControlPanel>()
            {
                new ConnectionControlViewModel(InstrumentType, handler),
                new RadioButtonPanelViewModel("OutputMode", optionNames, newHandler, "OutputModeList"),
                new RangeButtonsPanelViewModel("Voltage", channelNames, newHandler),
                new WaveformShapePanelViewModel("Waveform Function", wfContainers, "WaveformA", newHandler),
                new OutputStateViewModel("OutputState", "Output State", newHandler)
            };
        }
        private void HandleInstrumentDisconnected(object sender, DeviceConnectRequestEventArgs e)
        {
            if (e.InstrumentType == InstrumentType)
            {
                Enabled = false;
            }
        }
    }
}
