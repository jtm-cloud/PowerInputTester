using CommonHelpers.GuardClauses;
using PowerInputTester.Hardware.Events;
using PowerInputTester.Hardware.Models;
using PowerInputTester.HardwareTest;
using PowerInputTester.UI.Events;
using PowerInputTester.UI.ViewModels;
using PowerInputTester.UI.Views;
using System;
using System.Collections.Generic;
using System.Windows;

namespace PowerInputTester.UI.Controls
{
    public class ServiceProvider
    {
        #region Backing Fields

        UIEventHandler _handler;
        InstrumentManagerMockUp _manager;
        DialogWindow _dialogWindow;
        
        #endregion
        public ServiceProvider(UIEventHandler handler)
        {
            GuardClause.NullReference(handler, "handler");
            _handler = handler;
            _handler.OnInstrumentConnectRequested += ProcessInstrumentConnectionRequest;
            _handler.OnInstrumentSelected += ProcessInstrumentSelection;
            _handler.OnInstrumentSelectionCancelled += ProcessInstrumentSelectionCancellation;
            _handler.OnInstrumentDisconnectRequested += ProcessInstrumentDisconnectRequest;
            _manager = new InstrumentManagerMockUp();
        }

        private void ProcessInstrumentConnectionRequest(object sender, DeviceConnectRequestEventArgs e)
        {
            ICollection<InstrumentInfo> infoList = _manager.FindInstruments(e.InstrumentType);
            if ((infoList != null) && (infoList.Count > 0))
            {
                DialogWindowViewModel viewModel = new DialogWindowViewModel();
                _dialogWindow = new DialogWindow();
                _dialogWindow.DataContext = viewModel;
                viewModel.ActiveViewModel = new DeviceSelectionViewModel(infoList, _handler);
                _dialogWindow.ShowDialog();
            }
        }
        private void ProcessInstrumentSelectionCancellation(object sender, EventArgs e)
        {
            _dialogWindow.Close();
            _dialogWindow = null;
        }
        private void ProcessInstrumentSelection(object sender, InstrumentSelectionEventArgs e)
        {
            _dialogWindow.Close();
            _dialogWindow = null;
            InstrumentEventHandler handler = _manager.GetInstrumentHandler(e.SelectedInstrument);

            if (handler != null)
            {
                _handler.RaiseInstrumentConnected(new InstrumentConnectedEventArgs(e.SelectedInstrument.InstrumentType, handler));
            }
            else
            {
                MessageBox.Show("The selected instrument was unable to be initialized.", "Initialization Error");
            }
        }
        private void ProcessInstrumentDisconnectRequest(object sender, DeviceConnectRequestEventArgs e)
        {
            _manager.DisconnectDevice(e.InstrumentType);
            _handler.RaiseInstrumentDisconnected(e);
        }
    }
}
