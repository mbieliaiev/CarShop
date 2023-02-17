using Microsoft.AspNetCore.Http;

namespace CarShop.Dto
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public double? EnginePower { get; set; }
        public string? EngineType { get; set; }
        public short? CylindersCount { get; set; }
        public string Color { get; set; }
        public DateTime DateProduced { get; set; }
        public int AvailableCount { get; set; }
        public IFormFile? Photo { get; set; }
        public byte[]? PhotoBytes { get; set; }
    }
}