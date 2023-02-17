using AutoMapper;
using CarShop.Data;
using CarShop.Dto;
using CarShop.Service.Contract;
using Data.Base.Contract;

namespace CarShop.Service.Implementation
{
    public class CarService : ICarService
    {
        private readonly IBaseRepository<CarEntity> _carRepository;
        private readonly IMapper _mapper;

        public CarService(IBaseRepository<CarEntity> carRepository,
            IMapper mapper) {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public Task Delete(int? id)
        {
            return _carRepository.Delete(id);
        }

        public async Task<List<CarDto>> GetAllAsync()
        {
            var result = await _carRepository.GetAllAsync();
            var mappedResult = result.Select(_mapper.Map<CarDto>).ToList();
            return mappedResult;
        }

        public async Task<CarDto> GetById(int? id)
        {
            var result = await _carRepository.GetById(id);
            var mappedResult = _mapper.Map<CarDto>(result);
            return mappedResult;
        }

        public Task Insert(CarDto carDto)
        {
            var carEntity = _mapper.Map<CarEntity>(carDto);
            FillPhoto(carDto, carEntity);
            return _carRepository.Insert(carEntity);
        }

        public Task Update(CarDto carDto)
        {
            var carEntity = _mapper.Map<CarEntity>(carDto);
            FillPhoto(carDto, carEntity);
            return _carRepository.Update(carEntity);
        }

        private void FillPhoto(CarDto carDto, CarEntity carEntity)
        {
            if (carDto.Photo != null)
            {
                byte[]? imageData = null;
                using (var binaryReader = new BinaryReader(carDto.Photo.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)carDto.Photo.Length);
                }
                carEntity.Photo = imageData;
            }
        }
    }
}