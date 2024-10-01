using PowerInputTester.UI.ViewModels.PowerSupply;
using System;
using System.Windows.Controls;

namespace PowerInputTester.UI.Views.PowerSupply
{
    /// <summary>
    /// Interaction logic for CurrentLimitPanelView.xaml
    /// </summary>
    public partial class CurrentLimitPanelView : UserControl
    {
        public CurrentLimitPanelView()
        {
            InitializeComponent();
        }
        private void OnCompleted(object sender, EventArgs e)
        {
            CurrentLimitPanelViewModel vm = (CurrentLimitPanelViewModel)DataContext;
            vm.Enabled = false;
        }
    }
}
