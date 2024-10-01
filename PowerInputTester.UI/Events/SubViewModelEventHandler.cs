using System;
using System.ComponentModel;

namespace PowerInputTester.UI.Events
{
    public class SubViewModelEventHandler
    {
        protected EventHandlerList listEventDelegates = new EventHandlerList();

        // Defines a unique key for each event.
        static readonly object subViewModelEnableChangedEventKey = new object();

        // Defines the event properties.
        public event EventHandler<SubViewModelEnableChangedEventArgs> SubViewModelEnableChanged
        {
            add
            {
                listEventDelegates.AddHandler(subViewModelEnableChangedEventKey, value);
            }
            remove
            {
                listEventDelegates.RemoveHandler(subViewModelEnableChangedEventKey, value);
            }
        }

        // Defines the methods used to raise each event.
        public void OnSubViewModelEnableChanged(SubViewModelEnableChangedEventArgs e)
        {
            EventHandler<SubViewModelEnableChangedEventArgs> EventDelegate =
                (EventHandler<SubViewModelEnableChangedEventArgs>)listEventDelegates[subViewModelEnableChangedEventKey];
            EventDelegate(this, e);
        }
    }
}
