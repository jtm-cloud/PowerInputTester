using PowerInputTester.Hardware.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerInputTester.UI.Abstract
{
    public class ControlViewModelBase : ViewModelBase
    {
        #region Backing Fields
        string _name;
        ObservableCollection<Setting> _settings;
        #endregion
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        public ObservableCollection<Setting> Settings
        {
            get { return _settings; }
            set { SetProperty(ref _settings, value); }
        }
    }
}
