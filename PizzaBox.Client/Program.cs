using System;
using System.Collections.Generic;
using PizzaBox.Client.Singletons;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client
{
  internal class Program
    {
        private static readonly PizzeriaSingleton _ps = PizzeriaSingleton.Instance;

        private static readonly UserRepository _ur = new UserRepository();

        private static readonly StoreRepository _sr = new StoreRepository();

        private static readonly PizzaRepository _pr = new PizzaRepository();

        private static readonly OrderRepository _or = new OrderRepository();

        private static void Main(string[] args)
        {   
            //ShowMenu();

            //GetAllStore();

            //PreOrder();

            //PostAllPizza();

            //_sr.CheckIfAccountExists("Mamma Mía", "13131");

            //_ur.CheckIfAccountExists("Mamma Mía", "13131");

            StartProgram();

        }

        private static void StartProgram()
        {
          Console.WriteLine("Welcome to Arlington's Fastest Pizza Delivery!");
          Console.WriteLine("Are you a client or a store?");
          Console.Write("Press 1 for client, 2 for store: ");
          int who = Int32.Parse(Console.ReadLine());
          bool check = who == 1 || who == 2;

          while (!check)
            {
              Console.Write("Invalid input, please try again: ");
              who = Int32.Parse(Console.ReadLine());
              check = (who == 1 || who == 2);
            }
          if (who == 1)
          {
            Console.Write("Please enter you username: ");
            string client = Console.ReadLine();
            Console.Write("Please enter you password: ");
            string cli_password = Console.ReadLine();
            bool check2 = _ur.CheckIfAccountExists(client, cli_password);

            while (!check2)
            {
              Console.WriteLine("Invalid input, please try again:");
              Console.Write("Please enter you username again: ");
              client = Console.ReadLine();
              Console.Write("Please enter you password again: ");
              cli_password = Console.ReadLine();
              check2 = _ur.CheckIfAccountExists(client, cli_password);
            }

          }
          else if (who == 2)
          {
            Console.Write("Please enter you username: ");
            string store = Console.ReadLine();
            Console.Write("Please enter you password: ");
            string store_password = Console.ReadLine();
            bool check2 = _sr.CheckIfAccountExists(store, store_password);

            while (!check2)
            {
              Console.WriteLine("Invalid input, please try again:");
              Console.Write("Please enter you username again: ");
              store = Console.ReadLine();
              Console.Write("Please enter you password again: ");
              store_password = Console.ReadLine();
              check2 = _sr.CheckIfAccountExists(store, store_password);
            }
          }

        }

        private static void GetAllStore()
        {


          foreach (var s in _sr.Get())
          {
            Console.WriteLine(s);
          }
        }
        
        private static void ShowMenu()
        {

          foreach (var p in _ps.Get())
          {
            Console.WriteLine(p);
          }
        }

        private static List<Pizza> PreOrder()
        {
          List<Pizza> list = new List<Pizza>();

          Console.WriteLine("Choose a pizza from the menu");

          bool preorder = true;

          while (preorder)
          {
            Console.WriteLine("0) I don't want more pizza");
            ShowMenu();
            Console.Write("Enter your pizza's number: ");
            int selection = Int32.Parse(Console.ReadLine());
            bool check = CheckIfNumMenuPizzaIsValid(selection) || selection == 0;
            
            while (!check)
            {
              Console.Write("The option you selected is not valid, please try again: ");
              selection = Int32.Parse(Console.ReadLine());
              check = CheckIfNumMenuPizzaIsValid(selection) || selection == 0;
            }
            if (selection == 0 && list.Count == 0)
            {
              Console.WriteLine("You didn't place an order");
              preorder = false;
            }
            else if (selection == 0 && list.Count > 0)
            {
              
              Console.WriteLine("This is your order:");
              foreach (var p in list)
              {
                decimal totalSum =+ p.Price;
                Console.WriteLine($"{p.Name} ${p.Price}");
              } 
              preorder = false;
            }
            else
            {
              Pizza pizza = _pr.GetPizzaByNumMenu(selection);
              list.Add(pizza);
              Console.WriteLine("This is your order:");
              foreach (var p in list)
              {
                Console.WriteLine($"{p.Name} ${p.Price}");
              } 
            
              preorder = true;
            }

          }
              
          return list;
        }


        private static bool CheckIfNumMenuPizzaIsValid(int nuMenu)
        {
          Pizza pizza = _pr.GetPizzaByNumMenu(nuMenu);
          if (pizza == null)
          {
            return false;
          }
          else
          {
            return true;
          }
        }

        // private static void PostAllPizza()
        // {
        //   var crust = _cr.Get();
        //   var size = _sr.Get();

        //   _ps.Post(crust[0], size[0], null);

        // }

    }
}
