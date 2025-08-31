using RestrurantPG.Models;

namespace RestrurantPG.Repositories.Interfaces
{
    public interface IGuestRepository
    {
        public Task<List<Guest>> GetAllGuestsAsync();
        public Task<Guest> GetGuestByEmailAsync(string Email);
        public Task<Guest> GetGuestByIdAsync(int id);
        public Task<Guest> AddNewGuestAsync(Guest guest);
        //public Task<Guest> UpdateGuest(Guest guest); Behövs inte då man inte uppdaterar gästens information!!
        //public Task<bool> DeleteGuest(int id); Behövs inte då man inte tar bort gästen !!

    }
}
