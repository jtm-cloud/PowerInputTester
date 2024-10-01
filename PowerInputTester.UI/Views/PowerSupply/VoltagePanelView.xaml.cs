using PowerInputTester.UI.ViewModels.PowerSupply;
using System.Windows.Controls;

namespace PowerInputTester.UI.Views.PowerSupply
{
    /// <summary>
    /// Interaction logic for VoltagePanelView.xaml
    /// </summary>
    public partial class VoltagePanelView : UserControl
    {
        public VoltagePanelView()
        {
            InitializeComponent();
        }
        private void OnSubCompleted(object sender, System.EventArgs e)
        {
            if (DataContext != null)
            {
                VoltagePanelViewModel vm = (VoltagePanelViewModel)DataContext;
                vm.TargetSetting.Enabled = false;
                if (vm.SettingsCount > 0)
                {
                    vm.SettingsCount -= 1;
                }
            }
        }
    }
}
