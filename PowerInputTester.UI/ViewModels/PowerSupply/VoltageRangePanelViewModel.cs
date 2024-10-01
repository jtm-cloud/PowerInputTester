using CommonHelpers.GuardClauses;
using PowerInputTester.Hardware.Events;
using PowerInputTester.Hardware.Models;
using PowerInputTester.UI.Abstract;
using PowerInputTester.UI.Commands;
using System.Windows.Input;

namespace PowerInputTester.UI.ViewModels.PowerSupply
{
    public class VoltageRangePanelViewModel : ViewModelBase, IInstrumentControlPanel
    {
        #region Backing Fields

        private bool _displayOffset;
        private bool _enabled;
        private InstrumentEventHandler _handler;
        private string _header;
        private string _name;
        private bool _maxRangeSelected;
        private bool _minRangeSelected;
        private float _maxRange;
        private float _minRange;

        #endregion

        public bool DisplayOffset
        {
            get { return _displayOffset; }
            set { SetProperty(ref _displayOffset, value); }
        }
        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                if (value != _enabled)
                {
                    if (value == true)
                    {
                        SetProperty(ref _enabled, value);
                        DisplayOffset = false;
                    }
                    else
                    {
                        DisplayOffset = true;
                    }
                }
            }
        }
        public string Header
        {
            get { return _header; }
            set { SetProperty(ref _header, value); }
        }
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        public bool MaxRangeSelected
        {
            get { return _maxRangeSelected; }
            set { SetProperty(ref _maxRangeSelected, value); }
        }
        public bool MinRangeSelected
        {
            get { return _minRangeSelected; }
            set { SetProperty(ref _minRangeSelected, value); }
        }
        public float MaxRange
        {
            get { return _maxRange; }
            set { SetProperty(ref _maxRange, value); }
        }
        public float MinRange
        {
            get { return _minRange; }
            set { SetProperty(ref _minRange, value); }
        }

        public ICommand MaxRangeCommand { get; set; }
        public ICommand MinRangeCommand { get; set; }

        public VoltageRangePanelViewModel(InstrumentEventHandler handler)
        {
            GuardClause.NullReference(handler, "handler");

            Name = "VoltageRange";
            _handler = handler;
            _handler.OnSettingChanged += _handler_OnSettingChanged;

            MaxRangeCommand = new RelayCommand(ExecuteMaxRangeCommand, CanExecuteCommands);
            MinRangeCommand = new RelayCommand(ExecuteMinRangeCommand, CanExecuteCommands);

            Header = "Voltage Range";
            Enabled = false;
        }

        private bool CanExecuteCommands(object value)
        {
            return _enabled;
        }
        private void ExecuteMaxRangeCommand(object value)
        {
            _handler?.RaiseUserInput(new InstrumentSettingEventArgs(_name, _maxRange));
        }
        private void ExecuteMinRangeCommand(object value)
        {
            _handler?.RaiseUserInput(new InstrumentSettingEventArgs(_name, _minRange));
        }
        private void _handler_OnSettingChanged(object sender, InstrumentSettingEventArgs e)
        {
            if (e.SettingName == _name)
            {
                if (Enabled == false)
                {
                    Enabled = true;
                }
                if ((float)e.Value == _maxRange)
                {
                    MaxRangeSelected = true;
                }
                else if ((float)e.Value == _minRange)
                {
                    MinRangeSelected = true;
                }
            }
            else if (e.SettingName == "VoltageRangeList")
            {
                SettingRange value = (SettingRange)e.Value;
                MaxRange = value.Max;
                MinRange = value.Min;
            }
        }
    }
}
