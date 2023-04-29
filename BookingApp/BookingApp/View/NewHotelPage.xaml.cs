using BookingApp.Controller;
using BookingApp.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace BookingApp.View
{
    /// <summary>
    /// Interaction logic for NewHotelPage.xaml
    /// </summary>
    public partial class NewHotelPage : Page
    {
        private UsersWindow parent;
        private HotelController hotelController;
        private UserController userController;
        public NewHotelPage(UsersWindow parent)
        {
            InitializeComponent();
            this.DataContext = this;
            this.parent = parent;
            var app = Application.Current as App;
            hotelController = app.HotelController;
            userController = app.UserController;
            OwnersJMBGs = userController.GetOwnersJMBG();
        }

        public List<string> OwnersJMBGs { get; set; }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (CodeInput.Text == "" || NameInput.Text == "" || YearInput.Text == "" || StarsInput.Text == "" || OwnersJMBGInput.Text == "")
            {
                MessageBox.Show("All fields are required!");
                return;
            }
            int desc = 0;
            if (!Int32.TryParse(YearInput.Text, out desc) || !Int32.TryParse(StarsInput.Text, out desc))
            {
                MessageBox.Show("Year of building and Stars rating must be integer number!");
                return;
            }
            if (!hotelController.CreateHotel(new Hotel(CodeInput.Text, NameInput.Text, Int32.Parse(YearInput.Text), new Dictionary<string, Apartment>(), Int32.Parse(StarsInput.Text), OwnersJMBGInput.Text, false)))
            {
                MessageBox.Show("Hotel code is already taken!");
                return;
            }
            parent.MainFrame.Content = new HotelsPage(parent);
        }
    }
}
