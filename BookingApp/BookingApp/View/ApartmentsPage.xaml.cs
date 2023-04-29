using BookingApp.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace BookingApp.View
{
    /// <summary>
    /// Interaction logic for ApartmentsPage.xaml
    /// </summary>
    public partial class ApartmentsPage : Page, INotifyPropertyChanged
    {
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private Apartment selectedApartment;
        private ObservableCollection<Apartment> apartments;
        private UsersWindow parent;
        private Hotel hotel;
        public ApartmentsPage(Hotel hotel, UsersWindow parent)
        {
            InitializeComponent();
            this.DataContext = this;
            var app = Application.Current as App;
            HandleAccess(app.LoggedUser.Role, app.LoggedUser.JMBG == hotel.OwnersJMBG);
            this.hotel = hotel;
            Apartments = new ObservableCollection<Apartment>(hotel.Apartments.Values);
            Code.Text += hotel.Code;
            Name.Text += hotel.Name;
            Stars.Text += hotel.StarsRating;
            this.parent = parent;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Apartment> Apartments
        {
            get
            {
                return apartments;
            }
            set
            {
                if (value != apartments)
                {
                    apartments = value;
                    OnPropertyChanged("Apartments");
                }
            }
        }
        public Apartment SelectedApartment
        {
            get
            {
                return selectedApartment;
            }

            set
            {
                if (value != selectedApartment)
                {
                    selectedApartment = value;
                    if (selectedApartment == null)
                    {
                        Reserve.IsEnabled = false;
                    }
                    else
                    {
                        Reserve.IsEnabled = true;
                    }
                    OnPropertyChanged("SelectedApartment");
                }
            }
        }

        private void AddNew_Click(object sender, RoutedEventArgs e)
        {
            parent.MainFrame.Content = new NewApartmentPage(parent, hotel);
        }

        private void Reserve_Click(object sender, RoutedEventArgs e)
        {
            parent.MainFrame.Content = new NewReservationPage(parent, hotel.Code, selectedApartment.Name);
        }
        private void HandleAccess(string role, bool owner)
        {
            if (role == "GUEST")
            {
                Reserve.Visibility = Visibility.Visible;
            }
            else if (role == "OWNER" && owner)
            {
                AddNew.Visibility = Visibility.Visible;
            }
        }
    }
}
