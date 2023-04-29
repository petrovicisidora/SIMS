using BookingApp.Controller;
using BookingApp.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace BookingApp.View
{
    /// <summary>
    /// Interaction logic for UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page, INotifyPropertyChanged
    {
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private UserController userController;
        private ObservableCollection<User> users;
        private User selectedUser;
        private string selectedRole = "BOTH";
        public UsersPage()
        {
            InitializeComponent();
            this.DataContext = this;
            var app = Application.Current as App;
            userController = app.UserController;
            Users = new ObservableCollection<User>(userController.GetAll());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public List<string> Roles { get; set; } = new List<string>() { "BOTH", "GUEST", "OWNER" };
        public ObservableCollection<User> Users
        {
            get
            {
                return users;
            }
            set
            {
                if (value != users)
                {
                    users = value;
                    OnPropertyChanged("Users");
                }
            }
        }
        public User SelectedUser
        {
            get
            {
                return selectedUser;
            }
            set
            {
                if (value != selectedUser)
                {
                    selectedUser = value;
                    if (selectedUser != null)
                    {
                        Block.Visibility = Visibility.Visible;
                        Block.IsEnabled = true;
                        if (selectedUser.Blocked)
                        {
                            Block.Content = "UNBLOCK";
                        }
                        else
                        {
                            Block.Content = "BLOCK";
                        }
                    }
                    else
                    {
                        Block.IsEnabled = false;
                        Block.Visibility = Visibility.Collapsed;
                    }
                    OnPropertyChanged("SelectedUser");
                }
            }
        }

        public string SelectedRole
        {
            get
            {
                return selectedRole;
            }
            set
            {
                if (value != selectedRole)
                {
                    selectedRole = value;
                    Users = new ObservableCollection<User>(userController.GetAll(selectedRole));
                    OnPropertyChanged("SelectedRole");
                }
            }
        }

        private void Block_Click(object sender, RoutedEventArgs e)
        {
            if (!userController.ChangeBlocked(selectedUser.JMBG))
            {
                MessageBox.Show("Something went wrong!");
                return;
            }
            Users = new ObservableCollection<User>(userController.GetAll(selectedRole));
        }
    }
}
