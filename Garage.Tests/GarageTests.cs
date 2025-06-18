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

        [Fact]
        public void RemoveVehicle_RemovingExistingVehicle_SuccessfullyRemovesVehicle()
        {
            // Arrange
            var garage = CreateGarageWithCapacity(2);
            garage.ParkVehicle(new Car("ABC321", "Red", 4, "Diesel"));
            
            // Act
            var removed = garage.RemoveVehicle("ABC321");
            
            // Assert
            Assert.True(removed);
            Assert.Empty(garage.GetAllVehicles());
        }

        [Fact]
        public void RemoveVehicle_RemovingNonExistingVehicle_ReturnsFalse()
        {
            // Arrange
            var garage = CreateGarageWithCapacity(2);
            garage.ParkVehicle(new Car("ABC321", "Red", 4, "Diesel"));
            
            // Act
            var removed = garage.RemoveVehicle("XYZ789");
            
            // Assert
            Assert.False(removed);
            Assert.Single(garage.GetAllVehicles());
        }

        [Fact]
        public void FindVehicle_ReturnsCorrectVehicle_IgnoringCase()
        {
            // Arrange
            var garage = CreateGarageWithCapacity(1);
            var vehicle = new Car("ABC321", "Red", 4, "Diesel");
            garage.ParkVehicle(vehicle);
            
            // Act
            var foundVehicle = garage.FindVehicle("abc321");
            
            // Assert
            Assert.NotNull(foundVehicle);
            Assert.Equal("ABC321", foundVehicle!.RegistrationNumber);
        }

        [Fact]
        public void FindVehicle_ReturnsNull_WhenVehicleNotFound()
        {
            // Arrange
            var garage = CreateGarageWithCapacity(1);
            garage.ParkVehicle(new Car("ABC321", "Red", 4, "Diesel"));
            
            // Act
            var foundVehicle = garage.FindVehicle("XYZ789");
            
            // Assert
            Assert.Null(foundVehicle);
        }
    }
}
