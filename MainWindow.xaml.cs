using System.Windows;
using System.Windows.Media;
namespace Boosty
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DashboardBtn_Click(object sender, RoutedEventArgs e)
        {
            basicBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#2F3136");
            dashboardBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#36393F");
            AdvancedBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#2F3136");
            CleanUpBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#2F3136");
            RestoreBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#2F3136");
            dashboardBorder.CornerRadius = new CornerRadius(0, 0, 0, 0);
            HeadBorder.CornerRadius = new CornerRadius(20, 0, 20, 0);
            basicBorder.CornerRadius = new CornerRadius(0, 20, 0, 0);
            AdvancedBorder.CornerRadius = new CornerRadius(0, 0, 0, 0);
            RestoreBorder.CornerRadius = new CornerRadius(0, 0, 0, 0);
            CleanUpBorder.CornerRadius = new CornerRadius(0, 0, 0, 0);
            restBorder.CornerRadius = new CornerRadius(0, 0, 0, 20);

        }
        private void BasicBtn_Click(object sender, RoutedEventArgs e)
        {
            basicBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#36393F");
            dashboardBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#2F3136");
            AdvancedBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#2F3136");
            CleanUpBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#2F3136");
            RestoreBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#2F3136");

            dashboardBorder.CornerRadius = new CornerRadius(0, 0, 20, 0);
            HeadBorder.CornerRadius = new CornerRadius(20, 0, 0, 0);
            basicBorder.CornerRadius = new CornerRadius(0, 0, 0, 0);
            AdvancedBorder.CornerRadius = new CornerRadius(0, 20, 0, 0);
            RestoreBorder.CornerRadius = new CornerRadius(0, 0, 0, 0);
            CleanUpBorder.CornerRadius = new CornerRadius(0, 0, 0, 0);
            restBorder.CornerRadius = new CornerRadius(0, 0, 0, 20);
        }

        private void AdvancedBtn_Click(object sender, RoutedEventArgs e)
        {
            basicBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#2F3136");
            dashboardBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#2F3136");
            AdvancedBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#36393F");
            CleanUpBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#2F3136");
            RestoreBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#2F3136");
            dashboardBorder.CornerRadius = new CornerRadius(0, 0, 0, 0);
            HeadBorder.CornerRadius = new CornerRadius(20, 0, 0, 0);
            basicBorder.CornerRadius = new CornerRadius(0, 0, 20, 0);
            AdvancedBorder.CornerRadius = new CornerRadius(0, 0, 0, 0);
            RestoreBorder.CornerRadius = new CornerRadius(0, 0, 0, 0);
            CleanUpBorder.CornerRadius = new CornerRadius(0, 20, 0, 0);
            restBorder.CornerRadius = new CornerRadius(0, 0, 0, 20);
        }

        private void CleanBtn_Click(object sender, RoutedEventArgs e)
        {
            basicBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#2F3136");
            dashboardBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#2F3136");
            AdvancedBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#2F3136");
            CleanUpBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#36393F");
            RestoreBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#2F3136");
            dashboardBorder.CornerRadius = new CornerRadius(0, 0, 0, 0);
            HeadBorder.CornerRadius = new CornerRadius(20, 0, 0, 0);
            basicBorder.CornerRadius = new CornerRadius(0, 0, 0, 0);
            AdvancedBorder.CornerRadius = new CornerRadius(0, 0, 20, 0);
            RestoreBorder.CornerRadius = new CornerRadius(0, 20, 0, 0);
            CleanUpBorder.CornerRadius = new CornerRadius(0, 0, 0, 0);
            restBorder.CornerRadius = new CornerRadius(0, 0, 0, 20);
        }
    
        private void RestoreBtn_Click(object sender, RoutedEventArgs e)
        {
            basicBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#2F3136");
            dashboardBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#2F3136");
            AdvancedBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#2F3136");
            CleanUpBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#2F3136");
            RestoreBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#36393F");
            dashboardBorder.CornerRadius = new CornerRadius(0, 0, 0, 0);
            HeadBorder.CornerRadius = new CornerRadius(20, 0, 0, 0);
            basicBorder.CornerRadius = new CornerRadius(0, 0, 0, 0);
            AdvancedBorder.CornerRadius = new CornerRadius(0, 0, 0, 0);
            RestoreBorder.CornerRadius = new CornerRadius(0, 0, 0, 0);
            CleanUpBorder.CornerRadius = new CornerRadius(0, 0, 20, 0);
            restBorder.CornerRadius = new CornerRadius(0, 20, 0, 20);
        }

        private void minimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
