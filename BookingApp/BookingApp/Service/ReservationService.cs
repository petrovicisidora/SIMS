using BookingApp.Model;
using BookingApp.Repository;
using System.Collections.Generic;
using System.Linq;

namespace BookingApp.Service
{
    public class ReservationService
    {
        private IReservationRepository reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }

        public IEnumerable<Reservation> GetUsersReservations(string jmbg)
        {
            return reservationRepository.GetByUsersJMBG(jmbg);
        }

        public IEnumerable<Reservation> GetHotelsReservations(string code)
        {
            return reservationRepository.GetAll().Where(r => r.HotelCode == code);
        }

        public bool MakeReservation(Reservation reservation)
        {
            var check = reservationRepository.GetByHotelsCodeAndApartment(reservation.HotelCode, reservation.ApartmentName).Where(r => r.Date == reservation.Date && r.Approved).FirstOrDefault();
            if (check != null)
            {
                return false;
            }
            reservationRepository.Create(reservation);
            return true;
        }

        public bool CancelReservation(Reservation reservation)
        {
            return reservationRepository.Delete(reservation);
        }

        public bool ApproveReservation(Reservation reservation)
        {
            var check = reservationRepository.GetByHotelsCodeAndApartment(reservation.HotelCode, reservation.ApartmentName).Where(r => r.Date == reservation.Date && r.Approved).FirstOrDefault();
            if (check != null)
            {
                return false;
            }
            reservation.Approved = true;
            reservationRepository.Update(reservation);
            return true;
        }

        public bool DeclineReservation(Reservation reservation)
        {
            var check = reservationRepository.GetAll().Where(r => r.Id == reservation.Id).FirstOrDefault();
            if (check == null)
            {
                return false;
            }
            reservation.Approved = false;
            reservationRepository.Update(reservation);
            return true;
        }
    }
}
