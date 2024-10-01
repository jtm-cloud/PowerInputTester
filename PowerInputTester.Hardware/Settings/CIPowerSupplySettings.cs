using PowerInputTester.Hardware.Abstract;
using PowerInputTester.Hardware.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PowerInputTester.Hardware.Settings
{
    public class CIPowerSupplySettings : IPowerSupplySettings
    {
        #region Backing Fields

        private float _frequencyA;
        private float _frequencyB;
        private float _frequencyC;
        private InstrumentMessagingBase _messenger;
        private float _voltageA;
        private float _voltageB;
        private float _voltageC;
        private ICollection<float> _clipLevelList;

        #endregion
        public CIPowerSupplySettings(InstrumentMessagingBase messenger)
        {
            _messenger = messenger;

            _clipLevelList = new List<float>()
            { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        }
        public float ClipLevelA
        {
            get
            {
                if ((WaveformShapeA == "CLIPPED") && (OutputMode != "DC"))
                {
                    PhaseSelection = "A";
                    _messenger.Write("FUNC:CSIN?");
                    return _messenger.ReadFloat();
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if ((WaveformShapeA == "CLIPPED") && (OutputMode != "DC") && (IsValidClip(value)))
                {
                    PhaseSelection = "A";
                    _messenger.Write("FUNC:CSIN " + value.ToString());
                    _messenger.Write("VOLT " + _voltageA.ToString());
                }
            }
        }
        public float ClipLevelB
        {
            get
            {
                if ((OutputNumber == "THREE") && (WaveformShapeB == "CLIPPED") && (OutputMode != "DC"))
                {
                    PhaseSelection = "B";
                    _messenger.Write("FUNC:CSIN?");
                    return _messenger.ReadFloat();
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if ((OutputNumber == "THREE") && (WaveformShapeB == "CLIPPED") && (OutputMode != "DC") && (IsValidClip(value)))
                {
                    PhaseSelection = "B";
                    _messenger.Write("FUNC:CSIN " + value.ToString());
                    _messenger.Write("VOLT " + _voltageB.ToString());
                }
            }
        }
        public float ClipLevelC
        {
            get
            {
                if ((OutputNumber == "THREE") && (WaveformShapeC == "CLIPPED") && (OutputMode != "DC"))
                {
                    PhaseSelection = "C";
                    _messenger.Write("FUNC:CSIN?");
                    return _messenger.ReadFloat();
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if ((OutputNumber == "THREE") && (WaveformShapeC == "CLIPPED") && (OutputMode != "DC") && (IsValidClip(value)))
                {
                    PhaseSelection = "C";
                    _messenger.Write("FUNC:CSIN " + value.ToString());
                    _messenger.Write("VOLT " + _voltageC.ToString());
                }
            }
        }
        public ICollection<float> ClipLevelList
        {
            get
            {
                return _clipLevelList;
            }
        }
        public float CurrentLimit
        {
            get
            {
                _messenger.Write("CURR?");
                return _messenger.ReadFloat();
            }
            set
            {
                if (IsValidCurrentLimit(value))
                {
                    _messenger.Write("CURR " + value.ToString());
                }
            }
        }
        public SettingRange CurrentLimitRange
        {
            get
            {
                SettingRange settingRange = new SettingRange();
                _messenger.Write("CURR?MAX");
                settingRange.Max = _messenger.ReadFloat();
                _messenger.Write("CURR?MIN");
                settingRange.Min = _messenger.ReadFloat();
                return settingRange;
            }
        }
        public float FrequencyA
        {
            get
            {
                if (OutputMode != "DC")
                {
                    PhaseSelection = "A";
                    _messenger.Write("FREQ?");
                    _frequencyA = _messenger.ReadFloat();
                    return _frequencyA;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if ((OutputMode != "DC") && (value != FrequencyA) && (IsValidFrequency(value)))
                {
                    PhaseSelection = "A";
                    _messenger.Write("FREQ " + value.ToString());
                    if ((OutputNumber == "THREE") && (OutputCoupling == "ALL"))
                    {
                        FrequencyB = value;
                        FrequencyC = value;
                    }
                }
            }
        }
        public float FrequencyB
        {
            get
            {
                if ((OutputNumber == "THREE") && (OutputMode != "DC"))
                {
                    PhaseSelection = "B";
                    _messenger.Write("FREQ?");
                    _frequencyB = _messenger.ReadFloat();
                    return _frequencyB;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if ((OutputNumber == "THREE") && (OutputMode != "DC") && (value != FrequencyB) && (IsValidFrequency(value)))
                {
                    PhaseSelection = "B";
                    _messenger.Write("FREQ " + value.ToString());
                    if (OutputCoupling == "ALL")
                    {
                        FrequencyA = value;
                        FrequencyC = value;
                    }
                }
            }
        }
        public float FrequencyC
        {
            get
            {
                if ((OutputNumber == "THREE") && (OutputMode != "DC"))
                {
                    PhaseSelection = "C";
                    _messenger.Write("FREQ?");
                    _frequencyC = _messenger.ReadFloat();
                    return _frequencyC;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if ((OutputNumber == "THREE") && (OutputMode != "DC") && (value != FrequencyC) && (IsValidFrequency(value)))
                {
                    PhaseSelection = "C";
                    _messenger.Write("FREQ " + value.ToString());
                    if (OutputCoupling == "ALL")
                    {
                        FrequencyA = value;
                        FrequencyB = value;
                    }
                }
            }
        }
        public SettingRange FrequencyRange
        {
            get
            {
                SettingRange range = new SettingRange();
                _messenger.Write("LIM:FREQ?");
                float[] buffer = _messenger.ReadFloatList();
                range.Min = buffer[0];
                range.Max = buffer[1];
                return range;
            }
        }
        public string OutputCoupling
        {
            get
            {
                _messenger.Write("INST:COUP?");
                return _messenger.ReadString();
            }
            set
            {
                if ((OutputNumber == "THREE") && (IsValidCoupling(value)))
                {
                    _messenger.Write("INST:COUP " + value);
                }
            }
        }
        public string OutputMode
        {
            get
            {
                _messenger?.Write("MODE?");
                return _messenger?.ReadString();
            }
            set
            {
                if ((value != OutputMode) && (IsValidOutputMode(value)))
                {
                    OutputState = false;
                    _messenger.Write("MODE " + value);
                    if ((value == "AC") || (value == "ACDC"))
                    {
                        VoltageA = 115;
                        if (OutputNumber == "THREE")
                        {
                            VoltageB = 115;
                            VoltageC = 115;
                        }
                    }
                    else
                    {
                        VoltageA = 28;
                    }
                }
            }
        }
        public string OutputNumber
        {
            get
            {
                _messenger.Write("SYST:CONF?");
                return _messenger.ReadString();
            }
            set
            {
                if ((OutputNumber != "FIXED") && (IsValidOutputNumber(value)))
                {
                    string argument = ResolveOutputNumberArgument(value);
                    _messenger.Write("SYST:CONF:NOUT " + argument);
                }

            }
        }
        public bool OutputState
        {
            get
            {
                _messenger.Write("OUTP?");
                return _messenger.ReadBool();
            }
            set
            {
                int argument = Convert.ToInt32(value);
                _messenger.Write("OUTP " + argument.ToString());
            }
        }
        public string PhaseSelection
        {
            get
            {
                _messenger.Write("INST:NSEL?");
                return _messenger.ReadString();
            }
            set
            {
                _messenger.Write("INST:NSEL " + value.ToString());
            }
        }
        public float VoltageA
        {
            get
            {
                PhaseSelection = "A";
                _messenger.Write("VOLT?");
                _voltageA = _messenger.ReadFloat();
                return _voltageA;
            }
            set
            {
                if ((value != VoltageA) && (IsValidVoltage(value)))
                {
                    PhaseSelection = "A";
                    _messenger.Write("VOLT " + value.ToString());
                    if ((OutputNumber == "THREE") && (OutputCoupling == "ALL"))
                    {
                        VoltageB = value;
                        VoltageC = value;
                    }
                }
            }
        }
        public float VoltageB
        {
            get
            {
                if (OutputNumber == "THREE")
                {
                    PhaseSelection = "B";
                    _messenger.Write("VOLT?");
                    _voltageB = _messenger.ReadFloat();
                    return _voltageB;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if ((OutputNumber == "THREE") && (value != VoltageB) && (IsValidVoltage(value)))
                {
                    PhaseSelection = "B";
                    _messenger.Write("VOLT " + value.ToString());
                    if (OutputCoupling == "ALL")
                    {
                        VoltageA = value;
                        VoltageC = value;
                    }
                }
            }
        }
        public float VoltageC
        {
            get
            {
                if (OutputNumber == "THREE")
                {
                    PhaseSelection = "C";
                    _messenger.Write("VOLT?");
                    _voltageC = _messenger.ReadFloat();
                    return _voltageC;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if ((OutputNumber == "THREE") && (value != VoltageC) && (IsValidVoltage(value)))
                {
                    PhaseSelection = "C";
                    _messenger.Write("VOLT " + value.ToString());
                    if (OutputCoupling == "ALL")
                    {
                        VoltageA = value;
                        VoltageB = value;
                    }
                }
            }
        }
        public float VoltageRange
        {
            get
            {
                _messenger.Write("VOLT:RANG?");
                return _messenger.ReadFloat();
            }
            set
            {
                if ((IsValidVoltageRange(value)) && (value != VoltageRange))
                {
                    OutputState = false;
                    _messenger.Write("VOLT:RANG " + value.ToString());
                    VoltageA = _voltageA;
                    if (OutputNumber == "THREE")
                    {
                        VoltageB = _voltageB;
                        VoltageC = _voltageC;
                    }
                    if (OutputMode != "DC")
                    {
                        FrequencyA = _frequencyA;
                        if (OutputNumber == "THREE")
                        {
                            FrequencyB = _frequencyB;
                            FrequencyC = _frequencyC;
                        }
                    }
                }
            }
        }
        public SettingRange VoltageRangeList
        {
            get
            {
                SettingRange range = new SettingRange();
                _messenger.Write("VOLT:RANG?MAX");
                range.Max = _messenger.ReadFloat();
                _messenger.Write("VOLT:RANG?MIN");
                range.Min = _messenger.ReadFloat();
                return range;
            }
        }
        public string WaveformShapeA
        {
            get
            {
                if (OutputMode != "DC")
                {
                    PhaseSelection = "A";
                    _messenger.Write("FUNC?");
                    return _messenger.ReadString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                if ((OutputMode != "DC") && (value != WaveformShapeA) && (IsValidWaveformShape(value)))
                {
                    PhaseSelection = "A";
                    _messenger.Write("FUNC " + value);
                    if ((OutputNumber == "THREE") && (OutputCoupling == "ALL"))
                    {
                        WaveformShapeB = value;
                        WaveformShapeC = value;
                    }
                }
            }
        }
        public string WaveformShapeB
        {
            get
            {
                if ((OutputNumber == "THREE") && (OutputMode != "DC"))
                {
                    PhaseSelection = "B";
                    _messenger.Write("FUNC?");
                    return _messenger.ReadString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                if ((OutputNumber == "THREE") && (OutputMode != "DC") && (value != WaveformShapeB) && (IsValidWaveformShape(value)))
                {
                    PhaseSelection = "B";
                    _messenger.Write("FUNC " + value);
                    if (OutputCoupling == "ALL")
                    {
                        WaveformShapeA = value;
                        WaveformShapeC = value;
                    }
                }
            }
        }
        public string WaveformShapeC
        {
            get
            {
                if ((OutputNumber == "THREE") && (OutputMode != "DC"))
                {
                    PhaseSelection = "C";
                    _messenger.Write("FUNC?");
                    return _messenger.ReadString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                if ((OutputNumber == "THREE") && (OutputMode != "DC") && (value != WaveformShapeC) && (IsValidWaveformShape(value)))
                {
                    PhaseSelection = "C";
                    _messenger.Write("FUNC " + value);
                    if (OutputCoupling == "ALL")
                    {
                        WaveformShapeA = value;
                        WaveformShapeB = value;
                    }
                }
            }
        }
        public ICollection<string> WaveformShapeList
        {
            get
            {
                _messenger.Write("TRAC:CAT?");
                return new Collection<string>(_messenger.ReadStringList());
            }
        }

        public void Dispose()
        {
            _messenger.Dispose();
        }

        private bool IsValidClip(float value)
        {
            foreach (float item in _clipLevelList)
            {
                if (item == value)
                {
                    return true;
                }
            }
            return false;
        }
        private bool IsValidCoupling(string value)
        {
            return ((value == "NONE") || (value == "ALL"));
        }
        private bool IsValidCurrentLimit(float value)
        {
            SettingRange range = CurrentLimitRange;
            return ((value >= range.Min) && (value <= range.Max));
        }
        private bool IsValidFrequency(float value)
        {
            SettingRange range = FrequencyRange;
            return ((value >= range.Min) && (value <= range.Max));
        }
        private bool IsValidOutputMode(string value)
        {
            return ((value == "AC") || (value == "DC") || (value == "ACDC"));
        }
        private bool IsValidOutputNumber(string value)
        {
            return ((value == "ONE") || (value == "THREE"));
        }
        private bool IsValidVoltage(float value)
        {
            float max = VoltageRange;
            return (value >= 0) && (value <= max);
        }
        private bool IsValidVoltageRange(float value)
        {
            SettingRange range = VoltageRangeList;
            return ((value <= range.Min) && (value <= range.Max));
        }
        private bool IsValidWaveformShape(string value)
        {
            ICollection<string> shapes = WaveformShapeList;
            foreach (string shape in shapes)
            {
                if (shape == value)
                {
                    return true;
                }
            }
            return false;
        }
        private string ResolveOutputNumberArgument(string value)
        {
            switch (value)
            {
                case "ONE":
                    return "ONEP";
                case "THREE":
                    return "THR";
                default:
                    return string.Empty;
            }
        }
    }
}
