using Microsoft.EntityFrameworkCore;
using RestrurantPG.Data;
using RestrurantPG.Models;

namespace RestrurantPG.Repositories.Interfaces
{
    public interface ITableRepository
    {
        public Task<List<Table>> GetAllTablesAsync();
        public Task<Table> GetTableBynumberAsync(int tablenumber);
        public Task<Table> GetTableByIdAsync(int id);
        public Task<Table> AddTableAsync(Table table);
        public Task<Table> UpdateTableAsync(Table table);
        public Task<bool> DeleteTableAsync(int tablenumber);
        public Task<List<Table>> GetAvailableTablesAsync(DateTime bookingStart, int numberOfGuests);
    }
}
