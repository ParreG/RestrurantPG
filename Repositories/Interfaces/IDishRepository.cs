using RestrurantPG.DTOs.DishDTOs;
using RestrurantPG.Models;

namespace RestrurantPG.Repositories.Interfaces
{
    public interface IDishRepository
    {
        Task<List<Dish>> GetAllDishesAsync();
        Task<Dish?> GetDishByIdAsync(int id);
        Task<Dish?> AddDishAsync(NewDishDTO dishDTO);
        Task<Dish?> UpdateDishAsync(Dish dish);
        Task<bool> DeleteDishAsync(Dish dish);
    }
}
