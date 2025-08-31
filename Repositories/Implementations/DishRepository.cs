using Microsoft.EntityFrameworkCore;
using RestrurantPG.Data;
using RestrurantPG.DTOs.DishDTOs;
using RestrurantPG.Models;
using RestrurantPG.Repositories.Interfaces;

namespace RestrurantPG.Repositories.Implementations
{
    public class DishRepository : IDishRepository
    {
        private readonly AppDBContext context;
        public DishRepository(AppDBContext _context)
        {
            context = _context;
        }

        public async Task<List<Dish>> GetAllDishesAsync()
        {
            return await context.Dishes.ToListAsync();
        }

        public async Task<Dish?> GetDishByIdAsync(int id)
        {
            return await context.Dishes.FirstOrDefaultAsync(d => d.Dish_Id == id);
        }

        public async Task<Dish?> AddDishAsync(NewDishDTO dishDTO)
        {
            var newDish = new Dish
            {
                Name = dishDTO.Name,
                Description = dishDTO.Description,
                Price = dishDTO.Price,
                IsPopular = dishDTO.IsPopular,
                PictureUrl = dishDTO.PictureUrl,
            };

            await context.Dishes.AddAsync(newDish);
            await context.SaveChangesAsync();
            return newDish;
        }

        public async Task<Dish?> UpdateDishAsync(Dish dish)
        {
            var existingDish = await context.Dishes.FirstOrDefaultAsync(d => d.Dish_Id == dish.Dish_Id);
            if (existingDish == null)
            {
                return null;
            }

            existingDish.Name = dish.Name;
            existingDish.Description = dish.Description;
            existingDish.Price = dish.Price;
            existingDish.IsPopular = dish.IsPopular;
            existingDish.PictureUrl = dish.PictureUrl;

            await context.SaveChangesAsync();
            return existingDish;
        }

        public async Task<bool> DeleteDishAsync(Dish dish) // Skickar med hela dish. Byt till DTO så id inte går att ändra!
        {
            var existingDish = await context.Dishes.FirstOrDefaultAsync(d => d.Dish_Id == dish.Dish_Id);
            if (existingDish == null)
            {
                return false;
            }

            context.Dishes.Remove(existingDish);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
