using BookingApp.Controller;
using BookingApp.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace BookingApp.View
{
    /// <summary>
    /// Interaction logic for MyHotelsPage.xaml
    /// </summary>
    public partial class MyHotelsPage : Page, INotifyPropertyChanged
    {
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private HotelController hotelController;
        private ObservableCollection<Hotel> hotels;
        private Hotel selectedHotel;
        private UsersWindow parent;
        public MyHotelsPage(UsersWindow parent)
        {
            InitializeComponent();
            this.DataContext = this;
            this.parent = parent;
            var app = Application.Current as App;
            hotelController = app.HotelController;
            Hotels = new ObservableCollection<Hotel>(hotelController.GetOwnersHotels(app.LoggedUser.JMBG));
        }

        public ObservableCollection<Hotel> Hotels
        {
            get
            {
                return hotels;
            }
            set
            {
                if (value != hotels)
                {
                    hotels = value;
                    OnPropertyChanged("Hotels");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public Hotel SelectedHotel
        {
            get
            {
                return selectedHotel;
            }
            set
            {
                if (value != selectedHotel)
                {
                    selectedHotel = value;
                    if (selectedHotel != null)
                    {
                        if (selectedHotel.Accepted)
                        {
                            Approve.IsEnabled = false;
                            Delete.IsEnabled = false;
                            Reservations.IsEnabled = true;
                        }
                        else
                        {
                            Approve.IsEnabled = true;
                            Delete.IsEnabled = true;
                            Reservations.IsEnabled = false;
                        }
                    }
                    OnPropertyChanged("SelectedHotel");
                }
            }
        }

        private void Approve_Click(object sender, RoutedEventArgs e)
        {
            var app = App.Current as App;
            if (!hotelController.ApproveHotel(selectedHotel.Code))
            {
                MessageBox.Show("Something went wrong!");
            }
            Approve.IsEnabled = false;
            Delete.IsEnabled = false;
            Hotels = new ObservableCollection<Hotel>(hotelController.GetOwnersHotels(app.LoggedUser.JMBG));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var app = App.Current as App;
            if (!hotelController.DeleteHotel(selectedHotel.Code))
            {
                MessageBox.Show("Something went wrong!");
            }
            Approve.IsEnabled = false;
            Delete.IsEnabled = false;
            Hotels = new ObservableCollection<Hotel>(hotelController.GetOwnersHotels(app.LoggedUser.JMBG));
        }

        private void Reservations_Click(object sender, RoutedEventArgs e)
        {
            parent.MainFrame.Content = new HotelsReservationsPage(selectedHotel);
        }
    }
}
