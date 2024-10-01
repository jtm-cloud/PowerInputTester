using PowerInputTester.Hardware.Models;
using System;
using System.ComponentModel;

namespace PowerInputTester.Hardware.Controls
{
    public class InstrumentEventHandler
    {
        protected EventHandlerList listEventDelegates = new EventHandlerList();

        // Defines a unique key for each event.
        static readonly object settingChangedEventKey = new object();
        static readonly object userInputEventKey = new object();

        // Defines the event properties.
        public event EventHandler<InstrumentSettingEventArgs> SettingChanged
        {
            add
            {
                listEventDelegates.AddHandler(settingChangedEventKey, value);
            }
            remove
            {
                listEventDelegates.RemoveHandler(settingChangedEventKey, value);
            }
        }
        public event EventHandler<InstrumentSettingEventArgs> UserInput
        {
            add
            {
                listEventDelegates.AddHandler(userInputEventKey, value);
            }
            remove
            {
                listEventDelegates.RemoveHandler(userInputEventKey, value);
            }
        }

        // Defines the private methods used to raise each event.
        public void OnSettingChanged(InstrumentSettingEventArgs e)
        {
            EventHandler<InstrumentSettingEventArgs> EventDelegate =
                (EventHandler<InstrumentSettingEventArgs>)listEventDelegates[settingChangedEventKey];
            EventDelegate(this, e);
        }
        public void OnUserInput(InstrumentSettingEventArgs e)
        {
            EventHandler<InstrumentSettingEventArgs> EventDelegate =
                (EventHandler<InstrumentSettingEventArgs>)listEventDelegates[userInputEventKey];
            EventDelegate(this, e);
        }
    }
}
