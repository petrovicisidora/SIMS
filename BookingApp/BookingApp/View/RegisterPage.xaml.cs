using BookingApp.Controller;
using BookingApp.Model;
using System.Windows;
using System.Windows.Controls;

namespace BookingApp.View
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        private MainWindow parent;
        private UserController userController;
        public RegisterPage(MainWindow parent)
        {
            InitializeComponent();
            this.parent = parent;
            var app = Application.Current as App;
            userController = app.UserController;
        }

        private void Confirm_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (JMBGInput.Text == "" || EmailInput.Text == "" || PasswordInput.Password == "" || NameInput.Text == "" || SurnameInput.Text == "" || PhoneInput.Text == "")
            {
                MessageBox.Show("All fields are required!");
                return;
            }
            if (userController.Register(new User(JMBGInput.Text, EmailInput.Text, PasswordInput.Password, NameInput.Text, SurnameInput.Text, PhoneInput.Text, "GUEST", false)))
            {
                MessageBox.Show("Registration succeed!");
                parent.SwitchFrameToLogin();
                return;
            }
            MessageBox.Show("Email or JMBG is already taken!");
            PasswordInput.Password = "";
            return;
        }
    }
}
