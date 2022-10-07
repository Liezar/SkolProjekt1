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

            while (_mainMenuRunning)
            {
                var menu = new Menu();
                switch (menu.PrintMainMenu())
                {
                    case MainMenuChoice.Shirts:
                        {
                            bool _shirtMenuRunning = true;

                            var shirtStorage = new JsonStorage<Shirt>("Test.json");
                            var plainStorage = new PlainStorage.PlainStorage("ShirtsPlain.txt");
                            var shirts = new List<Shirt>();
                            
                            while (_shirtMenuRunning)
                            {
                                switch (menu.PrintProductMenu())
                                {
                                    case ProductMenu.Generate:
                                        {
                                            Console.Write("Hur många tröjor vill du lägga till?: ");
                                            int numberOfShirts = int.Parse(Console.ReadLine() ?? "0");

                                            for (int i = 0; i < numberOfShirts; i++)
                                            {
                                                var shirt = new Shirt();

                                                Console.WriteLine($"Skriv in motivet för tröjan nmr {i + 1}");
                                                shirt.Motive = Console.ReadLine() ?? "";
                                                Console.WriteLine($"Skriv in material för tröja nmr {i + 1}");
                                                shirt.Material = Console.ReadLine() ?? "";
                                                Console.WriteLine($"Skriv in betyget för tröja nmr {i + 1}");
                                                shirt.Rating = Console.ReadLine() ?? "";
                                                Console.WriteLine($"Skriv in priset för tröja nmr {i + 1}");
                                                shirt.Price = Console.ReadLine() ?? "";
                                                Console.WriteLine($"Skriv in storleken för tröja nmr {i + 1}");
                                                shirt.Size = Console.ReadLine() ?? "";

                                                shirts.Add(shirt);
                                            }
                                            //shirtStorage.Save(shirts);
                                            plainStorage.Save(shirts);
                                        }
                                        break;
                                    case ProductMenu.Show:
                                        {
                                            Console.WriteLine("Motiv\tMaterial\tStorlek\t\tPriset\t\tBetyg");
                                            //foreach (var shirt in shirtStorage.Load().OrderByDescending(o => o.Rating))
                                            foreach (var shirt in plainStorage.Load().OrderByDescending(o => o.Rating))
                                            {
                                                Console.WriteLine($"\n{shirt.Motive.ToUpper()}\t{shirt.Material.ToUpper()}\t\t{shirt.Size.ToUpper()}\t\t{shirt.Price.ToUpper()}\t\t{shirt.Rating.ToUpper()}");
                                            }
                                        }
                                        break;
                                    case ProductMenu.Exit:
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

                            var mugStorage = new JsonStorage<Mug>("Muggar.txt");
                            var mugs = new List<Mug>();

                            while (_mugMenuRunning)
                            {
                                switch (menu.PrintProductMenu())
                                {
                                    case ProductMenu.Generate:
                                        {
                                            Console.Write("Hur många muggar vill du lägga till?: ");
                                            int numberOfMugs = int.Parse(Console.ReadLine() ?? "0");

                                            for (int i = 0; i < numberOfMugs; i++)
                                            {
                                                var mug = new Mug();

                                                Console.WriteLine($"Skriv in motivet för mugg nmr {i + 1}");
                                                mug.Motive = Console.ReadLine() ?? "";
                                                Console.WriteLine($"Skriv in priset för mugg nmr {i + 1}");
                                                mug.Price = float.Parse(Console.ReadLine() ?? "0");
                                                Console.WriteLine($"Skriv in betyget för mugg nmr {i + 1}");
                                                mug.Rating = float.Parse(Console.ReadLine() ?? "0");
                                                Console.WriteLine($"Skriv in typen för mugg nmr {i + 1}");
                                                mug.Type = Console.ReadLine() ?? "";

                                                mugs.Add(mug);
                                            }
                                            List<Mug> SortedList = mugs.OrderBy(o => o.Rating).ToList();
                                            mugStorage.Save(SortedList);
                                        }
                                        break;
                                    case ProductMenu.Show:
                                        {
                                            Console.WriteLine("Motiv\tTyp\tPris\tBetyg");
                                            foreach (var mug in mugStorage.Load().OrderBy(o => o.Rating))
                                            {
                                                Console.WriteLine($"{mug.Motive}\t{mug.Type}\t{mug.Price}\t{mug.Rating}");
                                            }
                                        }
                                        break;
                                    case ProductMenu.Exit:
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