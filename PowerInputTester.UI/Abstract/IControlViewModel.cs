using PowerInputTester.UI.Models;
using System.Collections.ObjectModel;

namespace PowerInputTester.UI.Abstract
{
    public interface IControlViewModel
    {
        string Name { get; }
        ObservableCollection<Setting> Settings { get; }
    }
}
