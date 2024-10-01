using System;
using System.ComponentModel;

namespace PowerInputTester.Hardware.Events
{
    public class InstrumentEventHandler
    {
        protected EventHandlerList listEventDelegates = new EventHandlerList();

        // Defines a unique key for each event.
        private static readonly object allSettingsRequestedEventKey = new object();
        private static readonly object settingChangedEventKey = new object();
        private static readonly object settingEnabledChangedEventKey = new object();
        private static readonly object userInputEventKey = new object();

        // Defines the event properties.
        public event EventHandler OnAllSettingsRequested
        {
            add
            {
                listEventDelegates.AddHandler(allSettingsRequestedEventKey, value);
            }
            remove
            {
                listEventDelegates.RemoveHandler(allSettingsRequestedEventKey, value);
            }
        }
        public event EventHandler<InstrumentSettingEventArgs> OnSettingChanged
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
        public event EventHandler<SettingEnabledEventArgs> OnSettingEnabledChanged
        {
            add
            {
                listEventDelegates.AddHandler(settingEnabledChangedEventKey, value);
            }
            remove
            {
                listEventDelegates.RemoveHandler(settingEnabledChangedEventKey, value);
            }
        }
        public event EventHandler<InstrumentSettingEventArgs> OnUserInput
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
        public void RaiseSettingChanged(InstrumentSettingEventArgs e)
        {
            EventHandler<InstrumentSettingEventArgs> EventDelegate =
                (EventHandler<InstrumentSettingEventArgs>)listEventDelegates[settingChangedEventKey];
            EventDelegate(this, e);
        }
        public void RaiseSettingEnabledChanged(SettingEnabledEventArgs e)
        {
            EventHandler<SettingEnabledEventArgs> EventDelegate =
                (EventHandler<SettingEnabledEventArgs>)listEventDelegates[settingEnabledChangedEventKey];
            EventDelegate(this, e);
        }
        public void RaiseUserInput(InstrumentSettingEventArgs e)
        {
            EventHandler<InstrumentSettingEventArgs> EventDelegate =
                (EventHandler<InstrumentSettingEventArgs>)listEventDelegates[userInputEventKey];
            EventDelegate(this, e);
        }
        public void RequestAllSettings(EventArgs e)
        {
            EventHandler EventDelegate =
                (EventHandler)listEventDelegates[allSettingsRequestedEventKey];
            EventDelegate(this, e);
        }
    }
}
