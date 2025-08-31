using RestrurantPG.DTOs.DishDTOs;
using RestrurantPG.Models;

namespace RestrurantPG.Services.Interfaces
{
    public interface IDishService
    {
        public Task <(bool Success, List<Dish>, string? Massage)> GetAllDishesAsync();
        public Task<(bool Success, Dish? Dish, string? Massage)> GetDishByIdAsync(int id);
        public Task<(bool Success, Dish? Dish, string? Massage)> AddDishAsync(NewDishDTO dishDTO);
        public Task<(bool Success, Dish? Dish, string? Message)> UpdateDishAsync(int dishId, Dish dish);
        public Task<(bool Success, Dish? Dish, string? Message)> DeleteDishAsync(Dish dish);
    }
}
