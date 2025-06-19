using Garage.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.ConsoleUI
{
    internal interface IUI
    {
        void Start();
        string GetInput(string prompt);
        void ShowMessage(string message);
        void ShowVehicles(IEnumerable<IVehicle> vehicles);
    }
}
