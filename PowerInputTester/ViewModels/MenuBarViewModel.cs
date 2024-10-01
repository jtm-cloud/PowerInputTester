using PowerInputTester.Controls;
using System.Collections.ObjectModel;

namespace PowerInputTester.ViewModels
{
    public class MenuBarViewModel : ViewModelBase
    {
        ObservableCollection<MenuItem> _items;
        public ObservableCollection<MenuItem> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }
        public MenuBarViewModel(UIEventManager handler)
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
