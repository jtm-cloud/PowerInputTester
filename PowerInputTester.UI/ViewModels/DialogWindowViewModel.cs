using PowerInputTester.UI.Abstract;

namespace PowerInputTester.UI.ViewModels
{
    public class DialogWindowViewModel : ViewModelBase
    {
        #region Backing Fields

        object _activeViewModel;

        #endregion
        public object ActiveViewModel
        {
            get { return _activeViewModel; }
            set { SetProperty(ref _activeViewModel, value); }
        }
        public DialogWindowViewModel()
        {
            
        }
    }
}
