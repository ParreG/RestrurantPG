using RestrurantPG.Models;

namespace RestrurantPG.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetAllBookingsAsync();
        Task<Booking?> GetBookingByIdAsync(int id);
        Task<Booking?> AddBookingAsync(Booking booking);
        Task<Booking?> UpdateBookingAsync(Booking booking);
        Task<bool> DeleteBookingAsync(Booking booking);
    }
}
