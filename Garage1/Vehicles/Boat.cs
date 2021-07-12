using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage1.Vehicles
{
   public class Boat : Vehicle
    {
        private int length;
        public int Length
        {
            get { return length; }
            set { length = value; }
        }
        public Boat() { }
        public Boat(string reg, string color, int numofw, int leng): base(reg, color, numofw)
        {
            Length = leng;
        }
        public override string ToString()
        {
            return base.ToString() + "Theboats has" + Length +"lenght.";
        }
    }
}
