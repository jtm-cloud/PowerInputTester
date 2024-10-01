using PowerInputTester.UI.ViewModels.PowerSupply;
using System;
using System.Windows.Controls;

namespace PowerInputTester.UI.Views.PowerSupply
{
    /// <summary>
    /// Interaction logic for OutputModePanelView.xaml
    /// </summary>
    public partial class OutputModePanelView : UserControl
    {
        public OutputModePanelView()
        {
            InitializeComponent();
        }
        private void OnCompleted(object sender, EventArgs e)
        {
            OutputModePanelViewModel vm = (OutputModePanelViewModel)DataContext;
            vm.Enabled = false;
        }
    }
}
