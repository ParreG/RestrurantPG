using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestrurantPG.DTOs.BookingDTOs;
using RestrurantPG.Services.Interfaces;

namespace RestrurantPG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService bookingService;

        public BookingController(IBookingService _bookingService)
        {
            bookingService = _bookingService;
        }


        [HttpGet("GetAllBookings")]
        [Authorize]
        public async Task<IActionResult> GetAllBookings()
        {
            var result = await bookingService.GetAllBookingsAsync();

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Bookings);
        }

        [HttpGet("GetBookingById/{id}")]
        [Authorize]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var result = await bookingService.GetBookingByIdAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Booking);
        }

        [HttpPost("AddNewBooking")]
        public async Task<IActionResult> AddBooking(NewBookingDTO bookingDTO)
        {
            var result = await bookingService.AddBookingAsync(bookingDTO);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return CreatedAtAction(nameof(GetBookingById),
                    new { id = result.Booking.Booking_Id },
            new
            {
                Message = "Din bokning är skapad!",
                result.Booking.Booking_Id,
                result.Booking.NumberOfGuests,
                result.Booking.BookingStart,
                TableNumber = result.Booking.Table.Number
            });

        }

        [HttpPut("UpdateBooking/{id}")]
        public async Task<IActionResult> UpdateBooking(int id, UpdateBookingDTO bookingDTO)
        {
            var result = await bookingService.UpdateBookingAsync(id, bookingDTO);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Booking);
        }


        [HttpDelete("DeleteBooking/{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var result = await bookingService.DeleteBookingAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Booking);
        }
    }
}

