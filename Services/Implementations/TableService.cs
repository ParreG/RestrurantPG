using RestrurantPG.DTOs.TableDTOs;
using RestrurantPG.Models;
using RestrurantPG.Repositories.Interfaces;
using RestrurantPG.Services.Interfaces;

namespace RestrurantPG.Services.Implementations
{
    public class TableService : ITableService
    {
        private readonly ITableRepository tableRepository;

        public TableService(ITableRepository _tableRepository)
        {
            tableRepository = _tableRepository;
        }

        public async Task<(bool Success, List<Table?> Tables, string? Message)> GetAllTablesAsync()
        {
            var allTables = await tableRepository.GetAllTablesAsync();

            if (allTables.Count == 0)
            {
                return (false, null, "Inga bord hittades");
            }

            return (true, allTables, "Dessa bord hittades!");
        }

        public async Task<(bool Success, Table? Table, string? Message)> GetTableBynumberAsync(int tablenumber)
        {
            var table = await tableRepository.GetTableBynumberAsync(tablenumber);

            if (table == null)
            {
                return (false, null, "Den aktuella bordsnummret hittades inte!");
            }

            return (true, table, $"Bordet med nummer {tablenumber} hittades!");
        }

        public async Task<(bool Success, Table? Table, string? Message)> GetTableByIdAsync(int id)
        {
            var table = await tableRepository.GetTableByIdAsync(id);
            
            if (table == null)
            {
                return (false, null, "Den aktuella bordsnummret hittades inte!");
            }

            return (true, table, $"Bordet med id:et {id} hittades!");
        }

        public async Task<(bool Success, Table? Table, string? Message)> AddTableAsync(TableDTO tableDTO)
        {
            var newTable = new Table
            {
                Number = tableDTO.Number,
                Capacity = tableDTO.Capacity,
            };

            var addedTable = await tableRepository.AddTableAsync(newTable);

            if (addedTable == null)
            {
                return (false, null, "Den aktuella bordet kunde inte läggas till!");
            }

            return (true, addedTable, "bordet har lagts till!");
        }

        public async Task<(bool Success, Models.Table? Table, string? Message)> UpdateTableAsync(int tableNumber, UpdateTableDTO updateTableDTO)
        {
            var table = await tableRepository.GetTableBynumberAsync(tableNumber);

            if (table == null)
            {
                return (false, null, "bordets nummer kunde inte hittas!");
            }

            table.Capacity = updateTableDTO.Capacity;

            await tableRepository.UpdateTableAsync(table);
            return (true, table, "Bordets kapacitet har uppdateradts!");
        }

        public async Task<(bool Success, Models.Table? Table, string? Message)> DeleteTableAsync(int tablenumber)
        {
            var table = await tableRepository.GetTableBynumberAsync(tablenumber);

            if (table == null)
            {
                return (false, null, "Den aktuella bordet kunde inte hittas");
            }

            await tableRepository.DeleteTableAsync(tablenumber);
            return (true, null, "Den aktuella bordet har tagits bort!");
        }

        public async Task<(bool Success, List<Table>? Tables, string Message)> GetAvailableTablesAsync(DateTime bookingStart, int numberOfGuests)
        {
            var tables = await tableRepository.GetAvailableTablesAsync(bookingStart, numberOfGuests);

            if (!tables.Any())
            {
                return (false, null, "Inga lediga bord hittades.");
            }

            return (true, tables, "Lediga bord hämtade.");
        }

        public async Task<(bool Success, List<Table>? Tables, string Message)> UpdateTablePositionsAsync(List<TablePositionDTO> updates)
        {
            if (updates == null || !updates.Any())
                return (false, null, "Inga uppdateringar skickades");

            var updatedTables = await tableRepository.UpdateTablePositionsAsync(updates);
            return (true, updatedTables, "Bordens positioner uppdaterades");
        }
    }
}
