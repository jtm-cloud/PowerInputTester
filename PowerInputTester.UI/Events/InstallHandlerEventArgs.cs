using System;

namespace PowerInputTester.UI.Events
{
    public class InstallHandlerEventArgs : EventArgs
    {
        private readonly object _handler;
        public InstallHandlerEventArgs(object handler)
        {
            _handler = handler;
        }
        public object Handler { get { return _handler; } }
    }
}
