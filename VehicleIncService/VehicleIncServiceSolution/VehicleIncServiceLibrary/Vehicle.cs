using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace VehicleIncServiceLibrary
{
    public class Vehicle
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int Wheels { get; set; }

        [DataMember]
        public int MotorPower { get; set; }
    }

    public class Car : Vehicle
    {
        [DataMember]
        public int NbrOfDoors { get; set; }

        [DataMember]
        public string Model { get; set; }
    }

    public class Motorcycle : Vehicle
    {
        [DataMember]
        public string Type { get; set; }
    }

    [ServiceContract]
    public interface IVehicleService
    {
        [OperationContract]
        List<Car> GetCars();

        [OperationContract]
        List<Motorcycle> GetMotorcycles();

        [OperationContract]
        void ByCar(Car car);

        [OperationContract]
        void ByMotorcycle(Motorcycle motorcycle);

        [OperationContract]
        Car SellCar(int Id);

        [OperationContract]
        Motorcycle SellMotorcycle(int Id);
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class VehicleService : IVehicleService
    {
        List<Car> Cars = new List<Car>
        {
            new Car{Id = 1, Wheels = 4, MotorPower = 625, NbrOfDoors = 2, Model = "Ferrari"},
            new Car{Id = 2, Wheels = 4, MotorPower = 573, NbrOfDoors = 4, Model = "Lamborghini"},
            new Car{Id = 3, Wheels = 4, MotorPower = 697, NbrOfDoors = 2, Model = "Corvette"},
            new Car{Id = 4, Wheels = 4, MotorPower = 365, NbrOfDoors = 4, Model = "Jeep"},
            new Car{Id = 5, Wheels = 4, MotorPower = 404, NbrOfDoors = 2, Model = "Maserati"}
        };

        List<Motorcycle> Motorcycles = new List<Motorcycle>
        {
            new Motorcycle{Id = 1, Wheels = 2, MotorPower = 180, Type = "Standard"},
            new Motorcycle{Id = 2, Wheels = 2, MotorPower = 157, Type = "Cruiser"},
            new Motorcycle{Id = 3, Wheels = 2, MotorPower = 285, Type = "Sportbike"},
            new Motorcycle{Id = 4, Wheels = 2, MotorPower = 230, Type = "Dual Sport"},
            new Motorcycle{Id = 5, Wheels = 2, MotorPower = 198, Type = "Scooter"}
        };

        #region GET CAR
        public List<Car> GetCars()
        {
            return Cars;
        }
        #endregion

        #region GET MOTORCYCLE
        public List<Motorcycle> GetMotorcycles()
        {
            return Motorcycles;
        }
        #endregion

        #region BY CAR
        public void ByCar(Car car)
        {
            Cars.Add(car);
        }
        #endregion

        #region BY MOTORCYCLE
        public void ByMotorcycle(Motorcycle motorcycle)
        {
            Motorcycles.Add(motorcycle);
        }
        #endregion

        #region SELL CAR
        public Car SellCar(int Id)
        {
            var sc = Cars.FirstOrDefault(x => x.Id == Id);

            Cars.Remove(sc);
            return sc;
        }
        #endregion

        #region SELL MOTORCYCLE
        public Motorcycle SellMotorcycle(int Id)
        {
            var sm = Motorcycles.FirstOrDefault(x => x.Id == Id);

            Motorcycles.Remove(sm);
            return sm;
        }
        #endregion
    }
}
