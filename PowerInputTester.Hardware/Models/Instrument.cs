using CommonHelpers.GuardClauses;
using NationalInstruments.Visa;
using PowerInputTester.Hardware.Abstract;
using PowerInputTester.Hardware.Controls;
using PowerInputTester.Hardware.Events;
using System;
using System.Collections.Generic;

namespace PowerInputTester.Hardware.Models
{
    public class Instrument
    {
        #region Backing Fields

        InstrumentEventHandler _handler;
        InstrumentMessagingBase _messageBase;
        
        #endregion
        public InstrumentInfo Info { get; set; }
        public MessageBasedSession Session { get; set; }
        public IDictionary<string, ISetting> Settings { get; }
        public Instrument(MessageBasedSession session, InstrumentInfo info, IDictionary<string, ISetting> settings, InstrumentEventHandler handler)
        {
            GuardClause.NullReference(session, "session");

            Session = session;
            _messageBase = new InstrumentMessagingBase(session);
            Info = info;
            _handler = handler;
            _handler.OnUserInput += ProcessUserInput;
            _handler.OnAllSettingsRequested += ProcessAllSettingsRequest;
            Settings = settings;
            
        }
        private void ProcessUserInput(object sender, InstrumentSettingEventArgs e)
        {
            if (Settings.ContainsKey(e.SettingName) && IsNewValue(e.SettingName, e.Value))
            {
                ChangeTargetSettingValue(e.SettingName, e.Value);
            }
        }
        private void ChangeTargetSettingValue(string name, object newValue)
        {
            ProcessPreTriggers(name, newValue);
            
        }
        private void ProcessAllSettingsRequest(object sender, EventArgs e)
        {

        }
        private void ProcessPreTriggers(string name, object newValue)
        {

        }
        private void ProcessPostTriggers(string name, object newValue)
        {

        }
        private bool IsNewValue(string name, object newValue)
        {
            SettingReadType readType = Settings[name].ReadType;
            object currentValue = Settings[name].Value;

            GuardClause.NullReference(newValue, "newValue");
            GuardClause.NullReference(currentValue, "currentValue");

            switch (readType)
            {
                case SettingReadType.Boolean:
                    return ((bool)currentValue == (bool)newValue);

                case SettingReadType.BooleanList:
                    return ((bool[])currentValue == (bool[])newValue);

                case SettingReadType.Byte:
                    return ((byte)currentValue == (byte)newValue);

                case SettingReadType.ByteList:
                    return ((byte[])currentValue == (byte[])newValue);

                case SettingReadType.Double:
                    return ((double)currentValue == (double)newValue);

                case SettingReadType.DoubleList:
                    return ((double[])currentValue == (double[])newValue);

                case SettingReadType.Float:
                    return ((float)currentValue == (float)newValue);

                case SettingReadType.FloatList:
                    return ((float[])currentValue == (float[])newValue);

                case SettingReadType.Integer:
                    return ((int)currentValue == (int)newValue);

                case SettingReadType.IntegerList:
                    return ((int[])currentValue == (int[])newValue);

                case SettingReadType.Long:
                    return ((long)currentValue == (long)newValue);

                case SettingReadType.LongList:
                    return ((long[])currentValue == (long[])newValue);

                case SettingReadType.String:
                    return ((string)currentValue == (string)newValue);

                case SettingReadType.StringList:
                    return ((string[])currentValue == (string[])newValue);

                default:
                    return false;
            }
        }
    }
}
