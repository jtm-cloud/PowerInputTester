using PowerInputTester.Commands;
using PowerInputTester.Events;
using System.Windows.Input;

namespace PowerInputTester.Controls
{
    public class DockItem
    {
        #region Private Fields
        private UIEventManager _handler;
        #endregion

        public string Name { get; set; }
        public ICommand SelectionCommand { get; set; }
        public DockItem(string name, UIEventManager handler)
        {
            Name = name;
            _handler = handler;
            SelectionCommand = new RelayCommand(RaiseItemSelection, CanExecuteItemSelection);
        }

        private bool CanExecuteItemSelection(object value)
        {
            return true;
        }
        private void RaiseItemSelection(object value)
        {
            _handler?.OnSideDockItemSelected(new UISelectionEventArgs(Name));
        }
    }
}
