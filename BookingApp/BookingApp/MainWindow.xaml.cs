using BookingApp.View;
using System.Windows;

namespace BookingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var newMenu = new LoginPage(this);
            MainFrame.Content = newMenu;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var newMenu = new LoginPage(this);
            MainFrame.Content = newMenu;
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var newMenu = new RegisterPage(this);
            MainFrame.Content = newMenu;
        }

        public void SwitchFrameToLogin()
        {
            var newMenu = new LoginPage(this);
            MainFrame.Content = newMenu;
        }
    }
}
