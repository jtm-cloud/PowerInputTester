using PowerInputTester.UI.Commands;
using PowerInputTester.UI.Events;
using System.Windows.Input;

namespace PowerInputTester.UI.Models
{
    public class DockItem
    {
        #region Private Fields
        private UIEventHandler _handler;
        #endregion

        public string Name { get; set; }
        public ICommand SelectionCommand { get; set; }
        public DockItem(string name, UIEventHandler handler)
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
            _handler?.RaiseSideDockItemSelected(new UISelectionEventArgs(Name));
        }
    }
}
