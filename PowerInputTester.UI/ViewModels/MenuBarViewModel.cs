using PowerInputTester.UI.Abstract;
using PowerInputTester.UI.Controls;
using PowerInputTester.UI.Events;
using PowerInputTester.UI.Models;
using System.Collections.ObjectModel;

namespace PowerInputTester.UI.ViewModels
{
    public class MenuBarViewModel : ViewModelBase
    {
        ObservableCollection<MenuItem> _items;
        public ObservableCollection<MenuItem> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }
        public MenuBarViewModel(UIEventHandler handler)
        {
            using (MenuItemFactory factory = new MenuItemFactory())
            {
                Items = new ObservableCollection<MenuItem>()
                {
                    new MenuItem("File", handler),
                    new MenuItem("Edit", handler),
                    new MenuItem("View", handler),
                    new MenuItem("Test", handler),
                    new MenuItem("Help", handler)
                };
            }
        }
    }
}
