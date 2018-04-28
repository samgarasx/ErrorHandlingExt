using ErrorHandlingExt.Extensions;
using ErrorHandlingExt.Extensions.Tasks;
using ErrorHandlingExt.Samples.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorHandlingExt.Samples
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var app = new App(new CarService(new CarRepository()));

            Task.Run(() => app.Run());

            Console.ReadLine();
        }

        private class App
        {
            private readonly CarService _carService;

            public App(CarService carService)
            {
                _carService = carService;
            }

            public async Task Run()
            {
                _carService.GetCars()
                    .OnSuccess(cars => cars.ToList().ForEach(car => Console.WriteLine(car.Model)))
                    .OnFailure(error => Console.WriteLine(error.Message));

                await _carService.GetCarsAsync()
                    .OnSuccess(cars => cars.ToList().ForEach(car => Console.WriteLine(car.Model)))
                    .OnFailure(error => Console.WriteLine(error.Message));

                _carService.GetCar(1)
                    .OnSuccess(car => Console.WriteLine(car.Model))
                    .OnFailure(error => Console.WriteLine(error.Message));

                await _carService.GetCarAsync(3)
                    .OnSuccess(car => Console.WriteLine(car.Model))
                    .OnFailure(error => Console.WriteLine(error.Message));
            }
        }
    }
}