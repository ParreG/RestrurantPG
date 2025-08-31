using RestrurantPG.DTOs.GuestDTOs;
using RestrurantPG.DTOs.TableDTOs;
using RestrurantPG.Models;
using RestrurantPG.Repositories.Interfaces;
using RestrurantPG.Services.Interfaces;

namespace RestrurantPG.Services.Implementations
{
    public class GuestService : IGuestService
    {
        private readonly IGuestRepository guestRepository;

        public GuestService(IGuestRepository _guestRepository)
        {
            guestRepository = _guestRepository;
        }

        public async Task<(bool Success, List<Guest?> Guests, string? Message)> GetAllGuestsAsync()
        {
            var allGuests = await guestRepository.GetAllGuestsAsync();

            if (allGuests.Count == 0)
            {
                return (false, new List<Guest>(), "Hittade inga registrerade gäster.");
            }

            return (true, allGuests, "Gäster hittades!");
        }
        public async Task<(bool Success, Guest? Guest, string? Message)> GetGuestByEmailAsync(string email)
        {
            var guest = await guestRepository.GetGuestByEmailAsync(email);

            if (guest == null)
            {
                return (false, null, "Hittade inte den aktuella mejladressen!");
            }

            return (true, guest, "Användaren hittades!");
        }

        public async Task<(bool Success, Guest? Guest, string? Message)> GetGuestByIdAsync(int id)
        {
            var guest = await guestRepository.GetGuestByIdAsync(id);

            if (guest == null)
            {
                return (false, null, "Hittade inte den aktuella id:et!");
            }

            return (true, guest, "Användaren hittades!");
        }

        public async Task<(bool Success, Guest? Guest, string? Message)> AddNewGuestAsync(GuestDTO guestDto)
        {
            var existingGuest = await guestRepository.GetGuestByEmailAsync(guestDto.Email);

            if (existingGuest == null)
            {
                var guest = new Guest
                {
                    Name = guestDto.Name,
                    LastName = guestDto.LastName,
                    Email = guestDto.Email,
                    Tel = guestDto.Tel
                };

                var newGuest = await guestRepository.AddNewGuestAsync(guest);

                if (newGuest == null)
                {
                    return (false, null, "Användaren kunte inte läggas till!");
                }

                return (true, newGuest, "Användaren har lagts till!");
            }

            return (true, existingGuest, "Gästen finns i databasen redan");
        }
    }
}
