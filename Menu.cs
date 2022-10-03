namespace Inlämmningsuppgift
{
    public enum MainMenuChoice
    {
        Shirts = 1,
        Mugs,
        Shoes,
        Exit
    }

    public enum ProductMenu
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
            Console.WriteLine("3: Shoes");
            Console.WriteLine("4: Exit");

            if (!int.TryParse(Console.ReadLine(), out int mainMenuChoice))
            {
                Console.WriteLine("Endast siffror!");
            }

            return (MainMenuChoice)mainMenuChoice;
        }

        public ProductMenu PrintProductMenu()
        {
            Console.WriteLine("1: Generate product");
            Console.WriteLine("2: Show products");
            Console.WriteLine("3: Exit");

            if (!int.TryParse(Console.ReadLine(), out int prodcutMenuChoice))
            {
                Console.WriteLine("Endast siffror!");
            }

            return (ProductMenu)prodcutMenuChoice;
        }
    }
}
