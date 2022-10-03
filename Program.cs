using System.Text.Json;
using SkolProjekt1;

namespace Inlämmningsuppgift
{
    internal class Program
    {
        private static bool _mainMenuRunning = true;
        private static bool _shirtMenuRunning = true;
        private static bool _muggMenuRunning = true;
        private static bool _shoeMenuRunning = true;
        private static bool _carMenuRunning = true;

        private static void Main(string[] args)
        {
            var muggs = new List<Mugg>();
            var shirts = new List<Shirt>();
            var shoes = new List<Shoe>();
            var cars = new List<Car>();
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
                    case MainMenuChoice.Shoes:
                        {
                            var shoeStorage = new JsonStorage<Shoe>("Skor.json");

                            while (_shoeMenuRunning)
                            {
                                switch (menu.PrintProductMenu())
                                {
                                    case ProductMenu.Generate:
                                        {
                                            Console.Write("Hur många skor vill du lägga till?: ");
                                            int numberOfShoes = int.Parse(Console.ReadLine() ?? "0");

                                            for (int i = 0; i < numberOfShoes; i++)
                                            {
                                                var shoe = new Shoe();

                                                Console.WriteLine($"Skriv in namnet för tröjan nmr {i + 1}");
                                                shoe.sku = Console.ReadLine() ?? "";
                                                Console.WriteLine($"Skriv in beskrvingen för tröja nmr {i + 1}");
                                                shoe.title = Console.ReadLine() ?? "";

                                                shoes.Add(shoe);
                                            }

                                            shoeStorage.Save(shoes);
                                        }
                                        break;
                                    case ProductMenu.Show:
                                        {
                                            Console.WriteLine("Sku\tTitle");
                                            foreach (var shoe in shoeStorage.Load())
                                            {
                                                Console.WriteLine($"{shoe.sku}\t{shoe.title}");
                                            }
                                        }
                                        break;
                                    case ProductMenu.Exit:
                                        {
                                            _shoeMenuRunning = false;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                            break;
                        }
                    case MainMenuChoice.Cars:
                        {
                            var carStorage = new JsonStorage<Car>("Cars.json");

                            while (_carMenuRunning)
                            {
                                switch (menu.PrintProductMenu())
                                {
                                    case ProductMenu.Generate:
                                        {
                                            Console.Write("Hur många bilar vill du lägga till?: ");
                                            int numberOfCars = int.Parse(Console.ReadLine() ?? "0");

                                            for (int i = 0; i < numberOfCars; i++)
                                            {
                                                var car = new Car();

                                                Console.WriteLine($"Skriv in modelen för bil nmr {i + 1}");
                                                car.Model = Console.ReadLine() ?? "";
                                                Console.WriteLine($"Skriv in årtalet för bil nmr {i + 1}");
                                                car.Year = int.Parse(Console.ReadLine() ?? "0");
                                                Console.WriteLine($"Skriv in märket för bil nmr {i + 1}");
                                                car.Brand = Console.ReadLine() ?? "";

                                                cars.Add(car);
                                            }

                                            carStorage.Save(cars);
                                        }
                                        break;
                                    case ProductMenu.Show:
                                        {
                                            Console.WriteLine("Model\tYear\tBrand");
                                            foreach (var car in carStorage.Load())
                                            {
                                                Console.WriteLine($"{car.Model}\t{car.Year}\t{car.Brand}");
                                            }
                                        }
                                        break;
                                    case ProductMenu.Exit:
                                        {
                                            _carMenuRunning = false;
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