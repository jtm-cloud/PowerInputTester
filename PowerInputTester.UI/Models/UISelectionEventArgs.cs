
namespace PowerInputTester.UI.Models
{
    public class UISelectionEventArgs
    {
        private readonly string _name;
        public UISelectionEventArgs(string name)
        {
            _name = name;
        }
        public string Name { get { return _name; } }
    }
}
