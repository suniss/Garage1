using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage1.Vehicles
{
    public class Motorcycle : Vehicle
    {
        private int cylinderVolume;

        public int CylinderVolume
        {
            get { return cylinderVolume; }
            set { CylinderVolume = value; }
        }

        public Motorcycle() { }

        public Motorcycle(string reg, string color, int numofw, int cylin): base(reg, color, numofw)
        {
            CylinderVolume = cylin;
        }

        public Motorcycle(string reg, string color, int numofw) : base(reg, color, numofw)
        {
        }

        public override string ToString()
        {
            return base.ToString()+ "nThe cylinder volume is" + CylinderVolume+ ".";
        }
    }

}
  

