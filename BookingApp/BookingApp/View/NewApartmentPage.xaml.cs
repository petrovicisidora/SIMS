using BookingApp.Controller;
using BookingApp.Model;
using System;
using System.Windows;
using System.Windows.Controls;

namespace BookingApp.View
{
    /// <summary>
    /// Interaction logic for NewApartmentPage.xaml
    /// </summary>
    public partial class NewApartmentPage : Page
    {
        private UsersWindow parent;
        private Hotel hotel;
        private ApartmentController apartmentController;
        public NewApartmentPage(UsersWindow parent, Hotel hotel)
        {
            InitializeComponent();
            this.DataContext = this;
            this.parent = parent;
            this.hotel = hotel;
            var app = Application.Current as App;
            this.apartmentController = app.ApartmentController;
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (NameInput.Text == "" || DescInput.Text == "" || RoomsInput.Text == "" || CapacityInput.Text == "")
            {
                MessageBox.Show("All fields are required!");
                return;
            }
            int desc = 0;
            if (!Int32.TryParse(RoomsInput.Text, out desc) || !Int32.TryParse(CapacityInput.Text, out desc))
            {
                MessageBox.Show("Rooms Count and Capacity must be integer numbers!");
                return;
            }
            if (!apartmentController.CreateNewApartment(new Apartment(NameInput.Text, DescInput.Text, Int32.Parse(RoomsInput.Text), Int32.Parse(CapacityInput.Text)), hotel))
            {
                MessageBox.Show("Apartments name is already taken!");
                return;
            }
            else
            {
                parent.MainFrame.Content = new HotelsPage(parent);
            }
        }
    }
}
