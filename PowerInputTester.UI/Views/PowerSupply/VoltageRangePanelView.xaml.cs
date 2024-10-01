using PowerInputTester.UI.ViewModels.PowerSupply;
using System.Windows.Controls;

namespace PowerInputTester.UI.Views.PowerSupply
{
    /// <summary>
    /// Interaction logic for VoltageRangePanelView.xaml
    /// </summary>
    public partial class VoltageRangePanelView : UserControl
    {
        public VoltageRangePanelView()
        {
            InitializeComponent();
        }
        private void OnCompleted(object sender, System.EventArgs e)
        {
            VoltageRangePanelViewModel vm = (VoltageRangePanelViewModel)DataContext;
            vm.Enabled = false;
        }
    }
}
