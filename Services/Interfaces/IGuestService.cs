using RestrurantPG.DTOs.GuestDTOs;
using RestrurantPG.Models;

namespace RestrurantPG.Services.Interfaces
{
    public interface IGuestService
    {
        public Task<(bool Success, List<Guest?> Guests, string? Message)> GetAllGuestsAsync();
        public Task<(bool Success, Guest? Guest, string? Message)> GetGuestByEmailAsync(string email);
        public Task<(bool Success, Guest? Guest, string? Message)> GetGuestByIdAsync(int id);
        public Task<(bool Success, Guest? Guest, string? Message)> AddNewGuestAsync(GuestDTO guestDto);

    }
}
