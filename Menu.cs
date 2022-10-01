using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämmningsuppgift
{
    public enum MainMenuChoice
    {
        Shirts = 1,
        Mugs,
        Exit
    }

    public enum ShirtMenu
    {
        Generate = 1,
        Show,
        Exit
    }

    public class Menu
    {
        public MainMenuChoice PrintMainMenu()
        {
            Console.WriteLine("Welcome!");
            Console.WriteLine("1: Shirts");
            Console.WriteLine("2: Mugs");
            Console.WriteLine("3: Exit");

            if (!int.TryParse(Console.ReadLine(), out int mainMenuChoice))
            {
                Console.WriteLine("Endast siffror!");
            }

            return (MainMenuChoice)mainMenuChoice;
        }

        public ShirtMenu PrintShirtMenu()
        {
            Console.WriteLine("1: Generate shirts");
            Console.WriteLine("2: Show shirts");
            Console.WriteLine("3: Exit");

            if (!int.TryParse(Console.ReadLine(), out int shirtMenuChoice))
            {
                Console.WriteLine("Endast siffror!");
            }

            return (ShirtMenu)shirtMenuChoice;
        }
    }
}
