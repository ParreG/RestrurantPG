using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestrurantPG.DTOs.DishDTOs;
using RestrurantPG.Models;
using RestrurantPG.Services.Implementations;
using RestrurantPG.Services.Interfaces;

namespace RestrurantPG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly IDishService dishService;

        public DishController(IDishService _dishService)
        {
            dishService = _dishService;
        }

        [HttpGet("GetAllDishes")]
        [Authorize]
        public async Task<IActionResult> GetAllDishes()
        {
            var result = await dishService.GetAllDishesAsync();

            if (!result.Success)
            {
                return NotFound(result.Massage);
            }

            return Ok(result.Item2); 
        }

        [HttpGet("GetDishById/{id}")]
        [Authorize]
        public async Task<IActionResult> GetDishById(int id)
        {
            var result = await dishService.GetDishByIdAsync(id);

            if (!result.Success)
            {
                return NotFound(result.Massage);
            }

            return Ok(result.Dish);
        }

        [HttpPost("AddDish")]
        [Authorize]
        public async Task<IActionResult> AddDish(NewDishDTO dishDTO)
        {
            var result = await dishService.AddDishAsync(dishDTO);

            if (!result.Success)
            {
                return BadRequest(result.Massage);
            }

            return CreatedAtAction(nameof(GetDishById), new { id = result.Dish!.Dish_Id }, result.Dish);
        }

        [HttpPut("UpdateDish/{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateDish(int id, Dish dish)
        {
            var result = await dishService.UpdateDishAsync(id, dish);

            if (!result.Success)
            {
                return NotFound(result.Message);
            }

            return Ok(result.Dish);
        }

        [HttpDelete("DeleteDish/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteDish(int id)
        {
            var existingDish = await dishService.GetDishByIdAsync(id);
            if (!existingDish.Success)
            {
                return NotFound(existingDish.Massage);
            }

            var result = await dishService.DeleteDishAsync(existingDish.Dish!);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}