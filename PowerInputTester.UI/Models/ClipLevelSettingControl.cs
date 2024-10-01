using CommonHelpers.GuardClauses;
using PowerInputTester.Hardware.Events;
using PowerInputTester.UI.Abstract;
using PowerInputTester.UI.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PowerInputTester.UI.Models
{
    public class ClipLevelSettingControl : ViewModelBase
    {
        #region Backing Fields

        private bool _displayOffset;
        private bool _enabled;
        private InstrumentEventHandler _handler;
        private string _name;
        private string _phase;
        private ObservableCollection<float> _clipLevelList;
        private float _userSelection;

        #endregion

        public ObservableCollection<float> ClipLevelList
        {
            get { return _clipLevelList; }
            set { SetProperty(ref _clipLevelList, value); }
        }
        public bool DisplayOffset
        {
            get { return _displayOffset; }
            set
            {
                if (value != _displayOffset)
                {
                    if (value == true)
                    {
                        SetProperty(ref _displayOffset, value);
                    }
                    else
                    {
                        Enabled = true;
                        SetProperty(ref _displayOffset, value);
                    }
                }
            }
        }
        public bool Enabled
        {
            get { return _enabled; }
            set { SetProperty(ref _enabled, value); }
        }
        public string Phase
        {
            get { return _phase; }
            set { SetProperty(ref _phase, value); }
        }
        public float UserSelection
        {
            get { return _userSelection; }
            set { SetProperty(ref _userSelection, value); }
        }
        public ClipLevelSettingControl(string name, InstrumentEventHandler handler)
        {
            GuardClause.EmptyString(name, "name");
            GuardClause.NullReference(handler, "handler");

            _name = name;

            _handler = handler;
            _handler.OnSettingChanged += _handler_OnSettingChanged;

            Phase = name[name.Length - 1].ToString();

            DisplayOffset = true;
        }
        private bool CanExecuteCommands(object value)
        {
            return Enabled;
        }
        private void ExecuteUserInputCommand(object value)
        {
            _handler?.RaiseUserInput(new InstrumentSettingEventArgs(_name, float.Parse(value as string)));
        }
        private void _handler_OnSettingChanged(object sender, InstrumentSettingEventArgs e)
        {
            if (e.SettingName == _name)
            {
                UserSelection = (float)e.Value;
            }
        }
    }
}
