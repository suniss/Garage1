using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage1
{
    public class Vehicle : IVehicle
    {
        private string registrationNumber;
        private string color;
        private int numberOfWheels;
        public string RegistrationNumber { get { return registrationNumber; } set { registrationNumber = value; } }
        public string Color { get { return color; } set { color = value; } }
        public int NumberOfWheels { get { return numberOfWheels; } set { numberOfWheels = value; } }

        string IVehicle.Color { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int IVehicle.NumberOfWheels { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IVehicle.RegistrationNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IVehicle.Length { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Vehicle() { }

        public Vehicle(string reg, string col, int numofw)
        {
            RegistrationNumber = reg;
            Color = col;
            NumberOfWheels = numofw;
        }
        public override string ToString()
        {
            return "Registration number" + RegistrationNumber + "\nAnd it has color" + Color + "\nand it has " + NumberOfWheels + "wheels";
        }

        string IVehicle.ToString()
        {
            throw new NotImplementedException();
        }
    }
}
