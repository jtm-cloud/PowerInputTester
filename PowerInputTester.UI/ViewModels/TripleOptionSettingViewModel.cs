using PowerInputTester.Hardware.Controls;
using PowerInputTester.UI.Abstract;
using PowerInputTester.UI.Controls;
using PowerInputTester.UI.Events;
using PowerInputTester.UI.Models;
using System.Collections.Generic;

namespace PowerInputTester.UI.ViewModels
{
    public class TripleOptionSettingViewModel : ViewModelBase, IInstrumentControlPanel
    {
        #region Backing Fields

        bool _enabled;
        SettingOption _firstOption;
        string _name;
        SettingOption _secondOption;
        SettingOption _thirdOption;

        #endregion

        public bool Enabled
        {
            get { return _enabled; }
            set { SetProperty(ref _enabled, value); }
        }
        public SettingOption FirstOption
        {
            get { return _firstOption; }
            set { SetProperty(ref _firstOption, value); }
        }
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        public SettingOption SecondOption
        {
            get { return _secondOption; }
            set { SetProperty(ref _secondOption, value); }
        }
        public SettingOption ThirdOption
        {
            get { return _thirdOption; }
            set { SetProperty(ref _thirdOption, value); }
        }

        public TripleOptionSettingViewModel(string settingName, IList<string> optionNames, UIEventHandler handler)
        {
            Name = settingName;
            FirstOption = new SettingOption(optionNames[0], settingName, handler);
            SecondOption = new SettingOption(optionNames[1], settingName, handler);
            ThirdOption = new SettingOption(optionNames[2], settingName, handler);
        }
    }
}
