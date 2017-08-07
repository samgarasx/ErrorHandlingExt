using ErrorHandlingExt.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorHandlingExt.Samples.Data
{
    public class CarRepository
    {
        public Result<IEnumerable<Car>> GetCars()
        {
            return Result<IEnumerable<CarEntity>>.From(CloudDatabase.GetCars)
                .Map(cars => cars.Select(car => new Car
                {
                    Id = car.Id,
                    Brand = car.Brand,
                    Model = car.Model,
                }));
        }

        public async Task<Result<IEnumerable<Car>>> GetCarsAsync()
        {
            return await Task.FromResult(
                Result<IEnumerable<CarEntity>>.From(CloudDatabase.GetCars)
                .Map(cars => cars.Select(car => new Car
                {
                    Id = car.Id,
                    Brand = car.Brand,
                    Model = car.Model,
                })));
        }

        public Result<Car> GetCar(int id)
        {
            return Result<CarEntity>.From(() => CloudDatabase.GetCar(id))
                .Map(car => new Car
                {
                    Id = car.Id,
                    Brand = car.Brand,
                    Model = car.Model,
                });
        }

        public async Task<Result<Car>> GetCarAsync(int id)
        {
            return await Task.FromResult(Result<CarEntity>.From(() => CloudDatabase.GetCar(id))
                .Map(car => new Car
                {
                    Id = car.Id,
                    Brand = car.Brand,
                    Model = car.Model,
                }));
        }
    }
}
