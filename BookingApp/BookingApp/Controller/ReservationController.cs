using BookingApp.Model;
using BookingApp.Service;
using System.Collections.Generic;

namespace BookingApp.Controller
{
    public class ReservationController
    {
        private ReservationService reservationService;

        public ReservationController(ReservationService reservationService)
        {
            this.reservationService = reservationService;
        }

        public IEnumerable<Reservation> GetUsersReservations(string jmbg)
        {
            return reservationService.GetUsersReservations(jmbg);
        }

        public bool MakeReservation(Reservation reservation)
        {
            return reservationService.MakeReservation(reservation);
        }

        public bool CancelReservation(Reservation reservation)
        {
            return reservationService.CancelReservation(reservation);
        }

        public IEnumerable<Reservation> GetHotelsReservations(string code)
        {
            return reservationService.GetHotelsReservations(code);
        }

        public bool ApproveReservation(Reservation reservation)
        {
            return reservationService.ApproveReservation(reservation);
        }

        public bool DeclineReservation(Reservation reservation)
        {
            return reservationService.DeclineReservation(reservation);
        }
    }
}
