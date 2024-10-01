using CommonHelpers.GuardClauses;
using PowerInputTester.Hardware.Events;
using PowerInputTester.UI.Abstract;
using PowerInputTester.UI.Commands;
using System.Windows;
using System.Windows.Input;

namespace PowerInputTester.UI.ViewModels.PowerSupply
{
    public class OutputCouplingPanelViewModel : ViewModelBase, IInstrumentControlPanel
    {
        #region Backing Fields

        private bool _allSelected;
        private bool _displayOffset;
        private bool _enabled;
        private InstrumentEventHandler _handler;
        private string _header;
        private string _name;
        private bool _noneSelected;
        private string _outputNumber;

        #endregion

        public bool AllSelected
        {
            get { return _allSelected; }
            set { SetProperty(ref _allSelected, value); }
        }
        public bool DisplayOffset
        {
            get { return _displayOffset; }
            set { SetProperty(ref _displayOffset, value); }
        }
        public bool Enabled
        {
            get { return _enabled; }
            set { SetProperty(ref _enabled, value); }
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
        public bool NoneSelected
        {
            get { return _noneSelected; }
            set { SetProperty(ref _noneSelected, value); }
        }

        public string OutputNumber
        {
            get { return _outputNumber; }
            set
            {
                if (value != _outputNumber)
                {
                    _outputNumber = value;
                    if (value == "THREE")
                    {
                        Enabled = true;
                        DisplayOffset = false;
                    }
                    else
                    {
                        DisplayOffset = true;
                    }
                }
            }
        }


        public ICommand AllCommand { get; set; }
        public ICommand NoneCommand { get; set; }
        public ICommand CloseCompletedCommand { get; set; }

        public OutputCouplingPanelViewModel(InstrumentEventHandler handler)
        {
            GuardClause.NullReference(handler, "handler");

            Name = "OutputCoupling";
            _handler = handler;
            _handler.OnSettingChanged += _handler_OnSettingChanged;

            AllCommand = new RelayCommand(ExecuteAllCommand, CanExecuteCommands);
            NoneCommand = new RelayCommand(ExecuteNoneCommand, CanExecuteCommands);
            CloseCompletedCommand = new RelayCommand(ExecuteCloseCompleted, CanExecuteCommands);
            Header = "Output Coupling";
        }

        private bool CanExecuteCommands(object value)
        {
            return true;
        }
        private void ExecuteAllCommand(object value)
        {
            _handler?.RaiseUserInput(new InstrumentSettingEventArgs(_name, "ALL"));
        }
        private void ExecuteCloseCompleted(object value)
        {
            MessageBox.Show("SUCCESSFUL!!!!");
        }
        private void ExecuteNoneCommand(object value)
        {
            _handler?.RaiseUserInput(new InstrumentSettingEventArgs(_name, "NONE"));
        }
        private void _handler_OnSettingChanged(object sender, InstrumentSettingEventArgs e)
        {
            if (e.SettingName == _name)
            {
                if (e.Value.ToString() == "ALL")
                {
                    AllSelected = true;
                }
                else if (e.Value.ToString() == "NONE")
                {
                    NoneSelected = true;
                }
            }
            else if (e.SettingName == "OutputNumber")
            {
                OutputNumber = e.Value.ToString();
            }
        }
    }
}
