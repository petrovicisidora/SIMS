using BookingApp.Controller;
using BookingApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BookingApp.View
{
    /// <summary>
    /// Interaction logic for HotelsReservationsPage.xaml
    /// </summary>
    public partial class HotelsReservationsPage : Page, INotifyPropertyChanged
    {
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private string selectedFilter = "All";
        private ReservationController reservationController;
        private ObservableCollection<Reservation> reservations;
        private Reservation selectedReservation;
        private Hotel hotel;
        public HotelsReservationsPage(Hotel hotel)
        {
            InitializeComponent();
            this.DataContext = this;
            var app = Application.Current as App;
            reservationController = app.ReservationController;
            this.hotel = hotel;
            Title.Text = $"{hotel.Name} Reservations";
            UpdateReservations();
        }
        public List<string> Filters { get; set; } = new List<string>() { "All", "Approved", "On Wait" };
        public string SelectedFilter
        {
            get
            {
                return selectedFilter;
            }
            set
            {
                if (selectedFilter != value)
                {
                    selectedFilter = value;
                    UpdateReservations();
                    OnPropertyChanged("SelectedFilter");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Reservation> Reservations
        {
            get
            {
                return reservations;
            }
            set
            {
                if (value != reservations)
                {
                    reservations = value;
                    OnPropertyChanged("Reservations");
                }
            }
        }

        public Reservation SelectedReservation
        {
            get
            {
                return selectedReservation;
            }
            set
            {
                if (value != selectedReservation)
                {
                    selectedReservation = value;
                    if (selectedReservation != null)
                        if (DateTime.Compare(selectedReservation.Date, DateTime.Now) < 0 || selectedReservation.Approved || selectedReservation.Message != "")
                        {
                            Decline.IsEnabled = false;
                            Approve.IsEnabled = false;
                        }
                        else
                        {
                            Decline.IsEnabled = true;
                            Approve.IsEnabled = true;
                        }
                    OnPropertyChanged("SelectedReservation");
                }
            }
        }

        private void Decline_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new DecliningMessageWindow(this, selectedReservation);
            newWindow.Show();
        }

        private void Approve_Click(object sender, RoutedEventArgs e)
        {
            if (reservationController.ApproveReservation(selectedReservation))
            {
                UpdateReservations();
                Decline.IsEnabled = false;
                Approve.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("You have already approved another reservation for this day in this apartment!");
            }
        }

        public bool DeclineReservation(Reservation reservation)
        {
            if (reservationController.DeclineReservation(reservation))
            {
                UpdateReservations();
                Decline.IsEnabled = false;
                Approve.IsEnabled = false;
                return true;
            }
            else
            {
                return false;
            }
        }
        private void UpdateReservations()
        {
            var rawReservations = this.reservationController.GetHotelsReservations(hotel.Code);
            switch (SelectedFilter)
            {
                case "All":
                    Reservations = new ObservableCollection<Reservation>(rawReservations.Where(r => r.Message == ""));
                    break;
                case "Approved":
                    Reservations = new ObservableCollection<Reservation>(rawReservations.Where(r => r.Approved));
                    break;
                case "On Wait":
                    Reservations = new ObservableCollection<Reservation>(rawReservations.Where(r => !r.Approved && r.Message == ""));
                    break;
            }
        }
    }
}
