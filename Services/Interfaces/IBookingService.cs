using RestrurantPG.DTOs.BookingDTOs;
using RestrurantPG.Models;

namespace RestrurantPG.Services.Interfaces
{
    public interface IBookingService
    {
        public Task<(bool Success, List<Booking>? Bookings, string Message)> GetAllBookingsAsync();
        public Task<(bool Success, Booking? Booking, string Message)> GetBookingByIdAsync(int id);
        public Task<(bool Success, Booking? Booking, string Message)> AddBookingAsync(NewBookingDTO bookingDTO);
        public Task<(bool Success, Booking? Booking, string Message)> UpdateBookingAsync(int bookingId, UpdateBookingDTO bookingDTO);
        public Task<(bool Success, Booking? Booking, string Message)> DeleteBookingAsync(int bookingId);
    }
}
