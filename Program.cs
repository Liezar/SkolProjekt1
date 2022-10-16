using CSV;
using SkolProjekt1;

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
                var _menu = new Menu();
                var _randomGenerator = new RandomGenerator();

                switch (Menu.PrintMainMenu())
                {
                    case MainMenuChoice.Shirts:
                        {
                            bool _shirtMenuRunning = true;

                            var _jsonStorage = new JsonStorage<Shirt>("/Shirts.json");
                            var _csvStorage = new CsvStorage<Shirt>("/Shirts.txt");
                            var _shirts = new List<Shirt>();

                            while (_shirtMenuRunning)
                            {
                                switch (Menu.PrintProductMenu())
                                {
                                    case ProductChoice.Generate:
                                        {
                                            int _numberOfProducts = Menu.NumberOfProducts();
                                            if (_numberOfProducts == 0)
                                            {
                                                break;
                                            }

                                            for (int i = 0; i < _numberOfProducts; i++)
                                            {
                                                var shirt = new Shirt
                                                {
                                                    Motif = RandomGenerator.Motive(),
                                                    Material = RandomGenerator.Material(),
                                                    Size = RandomGenerator.Size(),
                                                    Price = RandomGenerator.Price(),
                                                    Rating = RandomGenerator.Rating()
                                                };

                                                _shirts.Add(shirt);
                                            }

                                            if (_saveChoice == 1)
                                            {
                                                _csvStorage.Save(_shirts);
                                                Console.WriteLine("Saved in CSV format");
                                            }
                                            else if (_saveChoice == 2)
                                            {
                                                _jsonStorage.Save(_shirts);
                                                Console.WriteLine("Saved in Json format");
                                            }
                                        }
                                        break;
                                    case ProductChoice.Show:
                                        {
                                            Console.Clear();
                                            const int _alignment = -13;
                                            Console.WriteLine("Here is our assortment of T-shirts:\n");
                                            Console.WriteLine($"{"Motif",_alignment}{"Material",_alignment}{"Size",_alignment}{"Price",_alignment}{"Rating",_alignment}\n");

                                            Console.ForegroundColor = ConsoleColor.Green;
                                            if (_saveChoice == 1)
                                            {
                                                foreach (var shirt in _csvStorage.Load().OrderByDescending(o => o.Rating))
                                                {
                                                    Console.WriteLine($"{shirt.Motif,_alignment}{shirt.Material,_alignment}{shirt.Size,_alignment}{shirt.Price,_alignment}{shirt.Rating,_alignment}");
                                                }
                                            }
                                            else if (_saveChoice == 2)
                                            {
                                                foreach (var shirt in _jsonStorage.Load().OrderByDescending(o => o.Rating))
                                                {
                                                    Console.WriteLine($"{shirt.Motif,_alignment}{shirt.Material,_alignment}{shirt.Size,_alignment}{shirt.Price,_alignment}{shirt.Rating,_alignment}");
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

                            var _jsonStorage = new JsonStorage<Mug>("/Mugs.json");
                            var _csvStorage = new CsvStorage<Mug>("/Mugs.txt");
                            var _mugs = new List<Mug>();

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
                                                    Motif = RandomGenerator.Motive(),
                                                    Price = RandomGenerator.Price(),
                                                    Rating = RandomGenerator.Rating(),
                                                    Type = RandomGenerator.MugType()
                                                };
                                                _mugs.Add(mug);
                                            }

                                            if (_saveChoice == 1)
                                            {
                                                _csvStorage.Save(_mugs);
                                                Console.WriteLine("Saved in CSV format");
                                            }
                                            else if (_saveChoice == 2)
                                            {
                                                _jsonStorage.Save(_mugs);
                                                Console.WriteLine("Saved in Json format");
                                            }
                                        }
                                        break;
                                    case ProductChoice.Show:
                                        {
                                            Console.Clear();
                                            const int alignment = -13;
                                            Console.WriteLine("Here is our assortment of mugs:\n");
                                            Console.WriteLine($"{"Motif",alignment}{"Type",alignment}{"Price",alignment}{"Rating",alignment}\n");

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            if (_saveChoice == 1)
                                            {
                                                foreach (var mug in _csvStorage.Load().OrderBy(o => o.Rating))
                                                {
                                                    Console.WriteLine($"{mug.Motif,alignment}{mug.Type,alignment}{mug.Price,alignment}{mug.Rating,alignment}");
                                                }
                                            }
                                            else if (_saveChoice == 2)
                                            {
                                                foreach (var mug in _jsonStorage.Load().OrderBy(o => o.Rating))
                                                {
                                                    Console.WriteLine($"{mug.Motif,alignment}{mug.Type,alignment}{mug.Price,alignment}{mug.Rating,alignment}");
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
                                    case SettingChoice.CSV:
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