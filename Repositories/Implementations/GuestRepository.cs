using Microsoft.EntityFrameworkCore;
using RestrurantPG.Data;
using RestrurantPG.Models;
using RestrurantPG.Repositories.Interfaces;

namespace RestrurantPG.Repositories.Implementations
{
    public class GuestRepository : IGuestRepository
    {
        private readonly AppDBContext context;

        public GuestRepository(AppDBContext _context)
        {
            context = _context;
        }

        public async Task<List<Guest>> GetAllGuestsAsync()
        {
            var guestList = await context.Guests.ToListAsync();
            return guestList;
        }

        public async Task<Guest> GetGuestByEmailAsync(string Email)
        {
            var guest = await context.Guests.FirstOrDefaultAsync(g => g.Email == Email);
            return guest;
        }

        public async Task<Guest> GetGuestByIdAsync(int id)
        {
            var guest = await context.Guests.FirstOrDefaultAsync(g => g.Guest_Id == id);
            return guest;
        }

        public async Task<Guest> AddNewGuestAsync(Guest guest)
        {
            await context.Guests.AddAsync(guest);
            await context.SaveChangesAsync();
            return guest;
        }

        // Ifall att man vill implementera update guest!!
        //public async Task<Guest> UpdateGuestAsync(Guest guest) 
        //{
        //    context.Guests.Update(guest);
        //    await context.SaveChangesAsync();

        //    return guest;
        //}

        // Ifall att man vill implementera delete guest!!!
        //public async Task<bool> DeleteGuestAsync(int id)
        //{
        //    var guest = await context.Guests.FirstOrDefaultAsync(g => g.Guest_Id == id);

        //    if (guest == null)
        //    {
        //        return false;
        //    }

        //    context.Guests.Remove(guest);

        //    await context.SaveChangesAsync();
        //    return true;
        //}
    }
}
