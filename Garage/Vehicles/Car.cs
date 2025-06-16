using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    internal class Car : Vehicle
    {
        public string FuelType { get; } // Type of fuel used by the car (e.g., Gasoline, Diesel, Electric)
        public Car(string regNr, string color, int numberOfWheels, string fuelType) : base(regNr, color, numberOfWheels)
        {
            FuelType = fuelType;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, FuelType: {FuelType}";
        }
    }
}
