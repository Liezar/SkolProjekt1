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
        CSV = 1,
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
            Console.WriteLine("Come and visit! We are located at: Intressantgatan 10");
            Console.WriteLine("Billing address: Intressantgatan 13\n");

            Console.WriteLine("Welcome!");
            Console.WriteLine("1: Shirts");
            Console.WriteLine("2: Mugs");
            Console.WriteLine("3: Settings");
            Console.WriteLine("4: Exit");

            if (!int.TryParse(Console.ReadLine(), out int _mainMenuChoice))
            {
                Console.WriteLine("Only numbers!");
            }

            Console.Clear();
            return (MainMenuChoice)_mainMenuChoice;
        }

        public static SettingChoice PrintSettingsMenu()
        {
            Console.WriteLine("Here are the different save formats:\nJSON saves all data in JSON format\nCSV saves all data in CSV format but the seperator is a #\n");
            Console.WriteLine("1: CSV");
            Console.WriteLine("2: Json");
            Console.WriteLine("3: Exit");

            if (!int.TryParse(Console.ReadLine(), out int _settingMenuChoice))

            Console.Clear();
            return (SettingChoice)_settingMenuChoice;
        }

        public static ProductChoice PrintProductMenu()
        {
            Console.WriteLine("1: Generate product");
            Console.WriteLine("2: Show products");
            Console.WriteLine("3: Exit");

            if (!int.TryParse(Console.ReadLine(), out int _prodcutMenuChoice))

            Console.Clear();
            return (ProductChoice)_prodcutMenuChoice;
        }
        public static int NumberOfProducts()
        {
            Console.Clear();
            Console.Write("How many products do you wish to create?: ");

            if (!int.TryParse(Console.ReadLine(), out int _numberOfProducts))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Only numbers!");
                Console.ResetColor();
                return 0;
            }
            else if (_numberOfProducts <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You need to create one or more products!");
                Console.ResetColor();
                return 0;
            }
            return _numberOfProducts;
        }
    }
}
