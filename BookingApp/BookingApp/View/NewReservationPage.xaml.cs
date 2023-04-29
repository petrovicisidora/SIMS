using BookingApp.Controller;
using BookingApp.Model;
using System;
using System.Windows;
using System.Windows.Controls;

namespace BookingApp.View
{
    /// <summary>
    /// Interaction logic for NewReservationPage.xaml
    /// </summary>
    public partial class NewReservationPage : Page
    {
        private ReservationController reservationController;
        private UsersWindow parent;
        public NewReservationPage(UsersWindow parent, string hotelCode, string apartmentName)
        {
            InitializeComponent();
            var app = Application.Current as App;
            reservationController = app.ReservationController;
            this.parent = parent;
            HotelInput.Text = hotelCode;
            ApartmentInput.Text = apartmentName;
            JMBGInput.Text = app.LoggedUser.JMBG;
            DateInput.Text = DateTime.Now.ToShortDateString();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            DateTime selectedDate = DateTime.Parse(DateInput.Text);
            if (DateTime.Compare(selectedDate, DateTime.Now) < 0)
            {
                MessageBox.Show("Date must be in future!");
                return;
            }
            if (!reservationController.MakeReservation(new Reservation(JMBGInput.Text, selectedDate, HotelInput.Text, ApartmentInput.Text, false, null)))
            {
                MessageBox.Show("Apartment is already reserved for selected date, please select another one!");
                return;
            }
            parent.MainFrame.Content = new HotelsPage(parent);
        }
    }
}
