using System.Windows;

namespace BookingApp.View
{
    /// <summary>
    /// Interaction logic for AdministratorsWindow.xaml
    /// </summary>
    public partial class UsersWindow : Window
    {
        public UsersWindow()
        {
            InitializeComponent();
            MainFrame.Content = new HotelsPage(this);
            var app = Application.Current as App;
            HandleAccess(app.LoggedUser.Role);
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new MainWindow();
            newWindow.Show();
            Close();
        }

        private void HotelsButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new HotelsPage(this);
        }

        private void HandleAccess(string role)
        {
            switch (role)
            {
                case "ADMIN":
                    LogoutButton.Visibility = Visibility.Visible;
                    HotelsButton.Visibility = Visibility.Visible;
                    UsersButton.Visibility = Visibility.Visible;
                    UsersReservationsButton.Visibility = Visibility.Collapsed;
                    NewHotelButton.Visibility = Visibility.Visible;
                    MyHotelsButton.Visibility = Visibility.Collapsed;
                    NewOwnerButton.Visibility = Visibility.Visible;
                    break;
                case "OWNER":
                    LogoutButton.Visibility = Visibility.Visible;
                    HotelsButton.Visibility = Visibility.Visible;
                    UsersButton.Visibility = Visibility.Collapsed;
                    UsersReservationsButton.Visibility = Visibility.Collapsed;
                    NewHotelButton.Visibility = Visibility.Collapsed;
                    MyHotelsButton.Visibility = Visibility.Visible;
                    NewOwnerButton.Visibility = Visibility.Collapsed;
                    break;
                case "GUEST":
                    LogoutButton.Visibility = Visibility.Visible;
                    HotelsButton.Visibility = Visibility.Visible;
                    UsersButton.Visibility = Visibility.Collapsed;
                    UsersReservationsButton.Visibility = Visibility.Visible;
                    NewHotelButton.Visibility = Visibility.Collapsed;
                    MyHotelsButton.Visibility = Visibility.Collapsed;
                    NewOwnerButton.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void UsersButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new UsersPage();
        }

        private void UsersReservationsButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new UsersReservationsPage();
        }

        private void MyHotelsButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new MyHotelsPage(this);
        }

        private void NewHotelButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new NewHotelPage(this);
        }

        private void NewOwnerButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new NewOwnerPage(this);
        }
    }
}
