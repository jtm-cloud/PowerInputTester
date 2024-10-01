using PowerInputTester.Controls;
using System;
using System.Collections.ObjectModel;

namespace PowerInputTester.ViewModels
{
    public class SideDockViewModel : ViewModelBase
    {
        #region Private Fields
        ObservableCollection<DockItem> _items;
        #endregion

        public string Name { get; set; }

        /// <summary>
        /// This collection stores the names of the items to be listed in the dock panel.
        /// </summary>
        public ObservableCollection<DockItem> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SideDockViewModel(string name, UIEventManager handler)
        {
            Name = name;
            using(DockItemFactory factory = new DockItemFactory())
            {
                Items = new ObservableCollection<DockItem>(factory.Create(name, handler));
            }
        }

    }
}
