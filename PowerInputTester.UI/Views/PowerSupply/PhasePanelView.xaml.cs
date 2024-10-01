using PowerInputTester.UI.ViewModels.PowerSupply;
using System.Windows.Controls;

namespace PowerInputTester.UI.Views.PowerSupply
{
    /// <summary>
    /// Interaction logic for PhasePanelView.xaml
    /// </summary>
    public partial class PhasePanelView : UserControl
    {
        public PhasePanelView()
        {
            InitializeComponent();
        }
        private void OnCompleted(object sender, System.EventArgs e)
        {
            if (DataContext != null)
            {
                PhasePanelViewModel vm = (PhasePanelViewModel)DataContext;
                vm.Enabled = false;
            }
        }
    }
}
