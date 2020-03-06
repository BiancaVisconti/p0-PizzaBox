using System;
using System.Linq;
using System.Collections.Generic;
using PizzaBox.Client.Singletons;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client
{
  internal class Program
    {
        private static readonly PizzeriaSingleton _ps = PizzeriaSingleton.Instance;

        private static readonly OrderSingleton _os = OrderSingleton.Instance;

        private static readonly UserRepository _ur = new UserRepository();

        private static readonly StoreRepository _sr = new StoreRepository();

        private static readonly PizzaRepository _pr = new PizzaRepository();

        private static readonly OrderRepository _or = new OrderRepository();

        private static void Main(string[] args)
        {   
            //ShowMenu();

            //PreOrder();

            //PostAllPizza();

            DoAll();

            // var a = DateTime.Now;
            // //var b = DateTime(2019,03,03,10,30,23);
            // TimeSpan span = DateTime.Now.Subtract(new DateTime(1970,1,1,0,0,0));
            // Console.WriteLine(span);

            //Console.WriteLine(DateTime.Now.Ticks);

            // DateTime date1 = DateTime.Now;
            // DateTime date2 = new DateTime(2012, 1, 2, 1, 0, 0);
            // double minutes = (date1.Subtract(date2).TotalMinutes);
            // Console.WriteLine(minutes);
        }

        private static void DoAll()
        {
          Console.WriteLine("Welcome to Arlington's Fastest Pizza Delivery!");
          Console.WriteLine("");
          Console.WriteLine("Are you a client or a store?");
          Console.WriteLine("");
          Console.Write("Press 1 for client, 2 for store: ");
          string who = Console.ReadLine();
          Console.WriteLine("");
          bool check = who == "1" || who == "2";

          while (!check)
            {
              Console.Write("Invalid input, please try again: ");
              who = Console.ReadLine();
              Console.WriteLine("");
              check = (who == "1" || who == "2");
            }
          if (who == "1")
          {
            User user = LoginUser();
            Store store = ChooseAStore();
            List<Pizza> list = PreOrder();
            //TODO:
            //PostOrder();

          }
          else if (who == "2")
          {
            long storeid = LoginStore();
            MenuForStore();
          }
            
        }
        //TODO: 
        private static void PostOrder()
        {
          var store = _sr.Get();
          var user = _ur.Get();
          
          _os.Post(store[0], user[0]);
        }
        
        private static User LoginUser()
        {
          Console.Write("Please enter you username: ");
            string client = Console.ReadLine();
            Console.Write("Please enter you password: ");
            string cli_password = Console.ReadLine();
            Console.WriteLine("");
            bool check2 = _ur.CheckIfAccountExists(client, cli_password);

            while (!check2)
            {
              Console.WriteLine("Invalid input, please try again");
              Console.WriteLine("");
              Console.Write("Please enter you username again: ");
              client = Console.ReadLine();
              Console.Write("Please enter you password again: ");
              cli_password = Console.ReadLine();
              Console.WriteLine("");
              check2 = _ur.CheckIfAccountExists(client, cli_password);
            }

            User user = _ur.GetUser(client, cli_password);

            return user;
        }

        private static long LoginStore()
        {
          Console.Write("Please enter you username: ");
          string store = Console.ReadLine();
          Console.Write("Please enter you password: ");
          string store_password = Console.ReadLine();
          Console.WriteLine("");
          bool check2 = _sr.CheckIfAccountExists(store, store_password);

          while (!check2)            
          {
            Console.WriteLine("Invalid input, please try again");
            Console.WriteLine("");
            Console.Write("Please enter you username again: ");
            store = Console.ReadLine();
            Console.Write("Please enter you password again: ");
            store_password = Console.ReadLine();
            Console.WriteLine("");
            check2 = _sr.CheckIfAccountExists(store, store_password);
          }

            long storeid = _sr.GetId(store, store_password);

            return storeid;
        }

        private static Store ChooseAStore()
        {
          Console.WriteLine("Please choose a store from the following");
          Console.WriteLine("");
          ShowStores();
          Console.WriteLine("");

          Console.Write("Enter the store's number: ");
          string selection_store = Console.ReadLine();
          Console.WriteLine("");
          bool check3 = CheckIfNumLocationIsValid(selection_store);
              
          while (!check3)
          {              
            Console.Write("The option you selected is not valid, please try again: ");
            selection_store = Console.ReadLine();
            int selection_sto = Int32.Parse(selection_store);
            Console.WriteLine("");
            check3 = CheckIfNumLocationIsValid(selection_store);
          }

          Store store = _sr.GetStore(Int32.Parse(selection_store));

          return store;
        }

        private static void MenuForStore()
        {
          Console.Write("Choose one of the following options");
          Console.WriteLine("");
          Console.Write("1) Orders History");
          Console.Write("2) Inventory");
          Console.Write("3) Sales");
          Console.WriteLine("");

          Console.Write("Enter your option's number: ");
          string selection = Console.ReadLine();
          Console.WriteLine("");
          bool check = selection == "1" || selection == "2" || selection == "3";
              
          while (!check)
          {
            Console.Write("The option you selected is not valid, please try again: ");
            selection = Console.ReadLine();
            Console.WriteLine("");
            check = selection == "1" || selection == "2" || selection == "3";
          }

        } 
        private static void ShowMenu()
        {
          foreach (var p in _pr.Get())
          {
            Console.WriteLine(p);
          }
        }

        private static void ShowStores()
        {
          foreach (var s in _sr.Get())
          {
            Console.WriteLine(s);
          }
        }

        private static List<Pizza> PreOrder()
        {
          List<Pizza> list = new List<Pizza>();
          bool check = true;
          
          while (check)
          {
            ShowMenu();
            Console.WriteLine("");
            int selection_pizza = SelectPizza();

            Pizza pizza = _pr.GetPizzaByNumMenu(selection_pizza);
            list.Add(pizza);
            Console.WriteLine("");
            Console.WriteLine("This is your order:");
            Console.WriteLine("");
            foreach (var p in list)            
            {
              Console.WriteLine($"{p.Name} ${p.Price}");
            } 
            decimal sumPrices = list.Sum(l => l.Price);
            Console.WriteLine("");
            Console.WriteLine($"Your total so far is {sumPrices}");
            Console.WriteLine("");
            Console.WriteLine("Press 1: ADD A PIZZA");
            Console.WriteLine("Press 2: MY ORDER IS READY");
            Console.WriteLine("");
            Console.Write("Enter your option's number: ");
            string addPizza = Console.ReadLine();
            Console.WriteLine("");
            bool check2 = addPizza == "1" || addPizza == "2";
            while (!check2)
            {
              Console.Write("The option you selected is not valid, please try again: ");
              addPizza = Console.ReadLine();
              Console.WriteLine("");            
              check2 = addPizza == "1" || addPizza == "2";
            }

            if (addPizza == "1")
            {
              check = true;
            }
            else if (addPizza == "2")
            {
              Console.WriteLine("");
              Console.WriteLine("This is your order:");
              Console.WriteLine("");
              foreach (var p in list)            
              {
                Console.WriteLine($"{p.Name} ${p.Price}");
              }
              decimal sumPrices2 = list.Sum(l => l.Price);
              Console.WriteLine("");
              Console.WriteLine($"Your total is {sumPrices2}"); 
              check = false;
            }
          }
          
          return list;
        }

        private static int SelectPizza()
        {
          Console.Write("Enter your pizza's number: ");
          string selection_pizza = Console.ReadLine();
          Console.WriteLine("");
          bool check = CheckIfNumMenuPizzaIsValid(selection_pizza);
            
          while (!check)
          {
            Console.Write("The option you selected is not valid, please try again: ");
            selection_pizza = Console.ReadLine();
            //int selection_pizz = Int32.Parse(selection_pizza);
            Console.WriteLine("");            
            check = CheckIfNumMenuPizzaIsValid(selection_pizza);
          }
          return Int32.Parse(selection_pizza);
        }

        private static bool CheckIfNumMenuPizzaIsValid(string nuMenu)
        {
          int result;
          if (int.TryParse(nuMenu, out result))
          {
            Pizza pizza = _pr.GetPizzaByNumMenu(Int32.Parse(nuMenu));
            if (pizza == null)
            {
              return false;
            }
            else
            {
              return true;
            }
          }
          else
          {
            return false;
          }
          
          
        }

        private static bool CheckIfNumLocationIsValid(string nuMenu)
        {
          int result;
          if (int.TryParse(nuMenu, out result))
          {
            Store store = _sr.GetStoreByNumMenu(Int32.Parse(nuMenu));
            if (store == null)
            {
              return false;
            }
            else
            {
              return true;
            }
          }
          else{
            return false;
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
