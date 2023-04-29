using BookingApp.Controller;
using System.Windows;
using System.Windows.Controls;

namespace BookingApp.View
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private MainWindow parent;
        private UserController userController;
        private int failedLoginCounter = 0;
        public LoginPage(MainWindow parent)
        {
            InitializeComponent();
            this.parent = parent;
            var app = Application.Current as App;
            userController = app.UserController;
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (EmailInput.Text == "" || PasswordInput.Password == "")
            {
                MessageBox.Show("All fields are required!");
                return;
            }
            var user = userController.Login(EmailInput.Text, PasswordInput.Password);
            if (user != null)
            {
                var app = Application.Current as App;
                app.LoggedUser = user;
                var newWindow = new UsersWindow();
                newWindow.Show();
                parent.Close();
            }
            else
            {
                MessageBox.Show("Bad Credentials or Account blocked!");
                PasswordInput.Password = "";
                if (++failedLoginCounter >= 3)
                {
                    parent.Close();
                }
            }
        }
    }
}
