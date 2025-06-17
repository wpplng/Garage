using Garage.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class Handler : IHandler
    {
        private IGarage<IVehicle> _garage;

        public Handler(IGarage<IVehicle> garage)
        {
            _garage = garage ?? throw new ArgumentNullException(nameof(garage), "Garage cannot be null");
        }
        public bool AddVehicle(IVehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public IVehicle? FindVehicle(string regNr)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IVehicle> GetAllVehicles()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, int> GetVehicleTypeCounts()
        {
            throw new NotImplementedException();
        }

        public bool RemoveVehicle(string regNr)
        {
            throw new NotImplementedException();
        }
    }
}
