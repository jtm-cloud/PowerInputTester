using System;

namespace PowerInputTester.Events
{
    public class UISelectionEventArgs : EventArgs
    {
        private readonly string _name;
        public UISelectionEventArgs(string name)
        {
            _name = name;
        }
        public string Name { get { return _name; } }
    }
}
