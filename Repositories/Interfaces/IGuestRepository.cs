using RestrurantPG.Models;

namespace RestrurantPG.Repositories.Interfaces
{
    public interface IGuestRepository
    {
        Task<List<Guest>> GetAllGuestsAsync();
        Task<Guest> GetGuestByEmailAsync(string Email);
        Task<Guest> GetGuestByIdAsync(int id);
        Task<Guest> AddNewGuestAsync(Guest guest);
        //Task<Guest> UpdateGuest(Guest guest); Behövs inte då man inte uppdaterar gästens information!!
        //Task<bool> DeleteGuest(int id); Behövs inte då man inte tar bort gästen !!

    }
}
