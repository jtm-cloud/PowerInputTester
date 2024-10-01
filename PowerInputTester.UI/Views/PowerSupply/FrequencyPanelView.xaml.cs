
using PowerInputTester.UI.ViewModels.PowerSupply;
using System.Windows.Controls;

namespace PowerInputTester.UI.Views.PowerSupply
{
    /// <summary>
    /// Interaction logic for FrequencyPanelView.xaml
    /// </summary>
    public partial class FrequencyPanelView : UserControl
    {
        public FrequencyPanelView()
        {
            InitializeComponent();
        }

        private void OnSubCompleted(object sender, System.EventArgs e)
        {
            if (DataContext != null)
            {
                FrequencyPanelViewModel vm = (FrequencyPanelViewModel)DataContext;
                vm.TargetSetting.Enabled = false;
                if (vm.SettingsCount > 0)
                {
                    vm.SettingsCount -= 1;
                }
            }
        }
    }
}
