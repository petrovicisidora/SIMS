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
    /// Interaction logic for UsersReservationsPage.xaml
    /// </summary>
    public partial class UsersReservationsPage : Page, INotifyPropertyChanged
    {
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private ReservationController reservationController;
        private ObservableCollection<Reservation> reservations;
        private string selectedFilter = "All";
        private string loggedUserJMBG;
        private Reservation selectedReservation;
        public UsersReservationsPage()
        {
            InitializeComponent();
            this.DataContext = this;
            var app = Application.Current as App;
            reservationController = app.ReservationController;
            loggedUserJMBG = app.LoggedUser.JMBG;
            UpdateReservations();
        }
        public List<string> Filters { get; set; } = new List<string>() { "All", "Approved", "Declined", "On Wait" };
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
                        if (DateTime.Compare(selectedReservation.Date, DateTime.Now) < 0)
                        {
                            Cancel.IsEnabled = false;
                        }
                        else
                        {
                            Cancel.IsEnabled = true;
                        }
                    OnPropertyChanged("SelectedReservation");
                }
            }
        }

        private void Details_Click(object sender, RoutedEventArgs e)
        {
            var state = selectedReservation.Approved ? "Approved" : selectedReservation.Message == "" ? "On wait" : "Declined";
            MessageBox.Show($"{state}\n\n{selectedReservation.Message}");
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            if (reservationController.CancelReservation(selectedReservation))
            {
                Reservations = new ObservableCollection<Reservation>(reservationController.GetUsersReservations(loggedUserJMBG));
            }
            else
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private void UpdateReservations()
        {
            var rawReservations = this.reservationController.GetUsersReservations(loggedUserJMBG);
            switch (SelectedFilter)
            {
                case "All":
                    Reservations = new ObservableCollection<Reservation>(rawReservations);
                    break;
                case "Approved":
                    Reservations = new ObservableCollection<Reservation>(rawReservations.Where(r => r.Approved));
                    break;
                case "Declined":
                    Reservations = new ObservableCollection<Reservation>(rawReservations.Where(r => !r.Approved && r.Message != ""));
                    break;
                case "On Wait":
                    Reservations = new ObservableCollection<Reservation>(rawReservations.Where(r => !r.Approved && r.Message == ""));
                    break;
            }
        }
    }
}
