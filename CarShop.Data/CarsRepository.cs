using Data.Base.Contract;
using Data.Base.Implementation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace CarShop.Data
{
    public class CarsRepository : BaseRepository<CarEntity, CarShopContext>
    {
        public CarsRepository(CarShopContext context) : base(context)
        {
        }
    }
}
