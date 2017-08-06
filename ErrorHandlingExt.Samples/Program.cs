﻿using ErrorHandlingExt.Extensions;
using ErrorHandlingExt.Samples.Data;
using System;
using System.Linq;

namespace ErrorHandlingExt.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            var carService = new CarService(new CarRepository());

            carService.GetCars()
                .OnSuccess(cars => cars.ToList().ForEach(car => Console.WriteLine(car.Model)))
                .OnFailure(error => Console.WriteLine(error.Message));

            carService.GetCarsAsync()
                .OnSuccess(cars => cars.ToList().ForEach(car => Console.WriteLine(car.Model)))
                .OnFailure(error => Console.WriteLine(error.Message));

            carService.GetCar(3)
                .OnSuccess(car => Console.WriteLine(car.Model))
                .OnFailure(error => Console.WriteLine(error.Message));

            carService.GetCarAsync(1)
                .OnSuccess(car => Console.WriteLine(car.Model))
                .OnFailure(error => Console.WriteLine(error.Message));
        }
    }
}