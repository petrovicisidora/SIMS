using BookingApp.Controller;
using BookingApp.Model;
using BookingApp.Model.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace BookingApp.View
{
    /// <summary>
    /// Interaction logic for HotelsPage.xaml
    /// </summary>
    public partial class HotelsPage : Page, INotifyPropertyChanged
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
        private string selectedType = "Code";
        private string apartmentsSelectedType = "Rooms";
        private UsersWindow parent;
        public HotelsPage(UsersWindow parent)
        {
            InitializeComponent();
            this.DataContext = this;
            var app = Application.Current as App;
            this.hotelController = app.HotelController;
            this.Hotels = new ObservableCollection<Hotel>(hotelController.GetAll());
            this.parent = parent;
        }

        public event PropertyChangedEventHandler PropertyChanged;
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

        public List<string> SearchTypes { get; set; } = new List<string>() { "Code", "Name", "Year of building", "Stars", "Apartments" };
        public string SelectedType
        {
            get
            {
                return selectedType;
            }
            set
            {
                if (value != selectedType)
                {
                    selectedType = value;
                    if (selectedType == "Apartments")
                    {
                        ApartmentsSearchType.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        ApartmentsSearchType.Visibility = Visibility.Collapsed;
                    }
                    OnPropertyChanged("SelectedType");
                }
            }
        }
        public string ApartmentsSelectedType
        {
            get
            {
                return apartmentsSelectedType;
            }
            set
            {
                if (value != apartmentsSelectedType)
                {
                    apartmentsSelectedType = value;
                    if (ApartmentsSelectedType == "Rooms & Guests")
                    {
                        SearchValue.Visibility = Visibility.Collapsed;
                        ApartmentsSearchValues.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        SearchValue.Visibility = Visibility.Visible;
                        ApartmentsSearchValues.Visibility = Visibility.Collapsed;
                    }
                    OnPropertyChanged("ApartmentsSelectedType");
                }
            }
        }
        public List<string> ApartmentSearchTypes { get; set; } = new List<string>() { "Rooms", "Guests", "Rooms & Guests" };

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            var hotel = (Hotel)datagrid.SelectedItem;
            parent.MainFrame.Content = new ApartmentsPage(hotel, parent);
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            int dest = 0;
            if (SelectedType == "Year of building" || SelectedType == "Stars")
            {
                if (!Int32.TryParse(SearchValue.Text, out dest))
                {
                    MessageBox.Show("Search value must be integer number!");
                    return;
                }
            }
            else if (SelectedType == "Apartments")
            {
                if (ApartmentsSelectedType == "Rooms & Guests")
                {
                    if (!Int32.TryParse(FirstValue.Text, out dest) || !Int32.TryParse(SecondValue.Text, out dest))
                    {
                        MessageBox.Show("Search values must be integer numbers!");
                        return;
                    }
                }
                else
                {
                    if (!Int32.TryParse(SearchValue.Text, out dest))
                    {
                        MessageBox.Show("Search value must be integer numbers!");
                        return;
                    }
                }
            }
            string searchType = SelectedType;
            string searchValue = SelectedType == "Apartments" && ApartmentsSelectedType == "Rooms & Guests" ? FirstValue.Text : SearchValue.Text;
            string additionalSearchType = SelectedType == "Apartments" ? ApartmentsSelectedType : null;
            string additionalSearchValue = SelectedType == "Apartments" && ApartmentsSelectedType == "Rooms & Guests" ? SecondValue.Text : null;
            bool connection = OR_AND.Content.ToString() != "|";
            var query = new HotelsSearchQuery(searchType, searchValue, additionalSearchType, additionalSearchValue, connection);
            Hotels = new ObservableCollection<Hotel>(hotelController.GetAll(query));
        }

        private void OR_AND_Click(object sender, RoutedEventArgs e)
        {
            OR_AND.Content = OR_AND.Content.ToString() == "|" ? "&" : "|";
        }
    }
}
