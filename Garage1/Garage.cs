using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage1
{
    public class Garage<T> : IEnumerable<T> where T : IVehicle
    {
        private string name;
        private string address;
        private int count;
        private int capacity;
        private T[] vehiclesArray;

        public Garage(string name, string address, int capacity)
        {
            Capacity = capacity;
            Name = name;
            Address = address;
            vehiclesArray = new T[capacity];  //ToDo validate
        }
        public int Capacity
        {
            get { return capacity; }
           private set { capacity = value; }
        }
        public int Count => vehiclesArray.Count();
        //{
        //    get
        //    {
        //        count = vehiclesArray.Count();
        //        return count;
        //    }
        //}
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int FirstEmtySlot
        {
            get
            {
                return Array.FindIndex(vehiclesArray, x => x == null);

            }
        }
        public bool Park(T vehicle, int slot)
        {
            if (vehiclesArray[slot] == null)
            {
                vehiclesArray[slot] = vehicle;
                count++;
                return true;
            }
            else
                return false;
        }
        public bool Unpark(int slot)
        {
            //ToDo Validate!
            if (vehiclesArray[slot] != null)
            {
                vehiclesArray[slot] = default;
                count--;
                return true;
            }
            else
                return false;
        }
        public string List()
        {
            string result = "";
            for (int i = 0; i < Capacity; i++)
                if (vehiclesArray[i] != null)
                {
                    result += "Slot " + (i + 1) + "\n" + vehiclesArray[i].GetType().Name + "\n" + vehiclesArray[i] + "\n";

                }
            return result;
        }
        public List<int> ListPos(bool occupied)
        {
            List<int> empty = new List<int>();
            List<int> occupy = new List<int>();
            for (int i = 0; i < Capacity; i++)
                if (vehiclesArray[i] == null)
                    empty.Add(i);
                else
                    occupy.Add(i);
            if (occupied) return occupy;
            else return empty;
        }
        public string ListType()
        {
            string resultT = "";
            var vtype = vehiclesArray.Where(x => x != null).Select(x => x.GetType().Name);
            foreach (var v in vtype)
            {
                resultT += v + "|";
            }
            return resultT;
        }
        public int FindIndex(string registrationnumber)
        {
            return Array.FindIndex(vehiclesArray, x => x != null && x.RegistrationNumber == registrationnumber);
        }
        public Dictionary<int, T> FindByReg(string registrationnumber)
        {
            return vehiclesArray.Select((v, i) => new { vehicle = v, Index = i }).Where(x => x.vehicle != null && x.vehicle.RegistrationNumber.Contains(registrationnumber)).ToDictionary(x => x.Index, x => x.vehicle);
        }
        public Dictionary<int, T> FindByWheel(int numofwheels)
        {
            return vehiclesArray.Select((v, i) => new { vehicle = v, Index = i }).Where(x => x.vehicle != null && x.vehicle.NumberOfWheels == numofwheels).ToDictionary(x => x.Index, x => x.vehicle);
        }
        public Dictionary<int, T> FindByColor(string color)
        {
            return vehiclesArray.Select((v, i) => new { vehicle = v, Index = i }).Where(x => x.vehicle != null && x.vehicle.Color == color).ToDictionary(x => x.Index, x => x.vehicle);
        }
        public IEnumerable<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                if (vehiclesArray[i] != null)
                    yield return vehiclesArray[i];

            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)vehiclesArray).GetEnumerator();
        }

        internal string SearchByreg()
        {
            throw new NotImplementedException();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return ((IEnumerable<T>)vehiclesArray).GetEnumerator();
        }

        /*IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }*/
    }
}
