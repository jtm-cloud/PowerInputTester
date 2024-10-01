using CommonHelpers.GuardClauses;
using PowerInputTester.UI.Abstract;
using PowerInputTester.UI.Controls;
using PowerInputTester.UI.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerInputTester.UI.ViewModels
{
    public class PowerSupplyControlViewModel : ViewModelBase
    {
        #region Backing Fields
        ObservableCollection<object> _controls;
        UIEventHandler _handler;
        bool _isVisible;
        #endregion
        public ObservableCollection<object> Controls
        {
            get { return _controls; }
            set { SetProperty(ref _controls, value); }
        }
        public bool IsVisible
        {
            get { return _isVisible; }
            set { SetProperty(ref _isVisible, value); }
        }
        public PowerSupplyControlViewModel(ICollection<object> controls, UIEventHandler handler)
        {
            GuardClause.NullReference(handler, "handler");
            _handler = handler;
            Controls = new ObservableCollection<object>(controls);
        }
    }
}
