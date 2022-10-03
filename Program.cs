using System.Text.Json;
using SkolProjekt1;

namespace Inlämmningsuppgift
{
    internal class Program
    {
        private static bool _mainMenuRunning = true;
        private static bool _shirtMenuRunning = true;

        private static void Main(string[] args)
        {
            var menu = new Menu();
            var jsonStorage = new JsonStorage();

            while (_mainMenuRunning == true)
            {
                switch (menu.PrintMainMenu())
                {
                    case MainMenuChoice.Shirts:
                        {
                            while (_shirtMenuRunning == true)
                            {
                                switch (menu.PrintShirtMenu())
                                {
                                    case ShirtMenu.Generate:
                                        {
                                            Console.Write("Hur många tröjor vill du lägga till?: ");
                                            int numberOfShirts = int.Parse(Console.ReadLine());

                                            var shirts = new List<Shirt>();

                                            for (int i = 0; i < numberOfShirts; i++)
                                            {
                                                var shirt = new Shirt();

                                                Console.WriteLine($"Skriv in namnet för tröjan nmr {i + 1}");
                                                shirt.Name = Console.ReadLine();
                                                Console.WriteLine($"Skriv in beskrvingen för tröja nmr {i + 1}");
                                                shirt.Description = Console.ReadLine();
                                                Console.WriteLine($"Skriv in färgen för tröja nmr {i + 1}");
                                                shirt.Color = Console.ReadLine();
                                                Console.WriteLine($"Skriv in storleken för tröja nmr {i + 1}");
                                                shirt.Size = Console.ReadLine();

                                                shirts.Add(shirt);
                                            }

                                            jsonStorage.Save(shirts);
                                        }
                                        break;
                                    case ShirtMenu.Show:
                                        {
                                            jsonStorage.Load();
                                        }
                                        break;
                                    case ShirtMenu.Exit:
                                        {
                                            _shirtMenuRunning = false;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                            break;
                        }
                    case MainMenuChoice.Mugs:
                        {
                            break;
                        }
                    case MainMenuChoice.Exit:
                        {
                            _mainMenuRunning = false;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }

        }
    }
}