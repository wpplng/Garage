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
            throw new NotImplementedException();
        }

        public string GetInput(string prompt)
        {
            throw new NotImplementedException();
        }

        public void ShowMessage(string message)
        {
            throw new NotImplementedException();
        }

        public void ShowVehicles(IEnumerable<IVehicle> vehicles)
        {
            throw new NotImplementedException();
        }

    }
}
