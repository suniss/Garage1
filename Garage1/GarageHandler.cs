using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Globalization;
namespace Garage1
{
    //
    public class GarageHandler
    {
        private Garage<IVehicle> garage;

        //public void SetName(Garage<T> garage, string name)
        //{
        //    garage.Name = name;
        //}
        //public string GetName(Garage<T> garage)
        //{
        //    return garage.Name;
        //}
        //public void SetAddress(Garage<T> garage, string address)
        //{
        //    garage.Address = address;
        //}
        //public string GetAddress(Garage<T> garage)
        //{
        //    return garage.Address;
        //}
        //public int GetCapacity(Garage<T> garage)
        //{
        //    return garage.Capacity;
        //}
        //public int GetCount(Garage<T> garage)
        //{
        //    return garage.Count;
        //}

        //ToDo kanske bool?
        public void CreateGarage(string name, string address, int capacity)
        {

            garage = new Garage<IVehicle>(name, address, capacity);

        }
        public string ParkVehicle(IVehicle vehicle, int slot)
        {
            string message = "";
            if (slot < 0 || slot > garage.Capacity)
            {
                message = "Position is not available";
                return message;
            }
            else
            {
                if (slot == 0)
                {
                    slot = garage.FirstEmtySlot + 1;
                }
                if (slot == 0)
                {
                    message = "Garage is full";
                    return message;
                }
                if (garage.Park(vehicle, slot - 1))
                    message = "success at slot" + slot + "\n" + this.PrintGarage();
                else
                    message = "Slot is not empty";
                return message;
            }
        }
        public string UnParkVehicle(string reg, int slot)
        {
            string message = "";
            if (slot < 0 || slot > garage.Capacity)
            {
                message = "The position for unpark is not exit";
                return message;
            }
            else
            {
                if (slot == 0)
                {
                    slot = garage.FindIndex(reg) + 1;

                }
                if (slot == 0)
                {
                    message = "Can not find vehicle registration number";
                    return message;
                }
                if (garage.Unpark(slot - 1))
                    message = "Unpark is sucess";
                else
                    message = "Slot to unpark is empty";
                return message;
            }
        }
        public string PrintGarage()
        {
            return "Name" + garage.Name +
                "\nAdress" + garage.Address +
                "\nMaximum Capacity" + garage.Capacity +
                "\nNumber of ocuppied slots" + garage.Count +
                "\nNumber of available slots" + (garage.Capacity - garage.Count);
        }
        public string ShowList()
        {
            return garage.List();
        }
        public string ShowType()
        {
            string result = "";
            var velist = garage.GroupBy(x => x.GetType().Name).Select(g => new
            {
                type = g.Key,
                cout = g.Count()
            }).ToList();

            //velist.ForEach(v => result += v.type + "," + v.cout + "\n");
            //return result;

            foreach (var v in velist)
            {
                result += v.type + "," + v.cout + "\n";

            }
            return result;
        }
        private void PageList(List<int> list, int NoPage)
        {
            string result = "";
            for (int i = 0; i < list.Count; i = i + NoPage)
            {
                result = "";
                var items = list.Skip(i).Take(NoPage);
                for (int j = i; j < i + items.Count(); j++)
                {
                    result += (list.ElementAt(j) + 1);

                }
                Console.WriteLine(result.Substring(0, result.Length - 2));
                Console.ReadLine();
            }
        }

        //ToDo  Remove garage parameters, work on garage field
        public void ShowEmpty()
        {
            PageList(garage.ListPos(false), 20);
        }
        public void ShowOccupied()
        {
            PageList(garage.ListPos(true), 20);
        }

        public void FindVehicleByReg(string reg)
        {
            //var res =  garage.FirstOrDefault(v => v.RegistrationNumber == reg);

            var velist = garage.FindByReg(reg);
            if (velist.Count == 0)
                Console.WriteLine("The vehicle with registration number {0} is not found", reg);
            else
            {
                foreach (var v in velist)
                {
                    Console.WriteLine("Slot:" + (v.Key + 1) + "\n" + v.Value);
                }
            }
        }
        public void FindVehicleByWheel(int numofWheels)
        {
            var velist = garage.FindByWheel(numofWheels);
            if (velist.Count == 0)
                Console.WriteLine("Can not find with {0}wheels", numofWheels);
            else
            {
                foreach (var v in velist)
                {
                    Console.WriteLine("Slot" + (v.Key + 1) + "\n" + v.Value);
                }
            }
        }
        public void FindVehicleByColor(string color)
        {
            var velist = garage.FindByColor(color);
            if (velist.Count == 0)
                Console.WriteLine("Not find any vehicle with {0} wheels ", color);
            else
            {
                foreach (var v in velist)
                {
                    Console.WriteLine("Slot: " + (v.Key + 1) + "\n" + v.Value);
                }
            }
        }
        public void ShowListType(string typ)
        {
            var velist = garage.OfType<Vehicle>().Where(x => x.GetType().Name.Equals(typ, StringComparison.CurrentCulture));
            if (velist.Count() == 0)
                Console.WriteLine("Can not find vehicle vehicle from the type {0}", typ);
            else
                foreach (var v in velist)
                    Console.WriteLine(v);
        }
        public string TypeVehicle()
        {
            return garage.ListType();
        }

        public void Test()
        {
            IEnumerable<IVehicle> result = new List<IVehicle>();
            //Fråga vad användaren vill söka på.
            //Precis som när man parkerar
            var regNo = Console.ReadLine();
            var color = Console.ReadLine();
            var Length = Console.ReadLine();
            //color
            if (color != "X")
            {
                result = garage.Where(v => v.Color.StartsWith("RED"));
            }
            if (Length != "X")
            {
                result = result.Where(v => v.RegistrationNumber == regNo);
            }



        }

    }
}


