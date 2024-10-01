using PowerInputTester.Commands;
using System.Windows.Input;

namespace PowerInputTester.Models
{
    public class Setting
    {
        #region Private Fields

        private object _handler;
        #endregion
        public string Name { get; }
        public object Value { get; }
        public ICommand UserInputCommand { get; set; }
        public Setting(string name, object handler)
        {
            _handler = handler;
            Name = name;
            UserInputCommand = new RelayCommand(UpdateSetting, CanUpdateSetting);
        }

        private bool CanUpdateSetting(object value)
        {
            return true;
        }
        private void UpdateSetting(object value)
        {

        }
    }
}
