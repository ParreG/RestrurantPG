using RestrurantPG.DTOs.DishDTOs;
using RestrurantPG.Models;
using RestrurantPG.Repositories.Interfaces;
using RestrurantPG.Services.Interfaces;

namespace RestrurantPG.Services.Implementations
{
    public class DishService : IDishService
    {
        private readonly IDishRepository DishRepository;

        public DishService(IDishRepository _repository)
        {
            DishRepository = _repository;
        }

        public async Task<(bool Success, List<Dish>, string? Massage)> GetAllDishesAsync()
        {
            var dishes = await DishRepository.GetAllDishesAsync();

            if (dishes.Count == 0)
            {
                return (true, new List<Dish>(), "Inga maträtter hittades!");
            }

            return (true, dishes, "Listar alla maträtter.");
        }

        public async Task<(bool Success, Dish? Dish, string? Massage)> GetDishByIdAsync(int id)
        {
            var dish = await DishRepository.GetDishByIdAsync(id);

            if (dish == null)
            {
                return (false, null, "Den aktuella maträtten hittades inte!");
            }

            return (true, dish, "Tar fram den aktuella maträtten!");
        }

        public async Task<(bool Success, Dish? Dish, string? Massage)> AddDishAsync(NewDishDTO dishDTO)
        {
            var newDish = await DishRepository.AddDishAsync(dishDTO);

            if (newDish == null)
            {
                return (false, null, "Maträtten lades inte till. Testa igen!");
            }

            return (true, newDish, "Maträtten är tillagd!");
        }

        public async Task<(bool Success, Dish? Dish, string? Message)> UpdateDishAsync(int dishId, Dish dish)
        {
            var oldDish = await DishRepository.GetDishByIdAsync(dishId);
            if (oldDish == null)
            {
                return (false, null, "Kunnde inte hitta rätt maträtt med den angivna id:et!");
            }

            dish.Dish_Id = dishId;

            var updatedDish = await DishRepository.UpdateDishAsync(dish);

            return (true, updatedDish, "Maträtt är nu uppdaterad!");
        }



        public async Task<(bool Success, Dish? Dish, string? Message)> DeleteDishAsync(Dish dish)
        {
            var existingDish = await DishRepository.GetDishByIdAsync(dish.Dish_Id);
            if (existingDish == null)
            {
                return (false, null, "Kunnde inte hitta rätt maträtt med den angivna id:et!");
            }

            var deleted = await DishRepository.DeleteDishAsync(existingDish);

            if (!deleted)
            {
                return (false, null, "Lyckades inte radera maträtten!");
            }

            return (true, existingDish, "Maträtten är nu raderad!");
        }

    }
}
