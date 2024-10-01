using PowerInputTester.Commands;
using PowerInputTester.Events;
using System.Collections.Generic;
using System.Windows.Input;

namespace PowerInputTester.Controls
{
    public class MenuItem
    {
        #region Private Fields
        private UIEventManager _handler;
        #endregion

        public string Header { get; set; }
        public string IconPath { get; set; }
        public IList<MenuItem> Items { get; set; }
        public ICommand SelectionCommand { get; set; }
        public MenuItem(string header, UIEventManager handler, string iconPath = null)
        {
            Header = header;
            IconPath = iconPath;
            _handler = handler;
            SelectionCommand = new RelayCommand(RaiseItemSelection, CanExecuteItemSelection);
            using (MenuItemFactory factory = new MenuItemFactory())
            {
                Items = new List<MenuItem>(factory.Create(header, handler));
            }
        }
        private bool CanExecuteItemSelection(object value)
        {
            return true;
        }
        private void RaiseItemSelection(object value)
        {
            _handler?.OnMenuBarItemSelected(new UISelectionEventArgs(Header));
        }
    }
}
