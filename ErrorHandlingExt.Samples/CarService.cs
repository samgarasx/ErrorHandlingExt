using ErrorHandlingExt.Samples.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ErrorHandlingExt.Samples
{
    public class CarService
    {
        private readonly CarRepository repository;

        public CarService(CarRepository repository)
        {
            this.repository = repository;
        }

        public Result<IEnumerable<Car>> GetCars()
        {
            return this.repository.GetCars();
        }

        public async Task<Result<IEnumerable<Car>>> GetCarsAsync()
        {
            return await this.repository.GetCarsAsync();
        }

        public Result<Car> GetCar(int id)
        {
            return this.repository.GetCar(id);
        }

        public async Task<Result<Car>> GetCarAsync(int id)
        {
            return await this.repository.GetCarAsync(id);
        }
    }
}
