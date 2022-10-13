using SkolProjekt1;

namespace Inlämmningsuppgift
{
    public enum MainMenuChoice
    {
        Shirts = 1,
        Mugs,
        Settings,
        Exit
    }

    public enum SettingChoice
    {
        Plain = 1,
        Json,
        Exit
    }

    public enum ProductChoice
    {
        Generate = 1,
        Show,
        Exit
    }

    public class Menu
    {
        public static MainMenuChoice PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Kom och hälsa på! Vi befinner oss på: Intressantgatan 10");
            Console.WriteLine("Fakturaaddress: Intressantgatan 13\n");

            Console.WriteLine("Welcome!");
            Console.WriteLine("1: Shirts");
            Console.WriteLine("2: Mugs");
            Console.WriteLine("3: Settings");
            Console.WriteLine("4: Exit");

            if (!int.TryParse(Console.ReadLine(), out int mainMenuChoice))
            {
                Console.WriteLine("Endast siffror!");
            }

            Console.Clear();
            return (MainMenuChoice)mainMenuChoice;
        }

        public static SettingChoice PrintSettingsMenu()
        {
            Console.WriteLine("Nu visas de olika sparalternativen:\nJSON sparar all data i JSON format\nPLAIN sparar allting i ett eget format där allt separeras med #\n");
            Console.WriteLine("1: Plain");
            Console.WriteLine("2: Json");
            Console.WriteLine("3: Exit");

            if (!int.TryParse(Console.ReadLine(), out int settingMenuChoice))

            Console.Clear();
            return (SettingChoice)settingMenuChoice;
        }

        public static ProductChoice PrintProductMenu()
        {
            Console.WriteLine("1: Generate product");
            Console.WriteLine("2: Show products");
            Console.WriteLine("3: Exit");

            if (!int.TryParse(Console.ReadLine(), out int prodcutMenuChoice))

            Console.Clear();
            return (ProductChoice)prodcutMenuChoice;
        }
        public static int NumberOfProducts()
        {
            Console.Clear();
            Console.Write("Hur många produkter vill du skapa?: ");

            if (!int.TryParse(Console.ReadLine(), out int numberOfProducts))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Endast siffror!");
                Console.ResetColor();
                return 0;
            }
            else if (numberOfProducts <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Du måste generera en eller mer produkter");
                Console.ResetColor();
                return 0;
            }
            return numberOfProducts;
        }
    }
}
