namespace Inlämmningsuppgift
{
    internal class Program
    {
        private static bool _mainMenuRunning = true;
        private static bool _shirtMenuRunning = true;

        private static void Main(string[] args)
        {
            var menu = new Menu();

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

                                        }
                                        break;
                                    case ShirtMenu.Show:
                                        {

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