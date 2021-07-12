using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage1.Vehicles
{
    public class Car : Vehicle
    {
        private string fueltype;

        public string FuelType
        {
            get { return fueltype; }
            set { fueltype = value; }
        }

        public Car() { }

        public Car(string reg, string color, int numofw, string fuel): base(reg, color, numofw)
        {
            FuelType = fuel;
        }
        public override string ToString()
        {
            return base.ToString() + "nCar has fueltyp" + FuelType+ ".";
        }
    }
}
