using CommonHelpers.GuardClauses;
using PowerInputTester.Hardware.Models;
using PowerInputTester.UI.Abstract;
using PowerInputTester.UI.Commands;
using PowerInputTester.UI.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PowerInputTester.UI.ViewModels
{
    public class DeviceSelectionViewModel : ViewModelBase
    {
        #region Backing Fields

        private UIEventHandler _handler;
        private string _instructions;
        ObservableCollection<InstrumentInfo> _instruments;
        private string _title;

        #endregion

        public ICommand CancelCommand { get; set; }
        public string Instructions
        {
            get { return _instructions; }
            set { SetProperty(ref _instructions, value); }
        }
        public ObservableCollection<InstrumentInfo> Instruments
        {
            get { return _instruments; }
            set { SetProperty(ref _instruments, value); }
        }
        public ICommand SubmitCommand { get; set; }
        public InstrumentInfo SelectedInstrument { get; set; }
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public DeviceSelectionViewModel(ICollection<InstrumentInfo> instruments, UIEventHandler handler)
        {
            GuardClause.NullReference(instruments, "instruments");
            GuardClause.NullReference(handler, "handler");

            _handler = handler;
            CancelCommand = new RelayCommand(Cancel, CanCancel);
            SubmitCommand = new RelayCommand(Submit, CanSubmit);
            Instruments = new ObservableCollection<InstrumentInfo>(instruments);
            Title = "Instrument Selection:";
            Instructions = "Select the applicable instrument to use from the devices listed below.";
        }
        private bool CanCancel(object value)
        {
            return true;
        }
        private bool CanSubmit(object value)
        {
            if (SelectedInstrument != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void Cancel(object value)
        {
            _handler?.RaiseInstrumentSelectionCancelled(new EventArgs());
        }
        private void Submit(object value)
        {
            _handler?.RaiseInstrumentSelected(new InstrumentSelectionEventArgs(SelectedInstrument));
        }

    }
}
