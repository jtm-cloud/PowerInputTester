using PowerInputTester.UI.ViewModels.PowerSupply;
using System.Windows.Controls;

namespace PowerInputTester.UI.Views.PowerSupply
{
    /// <summary>
    /// Interaction logic for OutputCouplingPanelView.xaml
    /// </summary>
    public partial class OutputCouplingPanelView : UserControl
    {
        public OutputCouplingPanelView()
        {
            InitializeComponent();
        }

        private void OnCompleted(object sender, System.EventArgs e)
        {
            if (DataContext != null)
            {
                OutputCouplingPanelViewModel vm = (OutputCouplingPanelViewModel)DataContext;
                vm.Enabled = false;
            }
        }
    }
}
