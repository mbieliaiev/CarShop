using Data.Base.Implementation;

namespace CarShop.Data
{
    public class CarsRepository : BaseRepository<CarEntity, CarShopContext>
    {
        public CarsRepository(CarShopContext context) : base(context)
        {
        }
    }
}
