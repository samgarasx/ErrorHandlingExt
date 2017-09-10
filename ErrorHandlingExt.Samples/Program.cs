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

        public class App
        {
            private readonly CarService carService;

            public App(CarService carService)
            {
                this.carService = carService;
            }

            public async Task Run()
            {
                carService.GetCars()
                    .OnSuccess(cars => cars.ToList().ForEach(car => Console.WriteLine(car.Model)))
                    .OnFailure(error => Console.WriteLine(error.Message));

                await carService.GetCarsAsync()
                    .OnSuccess(cars => cars.ToList().ForEach(car => Console.WriteLine(car.Model)))
                    .OnFailure(error => Console.WriteLine(error.Message));

                carService.GetCar(1)
                    .OnSuccess(car => Console.WriteLine(car.Model))
                    .OnFailure(error => Console.WriteLine(error.Message));

                await carService.GetCarAsync(3)
                    .OnSuccess(car => Console.WriteLine(car.Model))
                    .OnFailure(error => Console.WriteLine(error.Message));

                carService.GetCars("Audi")
                    .Map(cars =>
                    {
                        if (!cars.Any())
                            throw new Exception("Cars");
                        return cars;
                    }, new Exception("There is no Audi cars."))
                    .OnSuccess(cars =>
                    {
                        cars.ToList().ForEach(car => Console.WriteLine(car.Model));
                        return cars;
                    })
                    .OnFailure(error => Console.WriteLine(error.Message), new Exception("Error"));
            }
        }
    }
}