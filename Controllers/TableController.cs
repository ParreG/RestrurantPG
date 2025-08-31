using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestrurantPG.DTOs.TableDTOs;
using RestrurantPG.Services.Interfaces;

namespace RestrurantPG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableService tableService;

        public TableController(ITableService _TableService)
        {
            tableService = _TableService;
        }

        [HttpGet("GetAllTables")]
        [Authorize]
        public async Task<IActionResult> GetAllTables()
        {
            var allTables = await tableService.GetAllTablesAsync();

            if (!allTables.Success)
            {
                return NotFound(allTables.Message);
            }

            return Ok(allTables.Tables);
        }

        [HttpGet("GetTableByNumber/{number}")]
        [Authorize]
        public async Task<IActionResult> GetTableByNumber(int number)
        {
            var table = await tableService.GetTableBynumberAsync(number);

            if (!table.Success)
            {
                return NotFound(table.Message);
            }

            return Ok(table.Table);
        }

        [HttpGet("GetTableById/{id}")]
        [Authorize]
        public async Task<IActionResult> GetTableById(int id)
        {
            var table = await tableService.GetTableByIdAsync(id);

            if (!table.Success)
            {
                return NotFound(table.Message);
            }

            return Ok(table.Table);
        }

        [HttpPost("AddTable")]
        [Authorize]
        public async Task<IActionResult> AddNewTable(TableDTO tableDTO)
        {
            var newTable = await tableService.AddTableAsync(tableDTO);

            if (!newTable.Success)
            {
                return BadRequest(newTable.Message);
            }

            return Ok(newTable.Table);
        }

        [HttpPut("UpdateTable/{tableNumber}")]
        [Authorize]
        public async Task<IActionResult> UpdateTable(int tableNumber, UpdateTableDTO updateTable)
        {
            var newTable = await tableService.UpdateTableAsync(tableNumber, updateTable);

            if (!newTable.Success)
            {
                return BadRequest(newTable.Message);
            }

            return Ok(newTable.Table);
        }

        [HttpDelete("DeleteTable/{tableNumber}")]
        [Authorize]
        public async Task<IActionResult> DeleteTable(int tableNumber)
        {
            var table = await tableService.DeleteTableAsync(tableNumber);

            if (!table.Success)
            {
                return BadRequest(table.Message);
            }

            return Ok(table.Success);
        }

        [HttpGet("GetAvailbleTables!")]
        public async Task<IActionResult> GetAvailableTables([FromQuery] DateTime bookingStart, [FromQuery] int numberOfGuests)
        {
            var result = await tableService.GetAvailableTablesAsync(bookingStart, numberOfGuests);

            if (!result.Success)
            {
                return NotFound(result.Message);
            }

            return Ok(result.Tables);
        }
    }
}
