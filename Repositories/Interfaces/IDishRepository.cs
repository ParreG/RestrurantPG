using RestrurantPG.DTOs.DishDTOs;
using RestrurantPG.Models;

namespace RestrurantPG.Repositories.Interfaces
{
    public interface IDishRepository
    {
        public Task<List<Dish>> GetAllDishesAsync();
        public Task<Dish?> GetDishByIdAsync(int id);
        public Task<Dish?> AddDishAsync(NewDishDTO dishDTO);
        public Task<Dish?> UpdateDishAsync(Dish dish);
        public Task<bool> DeleteDishAsync(Dish dish);
    }
}
