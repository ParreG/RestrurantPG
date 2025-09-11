using Microsoft.EntityFrameworkCore;
using RestrurantPG.Data;
using RestrurantPG.DTOs.TableDTOs;
using RestrurantPG.Models;

namespace RestrurantPG.Repositories.Interfaces
{
    public interface ITableRepository
    {
        Task<List<Table>> GetAllTablesAsync();
        Task<Table> GetTableBynumberAsync(int tablenumber);
        Task<Table> GetTableByIdAsync(int id);
        Task<Table> AddTableAsync(Table table);
        Task<Table> UpdateTableAsync(Table table);
        Task<bool> DeleteTableAsync(int tablenumber);
        Task<List<Table>> GetAvailableTablesAsync(DateTime bookingStart, int numberOfGuests);
        Task<List<Table>> UpdateTablePositionsAsync(List<TablePositionDTO> updates);
    }
}
