using System.Text.Json;
using SkolProjekt1;
using PlainStorage;

namespace Inlämmningsuppgift
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            bool _mainMenuRunning = true;
            int _saveChoice = 1;

            while (_mainMenuRunning)
            {
                var menu = new Menu();
                var RandomGenerator = new RandomGenerator();

                switch (Menu.PrintMainMenu())
                {
                    case MainMenuChoice.Shirts:
                        {
                            bool _shirtMenuRunning = true;

                            var jsonStorage = new JsonStorage<Shirt>("Shirts.json");
                            var plainStorage = new PlainStorage<Shirt>("Shirts.txt");
                            var shirts = new List<Shirt>();
                            
                            while (_shirtMenuRunning)
                            {
                                switch (Menu.PrintProductMenu())
                                {
                                    case ProductChoice.Generate:
                                        {
                                            int numberOfProducts = Menu.NumberOfProducts();
                                            if (numberOfProducts == 0)
                                            {
                                                break;
                                            }

                                            for (int i = 0; i < numberOfProducts; i++)
                                            { 
                                                var shirt = new Shirt
                                                {
                                                    Motive = RandomGenerator.Motive(),
                                                    Material = RandomGenerator.Material(),
                                                    Size = RandomGenerator.Size(),
                                                    Price = RandomGenerator.Price(),
                                                    Rating = RandomGenerator.Rating()
                                                };

                                                shirts.Add(shirt);
                                            }

                                            if (_saveChoice == 1)
                                            {
                                                plainStorage.Save(shirts);
                                                Console.WriteLine("Sparat i Plain");
                                            }
                                            else if (_saveChoice == 2)
                                            {
                                                jsonStorage.Save(shirts);
                                                Console.WriteLine("Sparat i Json");
                                            }
                                        }
                                        break;
                                    case ProductChoice.Show:
                                        {
                                            Console.Clear();
                                            const int alignment = -13;
                                            Console.WriteLine("Här är våra t-shirts:\n");
                                            Console.WriteLine($"{"Motive", alignment}{"Material",alignment}{"Size",alignment}{"Price",alignment}{"Rating",alignment}\n");

                                            Console.ForegroundColor = ConsoleColor.Green;
                                            if (_saveChoice == 1)
                                            {
                                                foreach (var shirt in plainStorage.Load().OrderByDescending(o => o.Rating))
                                                {
                                                    Console.WriteLine($"{shirt.Motive, alignment}{shirt.Material, alignment}{shirt.Size, alignment}{shirt.Price,alignment}{shirt.Rating,alignment}");
                                                }
                                            }
                                            else if (_saveChoice == 2)
                                            {
                                                foreach (var shirt in jsonStorage.Load().OrderByDescending(o => o.Rating))
                                                {
                                                    Console.WriteLine($"{shirt.Motive,alignment}{shirt.Material,alignment}{shirt.Size,alignment}{shirt.Price,alignment}{shirt.Rating,alignment}");
                                                }
                                            }
                                            Console.ResetColor();
                                            Console.WriteLine("");
                                        }
                                        break;
                                    case ProductChoice.Exit:
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
                            bool _mugMenuRunning = true;

                            var jsonStorage = new JsonStorage<Mug>("Muggar.json");
                            var plainStorage = new PlainStorage<Mug>("Muggar.txt");
                            var mugs = new List<Mug>();

                            while (_mugMenuRunning)
                            {
                                switch (Menu.PrintProductMenu())
                                {
                                    case ProductChoice.Generate:
                                        {
                                            int numberOfProducts = Menu.NumberOfProducts();
                                            if (numberOfProducts == 0)
                                            {
                                                break;
                                            }

                                            for (int i = 0; i < numberOfProducts; i++)
                                            {
                                                var mug = new Mug
                                                {
                                                    Motive = RandomGenerator.Motive(),
                                                    Price = RandomGenerator.Price(),
                                                    Rating = RandomGenerator.Rating(),
                                                    Type = RandomGenerator.MugType()
                                                };
                                                mugs.Add(mug);
                                            }

                                            if (_saveChoice == 1)
                                            {
                                                plainStorage.Save(mugs);
                                                Console.WriteLine("Sparat i Plain");
                                            }
                                            else if (_saveChoice == 2)
                                            {
                                                jsonStorage.Save(mugs);
                                                Console.WriteLine("Sparat i Json");
                                            }
                                        }
                                        break;
                                    case ProductChoice.Show:
                                        {
                                            Console.Clear();
                                            const int alignment = -13;
                                            Console.WriteLine("Här är våra muggar:\n");
                                            Console.WriteLine($"{"Motive",alignment}{"Type",alignment}{"Price",alignment}{"Rating",alignment}\n");

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            if (_saveChoice == 1)
                                            {
                                                foreach (var mug in plainStorage.Load().OrderBy(o => o.Rating))
                                                {
                                                    Console.WriteLine($"{mug.Motive,alignment}{mug.Type, alignment}{mug.Price,alignment}{mug.Rating,alignment}");
                                                }
                                            }
                                            else if (_saveChoice == 2)
                                            {
                                                foreach (var mug in jsonStorage.Load().OrderBy(o => o.Rating))
                                                {
                                                    Console.WriteLine($"{mug.Motive,alignment}{mug.Type, alignment}{mug.Price,alignment}{mug.Rating,alignment}");
                                                }
                                            }
                                            Console.ResetColor();
                                            Console.WriteLine("");
                                        }
                                        break;
                                    case ProductChoice.Exit:
                                        {
                                            _mugMenuRunning = false;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                            break;
                        }
                    case MainMenuChoice.Settings:
                        {
                            bool _settingsMenu = true;
                            while (_settingsMenu)
                            {
                                switch (Menu.PrintSettingsMenu())
                                {
                                    case SettingChoice.Plain:
                                        {
                                            _saveChoice = 1;
                                            _settingsMenu = false;
                                            break;
                                        }
                                    case SettingChoice.Json:
                                        {
                                            _saveChoice = 2;
                                            _settingsMenu = false;
                                            break;
                                        }
                                    case SettingChoice.Exit:
                                        {
                                            _settingsMenu = false;
                                            break;
                                        }
                                    default:
                                        break;
                                }
                            }
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