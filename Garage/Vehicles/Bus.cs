using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    internal class Bus : Vehicle
    {
        public int NumberOfSeats { get; } // Number of seats in the bus

        public Bus(string regNr, string color, int numberOfWheels, int numberOfSeats) : base(regNr, color, numberOfWheels)
        {
            NumberOfSeats = numberOfSeats;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Seats: {NumberOfSeats}";
        }
    }
}
