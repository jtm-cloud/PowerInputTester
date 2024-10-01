using PowerInputTester.UI.ViewModels.PowerSupply;
using System.Windows.Controls;
using System;

namespace PowerInputTester.UI.Views.PowerSupply
{
    /// <summary>
    /// Interaction logic for OutputStatePanelView.xaml
    /// </summary>
    public partial class OutputStatePanelView : UserControl
    {
        public OutputStatePanelView()
        {
            InitializeComponent();
        }
        private void OnCompleted(object sender, EventArgs e)
        {
            OutputStatePanelViewModel vm = (OutputStatePanelViewModel)DataContext;
            vm.Enabled = false;
        }
    }
}
