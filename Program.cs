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
            int _saveChoice = 0;

            while (_mainMenuRunning)
            {
                var menu = new Menu();
                var RandomGenerator = new RandomGenerator();

                switch (menu.PrintMainMenu())
                {
                    case MainMenuChoice.Shirts:
                        {
                            bool _shirtMenuRunning = true;

                            var jsonStorage = new JsonStorage<Shirt>("Test.json");
                            var plainStorage = new PlainStorage.PlainStorage("ShirtsPlain.txt");
                            var shirts = new List<Shirt>();
                            
                            while (_shirtMenuRunning)
                            {
                                switch (menu.PrintProductMenu())
                                {
                                    case ProductChoice.Generate:
                                        {
                                            Console.Write("Hur många tröjor vill du lägga till?: ");
                                            int numberOfShirts = int.Parse(Console.ReadLine() ?? "0");

                                            Random random = new Random();

                                            for (int i = 0; i < numberOfShirts; i++)
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
                                                plainStorage.SaveShirt(shirts);
                                                Console.WriteLine("Nu sparas det i PLAIN format");
                                            }
                                            else if (_saveChoice == 2)
                                            {
                                                jsonStorage.Save(shirts);
                                                Console.WriteLine("Nu sparas det i JSON format");
                                            }
                                        }
                                        break;
                                    case ProductChoice.Show:
                                        {
                                            const int alignment = -13;
                                            Console.WriteLine("Här är våra t-shirts:\n");
                                            Console.WriteLine($"{"Motive", alignment}{"Material",alignment}{"Size",alignment}{"Price",alignment}{"Rating",alignment}\n");

                                            foreach (var shirt in jsonStorage.Load().OrderByDescending(o => o.Rating))
                                            {
                                                Console.WriteLine($"{shirt.Motive, alignment}{shirt.Material, alignment}{shirt.Size, alignment}{shirt.Price,alignment}{shirt.Rating,alignment}");
                                            }

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
                            var plainStorage = new PlainStorage.PlainStorage("MuggarPlain.txt");
                            var mugs = new List<Mug>();

                            while (_mugMenuRunning)
                            {
                                switch (menu.PrintProductMenu())
                                {
                                    case ProductChoice.Generate:
                                        {
                                            Console.Write("Hur många muggar vill du lägga till?: ");
                                            int numberOfMugs = int.Parse(Console.ReadLine() ?? "0");

                                            for (int i = 0; i < numberOfMugs; i++)
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
                                                plainStorage.SaveMug(mugs);
                                                Console.WriteLine("Nu sparas det i PLAIN format");
                                            }
                                            else if (_saveChoice == 2)
                                            {
                                                jsonStorage.Save(mugs);
                                                Console.WriteLine("Nu sparas det i JSON format");
                                            }
                                        }
                                        break;
                                    case ProductChoice.Show:
                                        {
                                            const int alignment = -13;
                                            Console.WriteLine("Här är våra muggar:\n");
                                            Console.WriteLine($"{"Motive",alignment}{"Type",alignment}{"Price",alignment}{"Rating",alignment}\n");

                                            foreach (var shirt in plainStorage.ShirtLoad().OrderByDescending(o => o.Rating))
                                            {
                                                Console.WriteLine($"{shirt.Motive,alignment}{shirt.Material,alignment}{shirt.Size,alignment}{shirt.Price,alignment}{shirt.Rating,alignment}");
                                            }

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
                                switch (menu.PrintSettingsMenu())
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