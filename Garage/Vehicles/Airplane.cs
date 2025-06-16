using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    internal class Airplane : Vehicle
    {
        public int NumberOfEngines { get; } // Number of engines on the airplane

        public Airplane(string regNr, string color, int numberOfWheels, int numberOfEngines) : base(regNr, color, numberOfWheels)
        {
            NumberOfEngines = numberOfEngines;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Engines: {NumberOfEngines}";
        }
    }
}
