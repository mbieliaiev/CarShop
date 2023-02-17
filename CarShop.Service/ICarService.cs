using CarShop.Dto;

namespace CarShop.Service.Contract
{
    public interface ICarService
    {
        Task<List<CarDto>> GetAllAsync();
        Task<CarDto> GetById(int? id);
        Task Insert(CarDto carDto);
        Task Update(CarDto carDto);
        Task Delete(int? id);
    }
}