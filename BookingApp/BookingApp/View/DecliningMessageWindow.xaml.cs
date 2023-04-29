using BookingApp.Model;
using System.Windows;

namespace BookingApp.View
{
    /// <summary>
    /// Interaction logic for DecliningMessageWindow.xaml
    /// </summary>
    public partial class DecliningMessageWindow : Window
    {
        private HotelsReservationsPage parent;
        private Reservation reservation;
        public DecliningMessageWindow(HotelsReservationsPage parent, Reservation reservation)
        {
            InitializeComponent();
            this.parent = parent;
            ReservationDate.Text = reservation.Date.ToString();
            ReservationApartment.Text = reservation.ApartmentName;
            ReservationHotel.Text = reservation.HotelCode;
            this.reservation = reservation;
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (MessageInput.Text == "")
            {
                MessageBox.Show("Message is required!");
                return;
            }
            reservation.Message = MessageInput.Text;
            if (parent.DeclineReservation(reservation))
            {
                Close();
            }
            else
            {
                MessageBox.Show("Something went wrong!");
            }
        }
    }
}
