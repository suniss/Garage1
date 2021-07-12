using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage1.Vehicles
{
    class Airplane : Vehicle
    {
        private int numberOfEngines;
        public int NumberOfEngines
        {
            get { return numberOfEngines; }
            set { numberOfEngines = value; }
        }

        //constructor
        public Airplane() { }

        public Airplane(string reg,string color,int numofw,int numofEn) : base (reg,color,numofw)
        {
            NumberOfEngines = numofEn;
        }
        public override string ToString()
        {
            return base.ToString()+ "n has:" + NumberOfEngines+ "engines.";
        }
    }
}
