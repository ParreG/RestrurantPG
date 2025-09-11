namespace RestrurantPG.DTOs.TableDTOs
{
    public class TablePositionDTO
    {
        public int TableNumber { get; set; }
        public int? X { get; set; }
        public int? Y { get; set; }
    }

    public class BatchTablePositionUpdateDTO
    {
        public List<TablePositionDTO> Updates { get; set; } = new();
    }
}
