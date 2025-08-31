using RestrurantPG.DTOs.BookingDTOs;
using RestrurantPG.DTOs.GuestDTOs;
using RestrurantPG.Models;
using RestrurantPG.Repositories.Interfaces;
using RestrurantPG.Services.Interfaces;

namespace RestrurantPG.Services.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository bookingRepository;
        private readonly ITableService tableService;
        private readonly IGuestService guestService;

        public BookingService(IBookingRepository _bookingRepository, ITableService _tableService, IGuestService _guestService)
        {
            bookingRepository = _bookingRepository;
            tableService = _tableService;
            guestService = _guestService;
        }

        public async Task<(bool Success, List<Booking>? Bookings, string Message)> GetAllBookingsAsync()
        {
            var allBookings = await bookingRepository.GetAllBookingsAsync();

            if (allBookings.Count == 0)
            {
                return (false, null, "Inga bokningar hittades.");
            }

            return (true, allBookings, "Listar alla bokningar!");
        }

        public async Task<(bool Success, Booking? Booking, string Message)> GetBookingByIdAsync(int id)
        {
            var booking = await bookingRepository.GetBookingByIdAsync(id);

            if (booking == null)
            {
                return (false, null, "Dena aktuella bokningen hittades inte.");
            }

            return (true, booking, "Hittade bookningen!");
        }

        public async Task<(bool Success, Booking? Booking, string Message)> AddBookingAsync(NewBookingDTO bookingDTO)
        {
            var existingGuest = await guestService.GetGuestByEmailAsync(bookingDTO.Email);
            Guest? guest;

            if (!existingGuest.Success || existingGuest.Guest == null)
            {
                var newGuestDto = new GuestDTO
                {
                    Name = bookingDTO.Name,
                    Email = bookingDTO.Email,
                    LastName = bookingDTO.LastName,
                    Tel = bookingDTO.Tel,
                };

                var newGuest = await guestService.AddNewGuestAsync(newGuestDto);

                if (!newGuest.Success || newGuest.Guest == null)
                {
                    return (false, null, "Kunde inte spara kontaktuppgifterna. Vänligen kontakta resturangen!");
                }

                guest = newGuest.Guest;
            }
            else
            {
                guest = existingGuest.Guest;
            }

            if (guest == null)
            {
                return (false, null, "Kunde inte identifiera/registrera gäst.");
            }

            var bookingStart = bookingDTO.BookingStart;
            var bookingEnd = bookingStart.AddHours(2);

            var availableTables = await tableService.GetAvailableTablesAsync(bookingStart, bookingDTO.NumberOfGuests);

            if (!availableTables.Success || availableTables.Tables == null || !availableTables.Tables.Any())
            {
                return (false, null, "Inget ledigt bord hittades!");
            }

            // väljer bord med minst platser kvar efter bokningen!
            var chosenTable = availableTables.Tables
                .OrderBy(t => t.Capacity - bookingDTO.NumberOfGuests)
                .ThenBy(t => t.Capacity)
                .FirstOrDefault();

            if (chosenTable == null)
            {
                return (false, null, "Inget ledigt bord hittades!");
            }

            var newBooking = new Booking
            {
                BookingStart = bookingStart,
                BookingEnd = bookingEnd,
                NumberOfGuests = bookingDTO.NumberOfGuests,
                TableId_Fk = chosenTable.Table_Id,
                GuestId_Fk = guest.Guest_Id
            };

            var booking = await bookingRepository.AddBookingAsync(newBooking);
            return (true, booking, "Bokningen har lagts till!"); 
        }

        public async Task<(bool Success, Booking? Booking, string Message)> UpdateBookingAsync(int bookingId, UpdateBookingDTO bookingDTO)
        {
            var booking = await bookingRepository.GetBookingByIdAsync(bookingId);

            if (booking == null || booking.Guest.Email.Trim().ToLower() != bookingDTO.Email.Trim().ToLower())
            {
                return (false, null, "Bokningen hittades inte, eller så stämmer inte mejladressen med bokningen!");
            }

            booking.NumberOfGuests = bookingDTO.NumberOfGuests;
            booking.BookingStart = bookingDTO.BookingStart;

            await bookingRepository.UpdateBookingAsync(booking);

            return (true, booking, "Bookningen har nu uppdaterats");

        }

        public async Task<(bool Success, Booking? Booking, string Message)> DeleteBookingAsync(int bookingId, string email)
        {
            var booking = await bookingRepository.GetBookingByIdAsync(bookingId);

            if (booking == null || booking.Guest.Email.Trim().ToLower() != email.Trim().ToLower())
            {
                return (false, null, "Bokningen hittades inte, eller så stämmer inte mejladressen med bokningen!");
            }

            await bookingRepository.DeleteBookingAsync(booking);
            return (true, booking, "Bokningen har raderats!");
        }
    }
}
