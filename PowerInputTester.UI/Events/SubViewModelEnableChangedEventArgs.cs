
namespace PowerInputTester.UI.Events
{
    public class SubViewModelEnableChangedEventArgs
    {
        #region Backing Fields

        private readonly bool _enabled;

        #endregion

        public bool Enabled { get { return _enabled; } }

        public SubViewModelEnableChangedEventArgs(bool enabled)
        {
            _enabled = enabled;
        }
    }
}
