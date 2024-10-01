using PowerInputTester.Hardware.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PowerInputTester.HardwareTest
{
    public class CIPowerSupplySettingsMockUp
    {
        #region Backing Fields

        private float _clipLevelA;
        private float _clipLevelB;
        private float _clipLevelC;
        private ICollection<float> _clipLevelList;
        private float _currentLimit;
        private SettingRange _currentLimitRange;
        private float _frequencyA;
        private float _frequencyB;
        private float _frequencyC;
        private SettingRange _frequencyRange;
        private string _outputCoupling;
        private string _outputMode;
        private string _outputNumber;
        private bool _outputState;
        private float _voltageA;
        private float _voltageB;
        private float _voltageC;
        private float _voltageRange;
        private SettingRange _voltageRangeList;
        private string _waveformShapeA;
        private string _waveformShapeB;
        private string _waveformShapeC;
        private ICollection<string> _waveformShapeList;

        #endregion
        public CIPowerSupplySettingsMockUp()
        {

            _clipLevelList = new List<float>(){ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            _waveformShapeList = new Collection<string>() { "SINE", "SQUARE", "CLIPPED" };

            _voltageRangeList = new SettingRange();
            _voltageRangeList.Min = 156f;
            _voltageRangeList.Max = 312f;

            _frequencyRange = new SettingRange();
            _frequencyRange.Min = 40f;
            _frequencyRange.Max = 1000f;

            _currentLimitRange = new SettingRange();
            _currentLimitRange.Min = 0f;
            _currentLimitRange.Max = 20f;

            _outputCoupling = "NONE";

            _voltageA = 0f;
            _voltageB = 0f;
            _voltageC = 0f;
            _voltageRange = 156f;

            _frequencyA = 60f;
            _frequencyB = 60f;
            _frequencyC = 60f;

            _outputNumber = "THREE";
            _outputMode = "DC";
            _outputState = false;

            _clipLevelA = 0f;
            _clipLevelB = 0f;
            _clipLevelC = 0f;

            _waveformShapeA = "SINE";
            _waveformShapeB = "SINE";
            _waveformShapeC = "SINE";
        }
        public float ClipLevelA
        {
            get
            {
                if ((WaveformShapeA == "CLIPPED") && (OutputMode != "DC"))
                {
                    return _clipLevelA;
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
                    _clipLevelA = value;
                    VoltageA = 0;
                    VoltageB = 0;
                    VoltageC = 0;
                }
            }
        }
        public float ClipLevelB
        {
            get
            {
                if ((OutputNumber == "THREE") && (WaveformShapeB == "CLIPPED") && (OutputMode != "DC"))
                {
                    return _clipLevelB;
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
                    _clipLevelB = value;
                    VoltageA = 0;
                    VoltageB = 0;
                    VoltageC = 0;
                }
            }
        }
        public float ClipLevelC
        {
            get
            {
                if ((OutputNumber == "THREE") && (WaveformShapeC == "CLIPPED") && (OutputMode != "DC"))
                {
                    return _clipLevelC;
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
                    _clipLevelC = value;
                    VoltageA = 0;
                    VoltageB = 0;
                    VoltageC = 0;
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
                return _currentLimit;
            }
            set
            {
                if (IsValidCurrentLimit(value))
                {
                    _currentLimit = value;
                }
            }
        }
        public SettingRange CurrentLimitRange
        {
            get
            {
                return _currentLimitRange;
            }
        }
        public float FrequencyA
        {
            get
            {
                if (OutputMode != "DC")
                {
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
                    _frequencyA = value;
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
                    _frequencyB = value;
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
                    _frequencyC = value;
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
                return _frequencyRange;
            }
        }
        public string OutputCoupling
        {
            get
            {
                return _outputCoupling;
            }
            set
            {
                if ((OutputNumber == "THREE") && (IsValidCoupling(value)))
                {
                    _outputCoupling = value;
                }
            }
        }
        public string OutputMode
        {
            get
            {
                return _outputMode;
            }
            set
            {
                if ((value != OutputMode) && (IsValidOutputMode(value)))
                {
                    OutputState = false;
                    _outputMode = value;
                    if ((value == "AC") || (value == "ACDC"))
                    {
                        VoltageA = 115;
                        FrequencyA = 60;
                        if (OutputNumber == "THREE")
                        {
                            VoltageB = 115;
                            VoltageC = 115;
                        }
                    }
                    else
                    {
                        VoltageA = 28;
                        if (OutputNumber == "THREE")
                        {
                            VoltageB = 28;
                            VoltageC = 28;
                        }
                    }
                }
            }
        }
        public string OutputNumber
        {
            get
            {
                return _outputNumber;
            }
            set
            {
                if ((OutputNumber != "FIXED") && (IsValidOutputNumber(value)))
                {
                    _outputNumber = value;
                }

            }
        }
        public bool OutputState
        {
            get
            {
                return _outputState;
            }
            set
            {
                _outputState = value;
            }
        }
        public float VoltageA
        {
            get
            {
                return _voltageA;
            }
            set
            {
                if ((value != VoltageA) && (IsValidVoltage(value)))
                {
                    _voltageA = value;
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
                    _voltageB = value;
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
                    _voltageC = value;
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
                return _voltageRange;
            }
            set
            {
                if ((IsValidVoltageRange(value)) && (value != VoltageRange))
                {
                    OutputState = false;
                    _voltageRange = value;
                    VoltageA = _voltageA;
                    if (value == 156)
                    {
                        _currentLimitRange.Min = 0f;
                        _currentLimitRange.Max = 20f;
                    }
                    else
                    {
                        _currentLimitRange.Min = 0f;
                        _currentLimitRange.Max = 11.1f;
                    }

                    if (OutputNumber == "THREE")
                    {
                        VoltageB = _voltageA;
                        VoltageC = _voltageA;
                    }
                    if (OutputMode != "DC")
                    {
                        FrequencyA = _frequencyA;
                        if (OutputNumber == "THREE")
                        {
                            FrequencyB = _frequencyA;
                            FrequencyC = _frequencyA;
                        }
                    }
                }
            }
        }
        public SettingRange VoltageRangeList
        {
            get
            {
                return _voltageRangeList;
            }
        }
        public string WaveformShapeA
        {
            get
            {
                if (OutputMode != "DC")
                {
                    return _waveformShapeA;
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
                    _waveformShapeA = value;
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
                    return _waveformShapeB;
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
                    _waveformShapeB = value;
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
                    return _waveformShapeC;
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
                    _waveformShapeC = value;
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
                return _waveformShapeList;
            }
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
            return ((value >= _currentLimitRange.Min) && (value <= _currentLimitRange.Max));
        }
        private bool IsValidFrequency(float value)
        {
            return ((value >= _frequencyRange.Min) && (value <= _frequencyRange.Max));
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
            return (value >= 0) && (value <= VoltageRange);
        }
        private bool IsValidVoltageRange(float value)
        {
            return ((value == _voltageRangeList.Min) || (value == _voltageRangeList.Max));
        }
        private bool IsValidWaveformShape(string value)
        {
            foreach (string shape in _waveformShapeList)
            {
                if (shape == value)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
