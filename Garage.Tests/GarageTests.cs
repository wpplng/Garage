using Garage.Vehicles;
using System.Diagnostics.Metrics;

namespace Garage.Tests
{
    public class GarageTests
    {
        // Helper method to create a garage with a specific capacity
        private Garage<IVehicle> CreateGarageWithCapacity(int capacity) => new(capacity);

        [Fact]
        public void ParkVehicle_AddingOneVehicle_SuccessfullyAddsVehicle()
        {
            // Arrange
            var garage = CreateGarageWithCapacity(1);
            var vehicle = new Car("ABC321", "Red", 4, "Diesel");

            // Act
            var result = garage.ParkVehicle(vehicle);

            // Assert
            Assert.Equal(ParkingResult.Success, result);
            Assert.Single(garage.GetAllVehicles());
        }

        [Fact]
        public void ParkVehicle_AddingVehicleWhenGarageIsFull_FailsWhenGarageIsFull()
        {
            // Arrange
            var garage = CreateGarageWithCapacity(1);
            garage.ParkVehicle(new Car("ABC321", "Red", 4, "Diesel"));

            // Act
            var result = garage.ParkVehicle(new Car("DEF456", "Blue", 4, "Diesel"));

            // Assert
            Assert.Equal(ParkingResult.GarageFull, result);
        }

        [Fact]
        public void ParkVehicle_AddingDuplicateVehicle_FailsWhenDuplicateRegistration()
        {
            // Arrange
            var garage = CreateGarageWithCapacity(2);
            garage.ParkVehicle(new Car("ABC321", "Red", 4, "Diesel"));

            // Act
            var result = garage.ParkVehicle(new Car("ABC321", "Blue", 4, "Gasoline"));
            
            // Assert
            Assert.Equal(ParkingResult.DuplicateRegistration, result);
        }
    }
}
