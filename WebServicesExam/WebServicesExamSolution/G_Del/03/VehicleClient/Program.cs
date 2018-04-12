using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleClient.VehicleServiceReference;

namespace VehicleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            VehicleServiceClient client = new VehicleServiceClient("Ws");

            try
            {
                #region ADD NEW CAR
                Car newCar = new Car
                {
                    Id = 6,
                    Wheels = 4,
                    MotorPower = 400,
                    NbrOfDoors = 2,
                    Model = "Tesla Sportscar"
                };
                client.ByCar(newCar);
                #endregion

                #region ADD NEW MOTORCYCLE
                Motorcycle newMotorcycle = new Motorcycle
                {
                    Id = 6,
                    Wheels = 2,
                    MotorPower = 500,
                    Type = "Chopper",
                };
                client.ByMotorcycle(newMotorcycle);
                #endregion

                #region GET CARS
                Console.WriteLine("\nList Of Cars");
                var carResult = client.GetCars();
                foreach (var item in carResult)
                {
                    Console.WriteLine($"ID: {item.Id} - WHEELS: {item.Wheels} - MOTORPOWER: {item.MotorPower} - NUMBER OF DOORS: {item.NbrOfDoors} - MODEL: {item.Model}");
                }
                #endregion

                #region GET MOTORCYCLES
                Console.WriteLine("\nList Of MotorCycle");
                var motorcycleResult = client.GetMotorcycles();
                foreach (var item in motorcycleResult)
                {
                    Console.WriteLine($"ID: {item.Id} - WHEELS: {item.Wheels} - MOTORPOWER: {item.MotorPower} - TYPE: {item.Type}");
                }
                #endregion

                #region SELL CAR
                Console.WriteLine("\nSold Cars");
                var soldCar = client.SellCar(1);
                Console.WriteLine($"ID: {soldCar.Id} - WHEELS: {soldCar.Wheels} - MOTORPOWER: {soldCar.MotorPower} - NUMBER OF DOORS: {soldCar.NbrOfDoors} - MODEL: {soldCar.Model}");
                #endregion

                #region SELL MOTORCYCLE
                Console.WriteLine("\nSold Motorcycle");
                var soldMotorcycle = client.SellMotorcycle(2);
                Console.WriteLine($"ID: {soldMotorcycle.Id} - WHEELS: {soldMotorcycle.Wheels} - MOTORPOWER: {soldMotorcycle.MotorPower} - TYPE: {soldMotorcycle.Type}");
                #endregion

                Console.ReadLine();

                /* ------------------------------------------------------------------ */

                #region GET CARS
                Console.WriteLine("\nNew List Of Cars");
                var newCarResult = client.GetCars();
                foreach (var item in newCarResult)
                {
                    Console.WriteLine($"ID: {item.Id} - WHEELS: {item.Wheels} - MOTORPOWER: {item.MotorPower} - NUMBER OF DOORS: {item.NbrOfDoors} - MODEL: {item.Model}");
                }
                #endregion

                #region GET MOTORCYCLES
                Console.WriteLine("\nNew List Of MotorCycle");
                var newMotorcycleResult = client.GetMotorcycles();
                foreach (var item in newMotorcycleResult)
                {
                    Console.WriteLine($"ID: {item.Id} - WHEELS: {item.Wheels} - MOTORPOWER: {item.MotorPower} - TYPE: {item.Type}");
                }
                #endregion

                Console.ReadLine();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
