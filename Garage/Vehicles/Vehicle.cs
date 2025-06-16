using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    internal abstract class Vehicle : IVehicle
    {
        public string RegistrationNumber { get; }
        public string Color { get; }
        public int NumberOfWheels { get; }

        protected Vehicle(string regNr, string color, int numberOfWheels)
        {
            RegistrationNumber = regNr.ToUpper();
            Color = color;
            NumberOfWheels = numberOfWheels;
        }

        public override string ToString()
        {
            return $"RegNr: {RegistrationNumber}, Color: {Color}, Wheels: {NumberOfWheels}";
        }
    }
}
