using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage1.Vehicles

{
    public class Bus : Vehicle
    {
        private int numberOfSeats;

        public int NumberOfSeats
        {
            get { return numberOfSeats; }
            set { numberOfSeats = value; }
        }
        public Bus() { }

        public Bus(string reg, string color, int numofw, int numofseat) : base(reg, color, numofw)
        {
            NumberOfSeats = numofseat;
        }
        public override string ToString()
        {
            return base.ToString()+"\nThe bus has:" + NumberOfSeats+"seats.";
        }
    }
    
    
}
