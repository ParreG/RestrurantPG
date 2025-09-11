using RestrurantPG.DTOs.TableDTOs;
using RestrurantPG.Models;

namespace RestrurantPG.Services.Interfaces
{
    public interface ITableService
    {
        public Task<(bool Success, List<Table?> Tables, string? Message)> GetAllTablesAsync();
        public Task<(bool Success, Table? Table, string? Message)> GetTableBynumberAsync(int tablenumber);
        public Task<(bool Success, Table? Table, string? Message)> GetTableByIdAsync(int id);
        public Task<(bool Success, Table? Table, string? Message)> AddTableAsync(TableDTO tableDTO);
        public Task<(bool Success, Table? Table, string? Message)> UpdateTableAsync(int tableNumber, UpdateTableDTO updateTableDTO);
        public Task<(bool Success, Table? Table, string? Message)> DeleteTableAsync(int tablenumber);
        public Task<(bool Success, List<Table>? Tables, string Message)> GetAvailableTablesAsync(DateTime bookingStart, int numberOfGuests);
        public Task<(bool Success, List<Table>? Tables, string Message)> UpdateTablePositionsAsync(List<TablePositionDTO> updates);

    }
}
