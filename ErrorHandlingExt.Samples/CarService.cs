using System.Collections.Generic;
using System.Threading.Tasks;
using ErrorHandlingExt.Samples.Data;

namespace ErrorHandlingExt.Samples
{
    public class CarService
    {
        private readonly CarRepository _repository;

        public CarService(CarRepository repository)
        {
            _repository = repository;
        }

        public Result<IEnumerable<Car>> GetCars()
        {
            return _repository.GetCars();
        }

        public async Task<Result<IEnumerable<Car>>> GetCarsAsync()
        {
            return await _repository.GetCarsAsync();
        }

        public Result<Car> GetCar(int id)
        {
            return _repository.GetCar(id);
        }

        public async Task<Result<Car>> GetCarAsync(int id)
        {
            return await _repository.GetCarAsync(id);
        }
    }
}
