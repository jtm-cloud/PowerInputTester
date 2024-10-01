using System;
using System.ComponentModel;

namespace PowerInputTester.UI.Events
{
    public class UIEventHandler
    {
        protected EventHandlerList listEventDelegates = new EventHandlerList();

        // Defines a unique key for each event.
        static readonly object installHandlerRequestedEventKey = new object();
        static readonly object instrumentConnectedEventKey = new object();
        static readonly object instrumentConnectRequestedEventKey = new object();
        static readonly object instrumentControlViewChangedEventKey = new object();
        static readonly object instrumentDisconnectedEventKey = new object();
        static readonly object instrumentDisconnectRequestedEventKey = new object();
        static readonly object instrumentSelectedEventKey = new object();
        static readonly object instrumentSelectionCancelledEventKey = new object();
        static readonly object menuBarItemSelectedEventKey = new object();
        static readonly object sideDockItemSelectedEventKey = new object();

        // Defines the event properties.
        public event EventHandler<InstallHandlerEventArgs> OnInstallHandlerRequested
        {
            add
            {
                listEventDelegates.AddHandler(installHandlerRequestedEventKey, value);
            }
            remove
            {
                listEventDelegates.RemoveHandler(installHandlerRequestedEventKey, value);
            }
        }
        public event EventHandler<InstrumentConnectedEventArgs> OnInstrumentConnected
        {
            add
            {
                listEventDelegates.AddHandler(instrumentConnectedEventKey, value);
            }
            remove
            {
                listEventDelegates.RemoveHandler(instrumentConnectedEventKey, value);
            }
        }
        public event EventHandler<InstrumentControlViewChangeEventArgs> OnInstrumentControlViewChanged
        {
            add
            {
                listEventDelegates.AddHandler(instrumentControlViewChangedEventKey, value);
            }
            remove
            {
                listEventDelegates.RemoveHandler(instrumentControlViewChangedEventKey, value);
            }
        }
        public event EventHandler<DeviceConnectRequestEventArgs> OnInstrumentConnectRequested
        {
            add
            {
                listEventDelegates.AddHandler(instrumentConnectRequestedEventKey, value);
            }
            remove
            {
                listEventDelegates.RemoveHandler(instrumentConnectRequestedEventKey, value);
            }
        }
        public event EventHandler<DeviceConnectRequestEventArgs> OnInstrumentDisconnected
        {
            add
            {
                listEventDelegates.AddHandler(instrumentDisconnectedEventKey, value);
            }
            remove
            {
                listEventDelegates.RemoveHandler(instrumentDisconnectedEventKey, value);
            }
        }
        public event EventHandler<DeviceConnectRequestEventArgs> OnInstrumentDisconnectRequested
        {
            add
            {
                listEventDelegates.AddHandler(instrumentDisconnectRequestedEventKey, value);
            }
            remove
            {
                listEventDelegates.RemoveHandler(instrumentDisconnectRequestedEventKey, value);
            }
        }
        public event EventHandler<InstrumentSelectionEventArgs> OnInstrumentSelected
        {
            add
            {
                listEventDelegates.AddHandler(instrumentSelectedEventKey, value);
            }
            remove
            {
                listEventDelegates.RemoveHandler(instrumentSelectedEventKey, value);
            }
        }
        public event EventHandler OnInstrumentSelectionCancelled
        {
            add
            {
                listEventDelegates.AddHandler(instrumentSelectionCancelledEventKey, value);
            }
            remove
            {
                listEventDelegates.RemoveHandler(instrumentSelectionCancelledEventKey, value);
            }
        }
        public event EventHandler<UISelectionEventArgs> OnMenuBarItemSelected
        {
            add
            {
                listEventDelegates.AddHandler(menuBarItemSelectedEventKey, value);
            }
            remove
            {
                listEventDelegates.RemoveHandler(menuBarItemSelectedEventKey, value);
            }
        }
        public event EventHandler<UISelectionEventArgs> OnSideDockItemSelected
        {
            add
            {
                listEventDelegates.AddHandler(sideDockItemSelectedEventKey, value);
            }
            remove
            {
                listEventDelegates.RemoveHandler(sideDockItemSelectedEventKey, value);
            }
        }

        // Defines the methods used to raise each event.
        public void RaiseInstrumentConnected(InstrumentConnectedEventArgs e)
        {
            EventHandler<InstrumentConnectedEventArgs> EventDelegate =
                (EventHandler<InstrumentConnectedEventArgs>)listEventDelegates[instrumentConnectedEventKey];
            EventDelegate(this, e);
        }
        public void RaiseInstrumentControlViewChanged(InstrumentControlViewChangeEventArgs e)
        {
            EventHandler<InstrumentControlViewChangeEventArgs> EventDelegate =
                (EventHandler<InstrumentControlViewChangeEventArgs>)listEventDelegates[instrumentControlViewChangedEventKey];
            EventDelegate(this, e);
        }
        public void RaiseInstrumentDisconnected(DeviceConnectRequestEventArgs e)
        {
            EventHandler<DeviceConnectRequestEventArgs> EventDelegate =
                (EventHandler<DeviceConnectRequestEventArgs>)listEventDelegates[instrumentDisconnectedEventKey];
            EventDelegate(this, e);
        }
        public void RaiseInstrumentSelected(InstrumentSelectionEventArgs e)
        {
            EventHandler<InstrumentSelectionEventArgs> EventDelegate =
                (EventHandler<InstrumentSelectionEventArgs>)listEventDelegates[instrumentSelectedEventKey];
            EventDelegate(this, e);
        }
        public void RaiseInstrumentSelectionCancelled(EventArgs e)
        {
            EventHandler EventDelegate =
                (EventHandler)listEventDelegates[instrumentSelectionCancelledEventKey];
            EventDelegate(this, e);
        }
        public void RaiseMenuBarItemSelected(UISelectionEventArgs e)
        {
            EventHandler<UISelectionEventArgs> EventDelegate =
                (EventHandler<UISelectionEventArgs>)listEventDelegates[menuBarItemSelectedEventKey];
            EventDelegate(this, e);
        }
        public void RaiseSideDockItemSelected(UISelectionEventArgs e)
        {
            EventHandler<UISelectionEventArgs> EventDelegate =
                (EventHandler<UISelectionEventArgs>)listEventDelegates[sideDockItemSelectedEventKey];
            EventDelegate(this, e);
        }
        public void RequestInstallHandler(InstallHandlerEventArgs e)
        {
            EventHandler<InstallHandlerEventArgs> EventDelegate =
                (EventHandler<InstallHandlerEventArgs>)listEventDelegates[installHandlerRequestedEventKey];
            EventDelegate(this, e);
        }
        public void RequestInstrumentConnect(DeviceConnectRequestEventArgs e)
        {
            EventHandler<DeviceConnectRequestEventArgs> EventDelegate =
                (EventHandler<DeviceConnectRequestEventArgs>)listEventDelegates[instrumentConnectRequestedEventKey];
            EventDelegate(this, e);
        }
        public void RequestInstrumentDisconnect(DeviceConnectRequestEventArgs e)
        {
            EventHandler<DeviceConnectRequestEventArgs> EventDelegate =
                (EventHandler<DeviceConnectRequestEventArgs>)listEventDelegates[instrumentDisconnectRequestedEventKey];
            EventDelegate(this, e);
        }
    }
}
