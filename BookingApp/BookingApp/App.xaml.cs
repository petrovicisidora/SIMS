using BookingApp.Controller;
using BookingApp.Model;
using BookingApp.Repository;
using BookingApp.Service;
using System;
using System.Windows;

namespace BookingApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static string projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location.Split(new string[] { "bin" }, StringSplitOptions.None)[0];
        private string USER_FILE = projectPath + "\\Data\\users.csv";
        private string APARTMENT_FILE = projectPath + "\\Data\\apartments.csv";
        private string HOTEL_FILE = projectPath + "\\Data\\hotels.csv";
        private string RESERVATION_FILE = projectPath + "\\Data\\reservations.csv";

        private const string CSV_DELIMITER = ";";

        public App()
        {
            var userRepository = new UserRepository(USER_FILE, CSV_DELIMITER);
            var apartmentRepository = new ApartmentRepository(APARTMENT_FILE, CSV_DELIMITER);
            var hotelRepository = new HotelRepository(HOTEL_FILE, CSV_DELIMITER);
            var reservationRepository = new ReservationRepository(RESERVATION_FILE, CSV_DELIMITER);

            var userService = new UserService(userRepository);
            var hotelService = new HotelService(hotelRepository, apartmentRepository);
            var apartmentService = new ApartmentService(hotelRepository, apartmentRepository);
            var reservationService = new ReservationService(reservationRepository);

            UserController = new UserController(userService);
            HotelController = new HotelController(hotelService);
            ApartmentController = new ApartmentController(apartmentService);
            ReservationController = new ReservationController(reservationService);
        }
        public UserController UserController { get; set; }
        public HotelController HotelController { get; set; }
        public ApartmentController ApartmentController { get; set; }
        public ReservationController ReservationController { get; set; }
        public User LoggedUser { get; set; }
    }
}
