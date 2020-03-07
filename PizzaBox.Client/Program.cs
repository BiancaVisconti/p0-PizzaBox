using PizzaBox.Client.Singletons;

namespace PizzaBox.Client
{
  internal class Program
    {
        private static void Main(string[] args)
        {   
            StartMenu();
        }

        private static void StartMenu()
        {
            var menu = MenuSingleton.Instance;
            menu.DoAll();
        }
    }
}
