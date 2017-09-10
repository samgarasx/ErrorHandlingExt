using System;
using System.Collections.Generic;
using System.Linq;

namespace ErrorHandlingExt.Samples.Data
{
    public class CloudDatabase
    {
        private static IEnumerable<CarEntity> Cars = new List<CarEntity>()
        {
            new CarEntity(1)
            {
                Brand = "Ferrari",
                Model = "Ferrari 812 Superfast",
            },
            new CarEntity(2)
            {
                Brand = "Jaguar",
                Model = "Jaguar F-Type",
            },
        };

        public static IEnumerable<CarEntity> GetCars()
        {
            return Cars.ToList();
        }

        public static IEnumerable<CarEntity> GetCars(string brand)
        {
            return Cars.Where(car => car.Brand == brand).ToList();
        }

        public static CarEntity GetCar(int id)
        {
            var foundCar = Cars.FirstOrDefault(car => car.Id == id);
            if (foundCar == null)
                throw new Exception($"Can not find car with id={id}");

            return foundCar;
        }
    }
}
