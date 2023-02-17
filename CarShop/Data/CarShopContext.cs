//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CarShop.Web.Data
//{
//    public class CarShopContext : DbContext
//    {
//        public DbSet<CarEntity> CarModels { get; set; }

//        public CarShopContext(DbContextOptions<CarShopContext> options)
//            : base(options)
//        {
//            Database.EnsureCreated();
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<CarEntity>().HasData(
//                    new CarEntity {
//                        Id = 1,
//                        Name = "2022 Ferrari SP51", 
//                        DateProduced = new DateTime(2022, 1, 1), 
//                        AvailableCount = 2, 
//                        Color = "#FF0000", 
//                        CylindersCount = 16,
//                        EnginePower = 789,
//                        EngineType = "6,5-V12",
//                        Manufacturer= "Ferrari",
//                    },
//                    new CarEntity {
//                        Id = 2,
//                        Name = "Maserati GranTurismo",
//                        DateProduced = new DateTime(2023, 1, 1),
//                        AvailableCount = 1,
//                        Color = "#FF0000",
//                        EnginePower = 440,
//                        EngineType = "4,7-V8",
//                        Manufacturer = "Maserati",
//                    }
//            );
//        }
//    }
//}
