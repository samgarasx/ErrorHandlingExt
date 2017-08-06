using System;
using System.Collections.Generic;

namespace ErrorHandlingExt.Samples.Data
{
    public class CloudDatabase
    {
        private static List<CarEntity> Cars = new List<CarEntity>()
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
            return Cars;
        }

        public static CarEntity GetCar(int id)
        {
            var foundCar = Cars.Find(car => car.Id == id);
            if (foundCar == null)
                throw new Exception($"Can not find car with id={id}");

            return foundCar;
        }
    }
}
