using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestrurantPG.DTOs.GuestDTOs;
using RestrurantPG.Models;
using RestrurantPG.Services.Interfaces;

namespace RestrurantPG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService guestService;

        public GuestController(IGuestService _guestService)
        {
            guestService = _guestService;
        }

        [HttpGet("GetAllGuests")]
        [Authorize]
        public async Task<IActionResult> GetAllGuests()
        {
            var guests = await guestService.GetAllGuestsAsync();

            if (!guests.Success)
            {
                return NotFound(new { guests.Success, guests.Message });
            }

            return Ok(guests.Guests);
        }

        [HttpGet("GetByEmail/{email}")]
        [Authorize]
        public async Task<IActionResult> GetGuestByEmail(string email)
        {
            var guest = await guestService.GetGuestByEmailAsync(email);

            if (!guest.Success)
            {
                return NotFound(new {guest.Success, guest.Message});
            }

            return Ok(guest.Guest);
        }

        [HttpGet("GetByid/{id}")]
        [Authorize]
        public async Task<IActionResult> GetGuestById(int id)
        {
            var guest = await guestService.GetGuestByIdAsync(id);

            if (!guest.Success)
            {
                return NotFound(new { guest.Success, guest.Message });
            }

            return Ok(guest.Guest);
        }

        [HttpPost("AddNewGuest")]
        [Authorize]
        public async Task<IActionResult> AddNewGuest(GuestDTO guest)
        {
            var newGuest = await guestService.AddNewGuestAsync(guest);

            if (!newGuest.Success)
            {
                return BadRequest(new { newGuest.Success, newGuest.Message});
            }

            return Ok(newGuest.Guest);
        }


    }
}