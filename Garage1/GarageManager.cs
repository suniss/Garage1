using Garage1.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage1
{
    public class GarageManager
    {
        private GarageHandler gh;

        // Main Menu
        public void MainMenu()
        {
            //test with example
           // Garage<Vehicle> gr = new Garage<Vehicle>("test", "addr", 100);
           

            Menu MainMenu = new Menu();
            MainMenu.Description = "Main Menu:";
            MainMenu.AddMenuItem("1", "Enter 1 to create a new garage", CreateGarage );
            MainMenu.AddMenuItem("2", "Enter 2 to park your vehicle", new Action(() => { Park(); }));
            MainMenu.AddMenuItem("3", "Enter 3 to unpark your vehicle", new Action(() => { Unpark(); }));
            MainMenu.AddMenuItem("4", "Enter 4 to see information about the garage", new Action(() => { List(); }));
            MainMenu.AddMenuItem("5", "Enter 5 to search about vehicle", new Action(() => { Search(); }));
            MainMenu.AddMenuItem("0", "Enter 0 to Exit", new Action(() => { Close(); }));
            MainMenu.Color = "White";
            MainMenu.ShowMenu();
        }

        //SubMenu
        private  void Search()
        {
            Menu SubMenu = new Menu();
            SubMenu.Description = "Search Menu:";
            SubMenu.AddMenuItem("1", "Enter 1 to search vehicle by registration number", new Action(() => { Search( 1); }));
            SubMenu.AddMenuItem("2", "Enter 2 to search vehicle by type", new Action(() => { Search( 2); }));
            SubMenu.AddMenuItem("3", "Enter 3 to search vehicle by number of wheel", new Action(() => { Search( 3); }));
            SubMenu.AddMenuItem("4", "Enter 4 to search vehicle by color", new Action(() => { Search( 4); }));
            SubMenu.AddMenuItem("0", "Enter 0 to the main menu",() => { });
            SubMenu.Color = "Cyan";
            SubMenu.ShowMenu();
        }

        private  void List()
        {
            Menu SubMenu = new Menu();
            SubMenu.Description = "List Menu:";
            SubMenu.AddMenuItem("1", "Enter 1 to list all parked vehicles", new Action(() => { DisplayList( 1); }));
            SubMenu.AddMenuItem("2", "Enter 2 to list all types currently parked vehicle", new Action(() => { DisplayList( 2); }));
            SubMenu.AddMenuItem("3", "Enter 3 to list all available slots", new Action(() => { DisplayList( 3); }));
            SubMenu.AddMenuItem("4", "Enter 4 to list all occupied slot", new Action(() => { DisplayList( 4); }));
            SubMenu.AddMenuItem("0", "Enter 0 to come back the main menu", new Action(() => { }));
            SubMenu.Color = "Yellow";
            SubMenu.ShowMenu();
        }

        private  void Park()
        {
            Menu SubMenu = new Menu();

            SubMenu.Description = "Paking Menu:";
            SubMenu.AddMenuItem("1", "Enter 1 to park an airplane", new Action(() => { AddVehicle( 1); }));
            SubMenu.AddMenuItem("2", "Enter 2 to park a boat", new Action(() => { AddVehicle( 2); }));
            SubMenu.AddMenuItem("3", "Enter 3 to park a bus", new Action(() => { AddVehicle( 3); }));
            SubMenu.AddMenuItem("4", "Enter 4 to park a car", new Action(() => { AddVehicle( 4); }));
            SubMenu.AddMenuItem("5", "Enter 5 to park a motorcycle", new Action(() => { AddVehicle( 5); }));
            SubMenu.AddMenuItem("6", "Enter 6 to see parked vehicles", new Action(() => { DisplayList( 1); }));
            SubMenu.AddMenuItem("0", "Enter 0 to come back main menu", new Action(() => { }));
            SubMenu.Color = "Green";
            SubMenu.ShowMenu();
        }

        private  void Unpark()
        {

            Menu SubMenu = new Menu();

            SubMenu.Description = "Unpark Menu:";
            SubMenu.AddMenuItem("1", "Enter 1 to unpark your vehicle with resgiter number", new Action(() => { RemoveVehicle( 1); }));
            SubMenu.AddMenuItem("2", "Enter 2 to unpark your vehicle with slot", new Action(() => { RemoveVehicle( 2); }));
            SubMenu.AddMenuItem("3", "Enter 3 to see parked vehicles", new Action(() => { DisplayList( 1); }));
            SubMenu.AddMenuItem("0", "Enter 0 to come back the main menu", new Action(() => { }));
            SubMenu.Color = "Red";
            SubMenu.ShowMenu();
        }
       
        private void CreateGarage()
        {
            Console.Clear();
            Console.WriteLine("Please create a new garage");
            Console.WriteLine("*************");
            Console.Write("Please crate garage name: ");
            string name = Console.ReadLine();
            while (String.IsNullOrEmpty(name))
            {
                Console.Write("Invalid.Name can not be empty, please input again: ");
                name = Console.ReadLine();
            }

            Console.Write("Please enter address of garage: ");
            string address = Console.ReadLine();

            Console.Write("Please create number of capacity of garage: ");
            int capacity;
            while (!int.TryParse(Console.ReadLine(), out capacity))
            {
                Console.Write("Incorrect input.Please input number of capacity again: ");
            }

            gh = new GarageHandler();
            gh.CreateGarage(name, address, capacity);
            Console.WriteLine("************New Garage Create**************");
            Console.WriteLine(gh.PrintGarage());
            Console.ReadLine();
        }

        private void AddVehicle(int choice)
        {
            int position = 0;
            Vehicle v = CreateVehicle(choice);
            Console.Write("\nPlease input the position for park vehicle, or input 0 if you don't have any specific slot: ");
            string input = Console.ReadLine();
            if (!String.IsNullOrEmpty(input))
            {
                while (!int.TryParse(input, out position))
                {
                    Console.Write("Invalid input.Please input position again: ");
                    input = Console.ReadLine();
                }
            }
          
            Console.WriteLine(gh.ParkVehicle(v, position));
            Console.ReadLine();
        }

        private static Vehicle CreateVehicle(int choice)
        {

            Console.Clear();
            Console.WriteLine("Add new vehicle");
            Console.WriteLine("****************************************");
            Console.Write("Enter vehicle registration number:");
            string reg = Console.ReadLine();
            while (String.IsNullOrEmpty(reg))
            {
                Console.Write("registration number can not be null.Please input number again: ");
                reg = Console.ReadLine();
            }
            Console.Write("Enter vehicle color:");
            string col = Console.ReadLine();

            Console.Write("Enter the number of vehicle wheels:");
            int nw;
            while (!int.TryParse(Console.ReadLine(), out nw))
            {
                Console.Write("Invalid input.Please input vehicle number again: ");
            }
            if (choice == 1)
            {
                Console.Write("Enter the number of engine:");
                int numof;
                while (!int.TryParse(Console.ReadLine(), out numof))
                {
                    Console.Write("Invalid.Please input number of engine again: ");
                }
                Airplane air = new Airplane(reg, col, nw, numof);
                return air;
            }
            else if (choice == 2)
            {
                Console.Write("Enter the length of boat:");
                int leng;
                while (!int.TryParse(Console.ReadLine(), out leng))
                {
                    Console.Write("Invalid.Please input length of vehicle again: ");
                }
                Boat boat = new Boat(reg, col, nw, leng);
                return boat;
            }
            else if (choice == 3)
            {
                Console.Write("Enter the number of seat:");
                int seat;
                while (!int.TryParse(Console.ReadLine(), out seat))
                {
                    Console.Write("Invalid.Please input number of seats again: ");
                }
                Bus bus = new Bus(reg, col, nw, seat);
                return bus;
            }
            else if (choice == 4)
            {
                Console.Write("Enter the fuel type:");
                string fuel = Console.ReadLine();
                Car car = new Car(reg, col, nw, fuel);
                return car;
            }
            else
                Console.Write("Enter the cylinder volume:");
            int cyli;
            while (!int.TryParse(Console.ReadLine(), out cyli))
            {
                Console.Write("Invalid.Please input volume again: ");
            }
            Motorcycle moto = new Motorcycle(reg, col, nw, cyli);
            return moto;

        }

        private  void RemoveVehicle(int choice)
        {
            Console.Clear();
            Console.WriteLine("Unpark Vehicle");
            Console.WriteLine("***********************************");
            if (choice == 1)
            {
                Console.Write("Please input registration number of vehicle: ");
                string regis = Console.ReadLine();
                Console.WriteLine(gh.UnParkVehicle(regis, 0));
            }
            else
            {
                Console.Write("Please input the slot of vehicle: ");
                int slot;
                while (!int.TryParse(Console.ReadLine(), out slot))
                {
                    Console.Write("Invalid number.Please input number slot again: ");
                }
                Console.WriteLine(gh.UnParkVehicle(null, slot));
            }
            Console.ReadLine();
        }

        private  void DisplayList(int choice)
        {
            Console.Clear();

            if (choice == 1)
            {
                Console.WriteLine("List of vehicles");
                Console.WriteLine("**************************************");
                Console.WriteLine(gh.ShowList());
            }
            if (choice == 2)
            {
                Console.WriteLine("List of type");
                Console.WriteLine("***************************");
                Console.WriteLine(gh.ShowType());
            }
            if (choice == 3)
            {
                Console.WriteLine("AVAILABLE SLOTS");
                Console.WriteLine("****************************");
                gh.ShowEmpty();
            }
            if (choice == 4)
            {
                Console.WriteLine("OCCUPIED SLOTS");
                Console.WriteLine("****************************");
                gh.ShowOccupied();
            }
            Console.ReadLine();
        }

        private  void Search( int choice)
        {
            
            Vehicle v;
            Console.Clear();
            Console.WriteLine("Search for vehicles");
            Console.WriteLine("********************************");
            if (choice == 1)
            {
                Console.Write("Enter the registration number of the vehicle: ");
                string reg = Console.ReadLine();
                while (String.IsNullOrEmpty(reg))
                {
                    Console.Write("registration number can not be null.Please input again: ");
                    reg = Console.ReadLine();
                }
                gh.FindVehicleByReg( reg);
            }
            if (choice == 2)
            {
                Console.Write("Enter vehicle type: ");
                string typ = Console.ReadLine();
                while (String.IsNullOrEmpty(typ))
                {
                    Console.Write("Vehicle type can not be null.Please input again: ");
                    typ = Console.ReadLine();
                }
                gh.ShowListType( typ);
            }
            if (choice == 3)
            {
                Console.Write("Enter vehicles wheel number ");
                int wheels;
                while (!int.TryParse(Console.ReadLine(), out wheels))
                {
                    Console.Write("Invalid number of the wheels.Please input again: ");
                }
                gh.FindVehicleByWheel( wheels);

            }
            if (choice == 4)
            {
                Console.Write("Enter vehicles color: ");
                string col = Console.ReadLine();
                while (String.IsNullOrEmpty(col))
                {
                    Console.Write("Vehicle color can not be null.Please input again: ");
                    col = Console.ReadLine();
                }
                gh.FindVehicleByColor( col);
            }
            Console.ReadLine();
        }

        private static void Close()
        {
            Console.WriteLine("Thank you");
            
            return;
        }
       

    }
}