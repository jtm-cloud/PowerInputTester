using PowerInputTester.UI.Abstract;
using PowerInputTester.UI.Events;
using PowerInputTester.UI.Models;
using System.Collections.Generic;

namespace PowerInputTester.UI.ViewModels
{
    public class DoubleOptionSettingViewModel : ViewModelBase, IInstrumentControlPanel
    {
        #region Backing Fields
        string _name;
        bool _enabled;
        SettingOption _firstOption;
        SettingOption _secondOption;
        #endregion

        public bool Enabled
        {
            get { return _enabled; }
            set { SetProperty(ref _enabled, value); }
        }
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        public SettingOption FirstOption
        {
            get { return _firstOption; }
            set { SetProperty(ref _firstOption, value); }
        }
        public SettingOption SecondOption
        {
            get { return _secondOption; }
            set { SetProperty(ref _secondOption, value); }
        }
        public DoubleOptionSettingViewModel(string settingName, IList<string> optionNames, UIEventHandler handler)
        {
            Name = settingName;
            FirstOption = new SettingOption(optionNames[0], settingName, handler);
            SecondOption = new SettingOption(optionNames[1], settingName, handler);
        }
    }
}
