using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Data.Base.Implementation;

namespace CarShop.Data
{
    public class CarEntity : EntityBase
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public double? EnginePower { get; set; }
        public string? EngineType { get; set; }
        public short? CylindersCount { get; set; }
        public string Color { get; set; }
        public DateTime DateProduced { get; set; }
        public int AvailableCount { get; set; }
        public byte[]? Photo { get; set; }
    }
}