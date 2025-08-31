using Microsoft.EntityFrameworkCore;
using RestrurantPG.Data;
using RestrurantPG.Models;
using RestrurantPG.Repositories.Interfaces;

namespace RestrurantPG.Repositories.Implementations
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDBContext context;

        public BookingRepository(AppDBContext _context)
        {
            context = _context;
        }

        public async Task<List<Booking>> GetAllBookingsAsync()
        {
            var allBookings = await context.Bookings
                .Include(b => b.Guest)
                .Include(b => b.Table)
                .ToListAsync();

            return allBookings;
        }

        public async Task<Booking?> GetBookingByIdAsync(int id)
        {
            return await context.Bookings
                .Include(b => b.Guest)
                .Include(b => b.Table)
                .FirstOrDefaultAsync(b => b.Booking_Id == id);
        }

        public async Task<Booking?> AddBookingAsync(Booking booking)
        {
            await context.Bookings.AddAsync(booking);
            await context.SaveChangesAsync();
            return booking;
        }

        public async Task<Booking?> UpdateBookingAsync(Booking booking)
        {
            context.Bookings.Update(booking);
            await context.SaveChangesAsync();
            return booking;
        }

        public async Task<bool> DeleteBookingAsync(Booking booking)
        {
            context.Bookings.Remove(booking);
            await context.SaveChangesAsync();
            return true;
        }

    }
}
