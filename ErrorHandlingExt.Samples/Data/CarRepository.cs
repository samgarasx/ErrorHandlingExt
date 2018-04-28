using ErrorHandlingExt.Extensions;
using ErrorHandlingExt.Extensions.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorHandlingExt.Samples.Data
{
    public class CarRepository
    {
        public Result<IEnumerable<Car>> GetCars()
        {
            return Result<IEnumerable<CarEntity>>.From(() => Database.GetCars())
                .Map(cars => cars.Select(car => new Car
                {
                    Id = car.Id,
                    Brand = car.Brand,
                    Model = car.Model
                }));
        }

        public Result<IEnumerable<Car>> GetCars(string brand)
        {
            return Result<IEnumerable<CarEntity>>.From(() => Database.GetCars(brand))
                .Map(cars => cars.Select(car => new Car
                {
                    Id = car.Id,
                    Brand = car.Brand,
                    Model = car.Model
                }));
        }

        public async Task<Result<IEnumerable<Car>>> GetCarsAsync()
        {
            await Task.Delay(2000);

            return await Result<IEnumerable<CarEntity>>.FromAsync(() => Database.GetCars())
                .Map(cars => cars.Select(car => new Car
                {
                    Id = car.Id,
                    Brand = car.Brand,
                    Model = car.Model
                }));
        }

        public Result<Car> GetCar(int id)
        {
            return Result<CarEntity>.From(() => Database.GetCar(id))
                .Map(car => new Car
                {
                    Id = car.Id,
                    Brand = car.Brand,
                    Model = car.Model
                });
        }

        public async Task<Result<Car>> GetCarAsync(int id)
        {
            await Task.Delay(2000);

            return await Result<CarEntity>.FromAsync(() => Database.GetCar(id))
                .Map(car => new Car
                {
                    Id = car.Id,
                    Brand = car.Brand,
                    Model = car.Model
                });
        }
    }
}
