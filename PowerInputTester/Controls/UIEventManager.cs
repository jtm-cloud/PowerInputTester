using PowerInputTester.Events;
using System;
using System.ComponentModel;

namespace PowerInputTester.Controls
{
    public class UIEventManager
    {
        protected EventHandlerList listEventDelegates = new EventHandlerList();

        // Defines a unique key for each event.
        static readonly object menuBarItemSelectedEventKey = new object();
        static readonly object sideDockItemSelectedEventKey = new object();

        // Defines the event properties.
        public event EventHandler<UISelectionEventArgs> MenuBarItemSelected
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
        public event EventHandler<UISelectionEventArgs> SideDockItemSelected
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

        // Defines the private methods used to raise each event.
        public void OnMenuBarItemSelected(UISelectionEventArgs e)
        {
            EventHandler<UISelectionEventArgs> EventDelegate =
                (EventHandler<UISelectionEventArgs>)listEventDelegates[menuBarItemSelectedEventKey];
            EventDelegate(this, e);
        }
        public void OnSideDockItemSelected(UISelectionEventArgs e)
        {
            EventHandler< UISelectionEventArgs> EventDelegate =
                (EventHandler< UISelectionEventArgs>)listEventDelegates[sideDockItemSelectedEventKey];
            EventDelegate(this, e);
        }
    }
}
