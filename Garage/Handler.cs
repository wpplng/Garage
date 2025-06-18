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

        // Constructor that initializes the Handler with a garage instance
        public Handler(IGarage<IVehicle> garage)
        {
            _garage = garage ?? throw new ArgumentNullException(nameof(garage), "Garage cannot be null");
        }

        // Adds a vehicle to the garage - parks the vehicle if there's space and no duplicate registration number
        public ParkingResult AddVehicle(IVehicle vehicle) => _garage.ParkVehicle(vehicle);

        // Removes a vehicle from the garage by its registration number
        public bool RemoveVehicle(string regNr) => _garage.RemoveVehicle(regNr);

        // Finds a vehicle in the garage by its registration number
        public IVehicle? FindVehicle(string regNr) => _garage.FindVehicle(regNr);

        // Retrieves all vehicles currently in the garage
        public IEnumerable<IVehicle> GetAllVehicles() => _garage.GetAllVehicles();

        // Gets a count of each type of vehicle in the garage, returning a dictionary with vehicle type names as keys and their counts as values
        public Dictionary<string, int> GetVehicleTypeCounts()
        {
            return _garage.GetAllVehicles()
                .GroupBy(v => v.GetType().Name)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        // Serches for vehicles in the garage based on optional criteria such as color, number of wheels, type, and registration number
        public IEnumerable<IVehicle> SearchVehicle(
           string? color = null,
           int? numberOfWheels = null,
           string? type = null,
           string? regNr = null )
        {
            return _garage.GetAllVehicles().Where(v =>
                (color == null || v.Color.Equals(color, StringComparison.OrdinalIgnoreCase)) &&
                (numberOfWheels == null || v.NumberOfWheels == numberOfWheels) &&
                (type == null || v.GetType().Name.Equals(type, StringComparison.OrdinalIgnoreCase)) &&
                (regNr == null || v.RegistrationNumber.Equals(regNr, StringComparison.OrdinalIgnoreCase))
            );
        }
    }
}
