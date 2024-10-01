using System;
using System.Windows;
using System.Windows.Controls;

namespace PowerInputTester.UI.Views.PowerSupply
{
    /// <summary>
    /// Interaction logic for PowerSupplyControlView.xaml
    /// </summary>
    public partial class PowerSupplyControlView : UserControl
    {
        public PowerSupplyControlView()
        {
            InitializeComponent();
        }

        private void OnSlideRightCompleted(object sender, EventArgs e)
        {
            MainGrid.Visibility = Visibility.Collapsed;
        }

        private void DoubleAnimation_Completed(object sender, EventArgs e)
        {
            MainGrid.Visibility = Visibility.Collapsed;
        }
    }
}
