using Garage.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class UI : IUI
    {
        private readonly IHandler _handler;

        // Constructor that initializes the UI with a handler instance
        public UI(IHandler handler)
        {
            _handler = handler ?? throw new ArgumentNullException(nameof(handler), "Handler cannot be null");
        }

        public void Start()
        {
            // Menu with choices for the user
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===GARAGE===");
                Console.WriteLine("1. List of all vehicles in the garage");
                Console.WriteLine("2. Add vehicle");
                Console.WriteLine("3. Remove vehicle");
                Console.WriteLine("4. Search vehicle");
                Console.WriteLine("5. Show number of vehicles per type");
                Console.WriteLine("0. Terminate");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine() ?? string.Empty;
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        ShowVehicles(_handler.GetAllVehicles());
                        break;
                    case "2":
                        AddVehicleMenu();
                        break;
                    case "3":
                        string regToRemove = GetInput("Enter registration number to remove:");
                        bool removed = _handler.RemoveVehicle(regToRemove);
                        ShowMessage(removed ? "Vehicle removed!" : "Vehicle could not be found.");
                        break;
                    case "4":
                        SearchVehicleMenu();
                        break;
                    case "5":
                        foreach (var pair in _handler.GetVehicleTypeCounts())
                            Console.WriteLine($"{pair.Key}: {pair.Value}");
                        break;
                    case "0":
                        ShowMessage("Terminating...");
                        return;
                    default:
                        ShowMessage("Invalid choice, please try again.");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true); // Wait for user input before clearing the console again
            }
        }

        private void SearchVehicleMenu()
        {
            Console.WriteLine("===Search Vehicles===");
            Console.WriteLine("Enter search criteria (press Enter to skip any criteria):");

            // Prompt the user for search criteria
            string? color = GetInput("Color:");
            string? wheelsInput = GetInput("Number of wheels:");
            string? type = GetInput("Type of vehicle (car, bus, boat, motorcycle, airplane):");
            string? reg = GetInput("Registration number:");

            int? wheels = int.TryParse(wheelsInput, out int w) ? w : null;

            // Perform the search using the handler
            var results = _handler.SearchVehicle(
                string.IsNullOrWhiteSpace(color) ? null : color,
                wheels,
                string.IsNullOrWhiteSpace(type) ? null : type,
                string.IsNullOrWhiteSpace(reg) ? null : reg);

            // Display the search results
            Console.WriteLine("Search results:");
            ShowVehicles(results);
        }

        private void AddVehicleMenu()
        {
            // Display options for adding a vehicle
            Console.WriteLine("===Add vehicle===");
            Console.WriteLine("1. Car");
            Console.WriteLine("2. Motorcycle");
            Console.WriteLine("3. Boat");
            Console.WriteLine("4. Bus");
            Console.WriteLine("5. Airplane");
            Console.WriteLine("0. Avbryt");

            string choice = GetInput("Select vehicle type:");

            string reg = GetInput("Registraition number:").ToUpper();
            string color = GetInput("Color:");
            int wheels = GetIntInput("Number of wheels:");

            // Create the vehicle based on the user's choice
            IVehicle? vehicle = choice switch
            {
                "1" => new Car(reg, color, wheels, GetInput("Fuel type:")),
                "2" => new Motorcycle(reg, color, wheels, GetIntInput("Cylinder volyme:")),
                "3" => new Boat(reg, color, wheels, GetIntInput("Length (m):")),
                "4" => new Bus(reg, color, wheels, GetIntInput("Number of seats:")),
                "5" => new Airplane(reg, color, wheels, GetIntInput("Number of engines:")),
                "0" => null,
                _ => null
            };

            // Check if the vehicle was created successfully
            if (vehicle == null)
            {
                ShowMessage("Canceled, or invalid choice.");
                return;
            }

            // Attempt to add the vehicle to the garage
            bool added = _handler.AddVehicle(vehicle);
            ShowMessage(added ? "Vehicle added!" : "The vehicle could not be added.");
        }

        // Show prompt and read input from the user
        public string GetInput(string prompt)
        {
            Console.Write(prompt + " ");
            return Console.ReadLine() ?? string.Empty;
        }

        // Get an integer input from the user with validation
        private int GetIntInput(string prompt)
        {
            while (true)
            {
                string input = GetInput(prompt);
                if (int.TryParse(input, out int result))
                    return result;

                ShowMessage("Invalid input. Please enter a number.");
            }
        }

        // Show a message to the user
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        // Display a list of vehicles to the user
        public void ShowVehicles(IEnumerable<IVehicle> vehicles)
        {
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }

            if (!vehicles.Any())
            {
                Console.WriteLine("No vehicles found.");
            }
        }
    }
}
