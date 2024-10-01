using PowerInputTester.UI.Models;
using System;
using System.ComponentModel;

namespace PowerInputTester.UI.Controls
{
    public class UIEventHandler
    {
        protected EventHandlerList listEventDelegates = new EventHandlerList();

        // Defines a unique key for each event.
        static readonly object instrumentConnectionRequestedEventKey = new object();
        static readonly object instrumentSelectedEventKey = new object();
        static readonly object instrumentSelectionCancelledEventKey = new object();
        static readonly object menuBarItemSelectedEventKey = new object();
        static readonly object sideDockItemSelectedEventKey = new object();

        // Defines the event properties.
        public event EventHandler OnInstrumentConnectionRequested
        {
            add
            {
                listEventDelegates.AddHandler(instrumentConnectionRequestedEventKey, value);
            }
            remove
            {
                listEventDelegates.RemoveHandler(instrumentConnectionRequestedEventKey, value);
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
        public void RequestInstrumentConnection(EventArgs e)
        {
            EventHandler EventDelegate =
                (EventHandler)listEventDelegates[instrumentConnectionRequestedEventKey];
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
    }
}
