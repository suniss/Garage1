using System;
using System.Collections.Generic;
using System.Linq;

namespace Garage1
{
    public class Menu
    {
        public List<MenuItem> menulists = new List<MenuItem>();
        public string Description { get; set; }
        public string Color { get; set; }

        public void AddMenuItem(string option, string description, Action action)
        {
            MenuItem item = new MenuItem();
            item.Description = description;
            item.option = option;
            item.RelatedAction = action;
            menulists.Add(item);

        }

        

        private void Display()
        {
            Console.Clear();
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), this.Color, true);
            Console.WriteLine(Description);
            foreach (var item in menulists)
            {
                Console.WriteLine(item.Description);
            }
        }
        public void ShowMenu()
        {
            bool DisplayMenu = true;
            while(DisplayMenu)
            {
                this.Display();
                string input = Console.ReadLine();
                if (input == "0") DisplayMenu = false;
                this.ExecEntry(input);
            }
        }

        public void ExecEntry(string option)
        {
            var item = menulists.Where(p => p.option == option).ToList();
            if(item.Count == 0)
            {
                Console.WriteLine("Incorrect input");
                Console.ReadLine();
            }
            else
            {
                item[0].ExecEntry();
            }
        }
    }
    }
