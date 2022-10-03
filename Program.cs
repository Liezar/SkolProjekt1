using System.Text.Json;
using SkolProjekt1;

namespace Inlämmningsuppgift
{
    internal class Program
    {
        private static bool _mainMenuRunning = true;
        private static bool _shirtMenuRunning = true;
        private static bool _muggMenuRunning = true;

        private static void Main(string[] args)
        {
            var muggs = new List<Mugg>();
            var shirts = new List<Shirt>();
            var menu = new Menu();

            while (_mainMenuRunning)
            {
                switch (menu.PrintMainMenu())
                {
                    case MainMenuChoice.Shirts:
                        {
                            var shirtStorage = new JsonStorage<Shirt>("Shirts.json");
                            
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

                                                Console.WriteLine($"Skriv in namnet för tröjan nmr {i + 1}");
                                                shirt.Name = Console.ReadLine() ?? "";
                                                Console.WriteLine($"Skriv in beskrvingen för tröja nmr {i + 1}");
                                                shirt.Description = Console.ReadLine() ?? "";
                                                Console.WriteLine($"Skriv in färgen för tröja nmr {i + 1}");
                                                shirt.Color = Console.ReadLine() ?? "";
                                                Console.WriteLine($"Skriv in storleken för tröja nmr {i + 1}");
                                                shirt.Size = Console.ReadLine() ?? "";

                                                shirts.Add(shirt);
                                            }

                                            shirtStorage.Save(shirts);
                                        }
                                        break;
                                    case ProductMenu.Show:
                                        {
                                            Console.WriteLine("Namn\tFärg\tStorlek");
                                            foreach (var shirt in shirtStorage.Load())
                                            {
                                                Console.WriteLine($"{shirt.Name}\t{shirt.Color}\t{shirt.Size}");
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
                            var muggStorage = new JsonStorage<Mugg>("Muggar.json");
                            while (_muggMenuRunning)
                            {
                                switch (menu.PrintProductMenu())
                                {
                                    case ProductMenu.Generate:
                                        {
                                            Console.Write("Hur många muggar vill du lägga till?: ");
                                            int numberOfMugs = int.Parse(Console.ReadLine() ?? "0");

                                            for (int i = 0; i < numberOfMugs; i++)
                                            {
                                                var mugg = new Mugg();

                                                Console.WriteLine($"Skriv in motivet för mugg nmr {i + 1}");
                                                mugg.Motive = Console.ReadLine() ?? "";
                                                Console.WriteLine($"Skriv in priset för mugg nmr {i + 1}");
                                                mugg.Price = float.Parse(Console.ReadLine() ?? "0");
                                                Console.WriteLine($"Skriv in betyget för mugg nmr {i + 1}");
                                                mugg.Rating = float.Parse(Console.ReadLine() ?? "0");
                                                Console.WriteLine($"Skriv in typen för mugg nmr {i + 1}");
                                                mugg.Type = Console.ReadLine() ?? "";

                                                muggs.Add(mugg);
                                            }

                                            muggStorage.Save(muggs);
                                        }
                                        break;
                                    case ProductMenu.Show:
                                        {
                                            Console.WriteLine("Motiv\tTyp\tPris\tBetyg");
                                            foreach (var mugg in muggStorage.Load())
                                            {
                                                Console.WriteLine($"{mugg.Motive}\t{mugg.Type}\t{mugg.Price}\t{mugg.Rating}");
                                            }
                                        }
                                        break;
                                    case ProductMenu.Exit:
                                        {
                                            _muggMenuRunning = false;
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