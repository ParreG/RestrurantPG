using Microsoft.EntityFrameworkCore;
using RestrurantPG.Data;
using RestrurantPG.DTOs.TableDTOs;
using RestrurantPG.Models;
using RestrurantPG.Repositories.Interfaces;
using System.Linq;

namespace RestrurantPG.Repositories.Implementations
{
    public class TableRepository : ITableRepository
    {
        private readonly AppDBContext context;

        public TableRepository(AppDBContext _context)
        {
            context = _context;
        }

        public async Task<List<Table>> GetAllTablesAsync()
        {
            var allTables = await context.Tables.ToListAsync();

            return allTables;
        }

        public async Task<Table> GetTableBynumberAsync(int tablenumber)
        {
            var table = await context.Tables.FirstOrDefaultAsync(t => t.Number == tablenumber);
            return table;
        }

        public async Task<Table> GetTableByIdAsync(int id)
        {
            var table = await context.Tables.FirstOrDefaultAsync(t => t.Table_Id == id);
            return table;
        }

        public async Task<Table> AddTableAsync(Table table)
        {
            await context.Tables.AddAsync(table);
            await context.SaveChangesAsync();
            return table;
        }

        public async Task<Table> UpdateTableAsync(Table table)
        {
            context.Tables.Update(table);
            await context.SaveChangesAsync();
            return table;
        }

        public async Task<bool> DeleteTableAsync(int tablenumber)
        {
            var table = await context.Tables.FirstOrDefaultAsync(t => t.Number == tablenumber); // Denna gör jag redan i service D;. Kom ihåg och ta bort!

            context.Tables.Remove(table);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Table>> GetAvailableTablesAsync(DateTime bookingStart, int numberOfGuests)
        {
            var bookingEnd = bookingStart.AddHours(2);

            var candidateTables = await context.Tables
                .Where(t => t.Capacity >= numberOfGuests)
                .ToListAsync();

            var conflictingBookings = await context.Bookings
                .Where(b =>
                    bookingStart < b.BookingStart.AddHours(2) &&
                    bookingEnd > b.BookingStart.AddHours(-2))
                .ToListAsync();

            var occupiedTableIds = conflictingBookings.Select(b => b.TableId_Fk).ToHashSet();
            var freeTables = candidateTables
                .Where(t => !occupiedTableIds.Contains(t.Table_Id))
                .ToList();

            return freeTables;
        }

        public async Task<List<Table>> UpdateTablePositionsAsync(List<TablePositionDTO> updates)
        {
            var numbers = updates.Select(u => u.TableNumber).ToList();
            var tables = await context.Tables
                .Where(t => numbers.Contains(t.Number))
                .ToListAsync();

            foreach (var update in updates)
            {
                var table = tables.FirstOrDefault(t => t.Number == update.TableNumber);
                if (table != null)
                {
                    table.X = update.X;
                    table.Y = update.Y;
                }
            }

            await context.SaveChangesAsync();
            return tables;
        }


    }
}
