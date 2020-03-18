using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;
using System.Linq;
using System;

namespace PizzaBox.Client.Singletons
{

  public class MenuSingleton
  {
    private static readonly UserRepository _ur = new UserRepository();
    private static readonly StoreRepository _sr = new StoreRepository();
    private static readonly PizzaRepository _pr = new PizzaRepository();
    private static readonly OrderRepository _or = new OrderRepository();
    private static readonly OrderPizzaRepository _opr = new OrderPizzaRepository();
    private static readonly StorePizzaRepository _spr = new StorePizzaRepository();
    private static readonly OrderSingleton _os = OrderSingleton.Instance;
    private static readonly UserSingleton _us = UserSingleton.Instance;
    private static readonly StoreSingleton _ss = StoreSingleton.Instance;
    private static readonly StorePizzaSingleton _sps = StorePizzaSingleton.Instance;
    private static readonly OrderPizzaSingleton _ops = OrderPizzaSingleton.Instance;
    private static readonly MenuSingleton _ms = new MenuSingleton();
    
    public static MenuSingleton Instance
    {
      get
      {
        return _ms;
      }
    }

     public void DoAll()

        {
          string loginOrAccount = LoginOrCreateAccount();

          if (loginOrAccount == "2")
          {
            string clientOrStore_ = CreateClientOrStore();
            if(clientOrStore_ == "1")
            {
              CreateClientAccount();
            }
            else
            {
              CreatePizzeriaAccount();
            }
          }

          string clientOrStore = LoginClientOrStore();

          if (clientOrStore == "1")
          {
            User user = LoginUser();
            bool finishMenu = false;

            while (!finishMenu)
            {
              string optionUser = MenuforClient();

              if ( optionUser == "1")
              {
                string option = MenuChoosePeriod();
                if(option == "1")
                {
                  ClientViewCompletedOrders(user);
                }
                else if (option == "2")
                {
                  ClientViewCompletedOrdersByPeriod(user, 7);
                }
                else if (option == "3")
                {
                  ClientViewCompletedOrdersByPeriod(user, 30);
                }
              }
              else if (optionUser == "2")
              {
                bool check1 = HasItBeenMoreThan2Hours(user);
                if (check1)
                {
                  Store store = ChooseAStore();
                  bool check2 = HasItBeenMoreThan24Hours(user, store);
                  if (check2)
                  {
                    List<Pizza> list = PreOrder(user, store);
                    if (list.Count > 0)
                    {
                      PostOrder(store, user);
                      var order = _or.Get();
                      Order o = order[order.Count-1];
                      var dict = PizzaAmount(list);
                      foreach (var p in dict)
                      {
                        PostOrderPizza(o, p.Key, p.Value);
                        int old_inventory = _spr.GetInventory(store, p.Key);
                        int new_inventory = old_inventory - p.Value;
                        UpdateInventory(store, p.Key, new_inventory);    
                      }
                    }
                  }
                  else
                  {
                    Console.WriteLine("========================================================================");
                    Console.WriteLine("");
                    Console.WriteLine("YOU MADE AN ORDER WITHIN THE LAST 24 HOURS IN ANOTHER STORE");
                    Console.WriteLine("");
                    Console.WriteLine("FOR THE FIRST 24 HOURS YOU CAN ONLY ORDER PIZZA FROM THE SAME PIZZERIA");
                    Console.WriteLine("");
                  } 
                }
                else
                {
                  Console.WriteLine("========================================================================");
                  Console.WriteLine("");
                  Console.WriteLine("YOU MADE AN ORDER WITHIN THE LAST 2 HOURS, YOU CANNOT ORDER NOW");
                  Console.WriteLine("");
                  Console.WriteLine("FOR THE FIRST 24 HOURS YOU CAN ONLY ORDER PIZZA FROM THE SAME PIZZERIA");
                  Console.WriteLine("");
                }
                
              }
              else if (optionUser == "3")
              {
                Console.WriteLine($"Bye {user.Name}, hope to see you soon!");
                Console.WriteLine("");
                finishMenu = true;
              }
            }
          }
          else if (clientOrStore == "2")
          {
            Store store = LoginStore();
            bool finishMenu = false;

            while (!finishMenu)
            {
              string optionStore = MenuForStore();

              if (optionStore == "1")
              {
                string option = MenuChoosePeriod();
                if(option == "1")
                {
                  StoreViewCompletedOrders(store);
                }
                else if (option == "2")
                {
                  StoreViewCompletedOrdersPeriod(store, 7);
                }
                else if (option == "3")
                {
                  StoreViewCompletedOrdersPeriod(store, 30);
                }
                
              }
              else if (optionStore == "2")
              {
                string option = MenuChoosePeriod();
                if(option == "1")
                {
                  StoreViewSalesAndRevenue(store);
                }
                else if (option == "2")
                {
                  StoreViewSalesAndRevenuePerPeriod(store, 7);
                }
                else if (option == "3")
                {
                  StoreViewSalesAndRevenuePerPeriod(store, 30);
                }
              }
              else if (optionStore == "3")
              {
                StoreViewInventory(store);
              }
              else if (optionStore == "4")
              {
                AddPizzaInventory(store);
              }
              else if (optionStore == "5")
              {
                Console.WriteLine($"Bye {store.Name}, hope to see you soon!");
                Console.WriteLine("");
                finishMenu = true;
              }
            }
          }
          else if (clientOrStore == "3")
          {

          }
        }

//========================================================================= LOGIN        
        
        public static string LoginOrCreateAccount()
        {
          Console.WriteLine("");
          Console.WriteLine("WELCOME TO ARLINGTON'S FASTEST PIZZA DELIVERY APP!");
          Console.WriteLine("");
          Console.WriteLine("1) LOG IN");
          Console.WriteLine("2) CREATE AN ACCOUNT");
          Console.WriteLine("");
          Console.Write("Enter your option's number: ");
          string option = Console.ReadLine();
          Console.WriteLine("");
          bool check = option == "1" || option == "2";
          while (!check)
            {
              Console.Write("Invalid input, please try again: ");
              option = Console.ReadLine();
              Console.WriteLine("");
              check = (option == "1" || option == "2");
            }
          return option;
        }
        
        public static string LoginClientOrStore()
        {
          Console.WriteLine("1) LOG AS CLIENT");
          Console.WriteLine("2) LOG AS PIZZERIA");
          Console.WriteLine("3) EXIT");
          Console.WriteLine("");
          Console.Write("Enter your option's number: ");
          string who = Console.ReadLine();
          Console.WriteLine("");
          bool check = who == "1" || who == "2" || who == "3";
          while (!check)
            {
              Console.Write("Invalid input, please try again: ");
              who = Console.ReadLine();
              Console.WriteLine("");
              check = (who == "1" || who == "2" || who == "3");
            }
          return who;
        }

        public static string CreateClientOrStore()
        {
          Console.WriteLine("1) CREATE CLIENT ACCOUNT");
          Console.WriteLine("2) CREATE PIZZERIA ACCOUNT");
          Console.WriteLine("");
          Console.Write("Enter your option's number: ");
          string option = Console.ReadLine();
          Console.WriteLine("");
          bool check = option == "1" || option == "2";
          while (!check)
            {
              Console.Write("Invalid input, please try again: ");
              option = Console.ReadLine();
              Console.WriteLine("");
              check = (option == "1" || option == "2");
            }
          return option;
        }
        
        public static User LoginUser()
        {
          Console.WriteLine("--------------------------");
          Console.Write("PLEASE ENTER YOUR USERNAME: ");
          string client = Console.ReadLine();
          Console.Write("PLEASE ENTER YOUR PASSWORD: ");
          string cli_password = Console.ReadLine();
          Console.WriteLine("--------------------------");
          Console.WriteLine("");
          bool check2 = _ur.CheckIfAccountExists(client, cli_password);

          while (!check2)
          {
            Console.WriteLine("Invalid input, please try again");
            Console.WriteLine("");
            Console.WriteLine("--------------------------------");
            Console.Write("PLEASE ENTER YOUR USERNAME AGAIN: ");
            client = Console.ReadLine();
            Console.Write("PLEASE ENTER YOUR PASSWORD AGAIN: ");
            cli_password = Console.ReadLine();
            Console.WriteLine("--------------------------------");
            Console.WriteLine("");
            check2 = _ur.CheckIfAccountExists(client, cli_password);
          }

          User user = _ur.GetUser(client, cli_password);

          return user;
        }

        public static Store LoginStore()
        {
          Console.WriteLine("--------------------------");
          Console.Write("PLEASE ENTER YOUR USERNAME: ");
          string store = Console.ReadLine();
          Console.Write("PLEASE ENTER YOUR PASSWORD: ");
          string store_password = Console.ReadLine();
          Console.WriteLine("--------------------------");
          Console.WriteLine("");
          bool check2 = _sr.CheckIfAccountExists(store, store_password);

          while (!check2)            
          {
            Console.WriteLine("Invalid input, please try again");
            Console.WriteLine("");
            Console.WriteLine("--------------------------------");
            Console.Write("PLEASE ENTER YOUR USERNAME AGAIN: ");
            store = Console.ReadLine();
            Console.Write("PLEASE ENTER YOUR PASSWORD AGAIN: ");
            store_password = Console.ReadLine();
            Console.WriteLine("--------------------------------");
            Console.WriteLine("");
            check2 = _sr.CheckIfAccountExists(store, store_password);
          }

          Store store_ = _sr.GetStore(store, store_password);

          return store_;
        }
        
//========================================================================= STORES
        
        public static void CreatePizzeriaAccount()
        {
          Console.WriteLine("----------------------------------");
          Console.Write("PLEASE ENTER YOUR DESIRED USERNAME: ");
          string username = Console.ReadLine();
          bool check = _sr.CheckIfUsernameExists(username);
          while (check)
          {
            Console.Write("THIS USERNAME IS ALREADY IN USE, PLEASE ENTER A NEW ONE: ");
            username = Console.ReadLine();
            check = _sr.CheckIfUsernameExists(username);
          }
          Console.Write("PLEASE ENTER YOUR PASSWORD: ");
          string password = Console.ReadLine();
          Console.Write("PLEASE CONFIRM YOUR PASSWORD: ");
          string password_ = Console.ReadLine();
          bool check2 = password == password_;
          while (!check2)
          {
            Console.WriteLine("");
            Console.WriteLine("SOMETHING IS NOT RIGHT WITH THE PASSWORD");
            Console.Write("PLEASE ENTER YOUR PASSWORD AGAIN: ");
            password = Console.ReadLine();
            Console.Write("AND CONFIRM AGAIN: ");
            password_ = Console.ReadLine();
            check2 = password == password_;
          }
          Console.Write("PLEASE ENTER YOUR ADDRESS: ");
          string address = Console.ReadLine();
          Console.WriteLine("----------------------------------");
          Console.WriteLine("");
          PostStore(username, password, address);
          Store store = _sr.GetStore(username, password);
          foreach (var p in _pr.Get())
          {
            PostStorePizza(store, p);
          }
          Console.WriteLine($"{username}, your account is all set up!");
          Console.WriteLine("");
          Console.WriteLine("Now please update the inventory!");
          Console.WriteLine("");
          AddPizzaInventory(store);
          Console.WriteLine("========================================================================");
          Console.WriteLine("");
        }
        public static string MenuForStore()
        {
          Console.WriteLine("========================================================================");
          Console.WriteLine("");
          Console.Write("Choose one of the following options");
          Console.WriteLine("");
          Console.WriteLine("");
          Console.WriteLine("1) PAST ORDERS");
          Console.WriteLine("2) SALES AND REVENUE");
          Console.WriteLine("3) VIEW INVENTORY");
          Console.WriteLine("4) ADD OR REMOVE PIZZAS FROM INVENTORY");
          Console.WriteLine("5) LOG OUT");
          Console.WriteLine("");
          Console.Write("Enter your option's number: ");
          string selection = Console.ReadLine();
          Console.WriteLine("");
          bool check = selection == "1" || selection == "2" || selection == "3" || selection == "4" || selection == "5";
              
          while (!check)
          {
            Console.Write("The option you selected is not valid, please try again: ");
            selection = Console.ReadLine();
            Console.WriteLine("");
            check = selection == "1" || selection == "2" || selection == "3" || selection == "4" || selection == "5";
          }

          return selection;
        }

        public static Dictionary<long, int> CalculateSalesAndRevenue(List<Order> listOrders)
        {
          Dictionary<long, int> RepeatedPizzaSales = new Dictionary<long, int>();

          foreach (var o in listOrders)
          {
            List<OrderPizza> listOrderPizza = _opr.Get(o);
            for (int i = 0; i < listOrderPizza.Count(); i++)
            {
              if (RepeatedPizzaSales.ContainsKey(listOrderPizza[i].PizzaId))
              {
                RepeatedPizzaSales[listOrderPizza[i].PizzaId] += listOrderPizza[i].Amount;
              }
              else
              {
                RepeatedPizzaSales.Add(listOrderPizza[i].PizzaId, listOrderPizza[i].Amount);
              }
            }  
          }

          return RepeatedPizzaSales;
        }
        
        public static void StoreViewSalesAndRevenue(Store store)
        {
          Console.WriteLine("================================");
          Console.WriteLine("");
          List<Order> listOrders = _or.Get(store);
          if (listOrders.Count == 0)
          {
            Console.WriteLine("You don't have any sales so far");
            Console.WriteLine("");
          }
          else
          {
            Console.WriteLine("SALES AND REVENUE OF ALL TIME");
            Console.WriteLine("------------------------------");
            Console.WriteLine("");
            decimal totalRevenue = 0;
            int totalAmount = 0;
            Dictionary<long, int> RepeatedPizzaSales = CalculateSalesAndRevenue(listOrders);
            foreach (var p in RepeatedPizzaSales)
            {
              totalAmount += p.Value;
              int amount = p.Value;
              string namePizza = _pr.GetName(p.Key);
              decimal price = _pr.GetPrice(p.Key);
              totalRevenue += amount*price;
              decimal revenue = amount*price;
              Console.WriteLine($"{amount} {namePizza} ${revenue}");   
            }

            Console.WriteLine("");
            Console.WriteLine($"TOTAL NUMBER OF PIZZAS SOLD: {totalAmount}");
            Console.WriteLine($"TOTAL REVENUE: ${totalRevenue}");
            Console.WriteLine("");  
          }

        }
        
        public static void StoreViewSalesAndRevenuePerPeriod(Store store, double days)
        {
          Console.WriteLine("================================");
          Console.WriteLine("");
          List<Order> listOrders = _or.GetPeriod(store, days);
          if (listOrders.Count == 0)
          {
            Console.WriteLine($"You don't have any sales in the last {days} days");
            Console.WriteLine("");
          }
          else
          {
            Console.WriteLine($"SALES AND REVENUE OF THE LAST {days} DAYS");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("");
            decimal totalRevenue = 0;
            int totalAmount = 0;
            Dictionary<long, int> RepeatedPizzaSales = CalculateSalesAndRevenue(listOrders);
            foreach (var p in RepeatedPizzaSales)
            {
              totalAmount += p.Value;
              int amount = p.Value;
              string namePizza = _pr.GetName(p.Key);
              decimal price = _pr.GetPrice(p.Key);
              totalRevenue += amount*price;
              decimal revenue = amount*price;
              Console.WriteLine($"{amount} {namePizza} ${revenue}");   
            }
            Console.WriteLine("");
            Console.WriteLine($"Total number of pizzas sold: {totalAmount}");
            Console.WriteLine($"Total revenue: ${totalRevenue}");
            Console.WriteLine("");  
          }

        }

        public static void StoreViewCompletedOrdersPeriod(Store store, double days)
        {
          Console.WriteLine("================================");
          Console.WriteLine("");
          List<Order> listOrders = _or.GetPeriod(store, days);
          if (listOrders.Count == 0)
          {
            Console.WriteLine($"You don't have orders in the last {days} days");
            Console.WriteLine("");
          }
          else
          {
            int count = 1;
            Console.WriteLine($"ORDERS OF THE LAST {days} DAYS");
            Console.WriteLine("--------------------------");
            Console.WriteLine("");

            foreach (var o in listOrders)
            {
              decimal total = 0;
              Console.WriteLine("--------");
              Console.WriteLine($"Order {count} {o.Date}");
              Console.WriteLine("--------");
              Console.WriteLine("");
              long userId = o.UserId;
              string nameUser = _ur.GetName(userId);
              Console.WriteLine($"Client: {nameUser}");
              List<OrderPizza> listOrderPizza = _opr.Get(o);
              foreach (var p in listOrderPizza)
              {
                int amount = p.Amount;
                long pizzaId = p.PizzaId;
                string namePizza = _pr.GetName(pizzaId);
                decimal price = _pr.GetPrice(pizzaId);
                total += amount*price;
                Console.WriteLine($"{amount} {namePizza} ${price*amount}");
                  
              }
              count += 1;
              Console.WriteLine("");
              Console.WriteLine($"The total of the order was ${total}");
              Console.WriteLine("");
            }
          
              
          }

        }
        public static void StoreViewCompletedOrders(Store store)
        {
          Console.WriteLine("================================");
          Console.WriteLine("");
          List<Order> listOrders = _or.Get(store);
          if (listOrders.Count == 0)
          {
            Console.WriteLine("You don't have previous orders");
            Console.WriteLine("");
          }
          else
          {
            int count = 1;
            Console.WriteLine($"ORDERS OF ALL TIME");
            Console.WriteLine("------------------");
            Console.WriteLine("");
            foreach (var o in listOrders)
            {
              decimal total = 0;
              Console.WriteLine("--------");
              Console.WriteLine($"Order {count} {o.Date}");
              Console.WriteLine("--------");
              Console.WriteLine("");
              long userId = o.UserId;
              string nameUser = _ur.GetName(userId);
              Console.WriteLine($"Client: {nameUser}");
              List<OrderPizza> listOrderPizza = _opr.Get(o);
              foreach (var p in listOrderPizza)
              {
                int amount = p.Amount;
                long pizzaId = p.PizzaId;
                string namePizza = _pr.GetName(pizzaId);
                decimal price = _pr.GetPrice(pizzaId);
                total += amount*price;
                Console.WriteLine($"{amount} {namePizza} ${price*amount}"); 
              }
              count += 1;
              Console.WriteLine("");
              Console.WriteLine($"The total of the order was ${total}");
              Console.WriteLine("");
            }    
          }
        }

        public static void AddPizzaInventory(Store store)
        {
          Console.WriteLine("================================");
          Console.WriteLine("");
          Console.WriteLine("Current Inventory");
          Console.WriteLine("-----------------");
          Console.WriteLine($"Stock | Pizza");
          Console.WriteLine("-------------------------------");
          foreach (var sp in _spr.GetPerStore(store))
          {
            Pizza pizza = _pr.GetPizza(sp.PizzaId);
            Console.WriteLine($"  {sp.Inventory}   | {pizza.Name}");
          }
          Console.WriteLine("");
          Console.WriteLine("Enter the number of pizzas to add(+) or subtract(-) per type, if none put 0");
          foreach (var p in _spr.GetPerStore(store))
          {
            Pizza pizza = _pr.GetPizza(p.PizzaId);
            Console.Write($"{pizza.Name}: ");
            string add = Console.ReadLine();
            int result;
            bool check = int.TryParse(add, out result);
            while (!check)
            {              
              Console.WriteLine("");
              Console.Write("Not valid, must be a number, please try again: ");
              add = Console.ReadLine();
              Console.WriteLine("");
              check = int.TryParse(add, out result);
            }
            int new_inventory = p.Inventory + Int32.Parse(add);
            bool check2 = new_inventory >= 0;
            while (!check2)
            {
              Console.WriteLine("");
              Console.Write("Not valid, the total inventory can't be negative, please try again: ");
              add = Console.ReadLine();
              new_inventory = p.Inventory + Int32.Parse(add);
              check2 = new_inventory >= 0;
              Console.WriteLine("");
            }
            UpdateInventory(store, pizza, new_inventory);
                          
          }
          Console.WriteLine("");
          Console.WriteLine($"{store.Name}, the inventory is updated!");
          Console.WriteLine("");
        }
        
        public static void StoreViewInventory(Store store)
        {
          Console.WriteLine("================================");
          Console.WriteLine("");
          Console.WriteLine($"INVENTORY");
          Console.WriteLine("---------");
          Console.WriteLine("");
          Console.WriteLine($"Stock | Pizza");
          Console.WriteLine("-------------------------------");
          foreach (var sp in _spr.GetPerStore(store))
          {
            Pizza pizza = _pr.GetPizza(sp.PizzaId);
            Console.WriteLine($"  {sp.Inventory}   | {pizza.Name}");
          }
          Console.WriteLine("");
        }
        
//======================================================================== CLIENTS        
        
        public static void CreateClientAccount()
        {
          Console.WriteLine("----------------------------------");
          Console.Write("PLEASE ENTER YOUR DESIRED USERNAME: ");
          string username = Console.ReadLine();
          bool check = _ur.CheckIfUsernameExists(username);
          while (check)
          {
            Console.Write("THIS USERNAME IS ALREADY IN USE, PLEASE ENTER A NEW ONE: ");
            username = Console.ReadLine();
            check = _ur.CheckIfUsernameExists(username);
          }
          Console.Write("PLEASE ENTER YOUR PASSWORD: ");
          string password = Console.ReadLine();
          Console.Write("PLEASE CONFIRM YOUR PASSWORD: ");
          string password_ = Console.ReadLine();
          bool check2 = password == password_;
          while (!check2)
          {
            Console.WriteLine("");
            Console.WriteLine("SOMETHING IS NOT RIGHT WITH THE PASSWORD");
            Console.Write("PLEASE ENTER YOUR PASSWORD AGAIN: ");
            password = Console.ReadLine();
            Console.Write("AND CONFIRM AGAIN: ");
            password_ = Console.ReadLine();
            check2 = password == password_;
          }
          Console.Write("PLEASE ENTER YOUR ADDRESS: ");
          string address = Console.ReadLine();
          Console.WriteLine("----------------------------------");
          Console.WriteLine("");
          PostUser(username, password, address);
          Console.WriteLine($"{username}, your account is all set up!");
          Console.WriteLine("");
          Console.WriteLine("========================================================================");
          Console.WriteLine("");
        }
        public static void ClientViewCompletedOrders(User user)
        {
          Console.WriteLine("================================");
          Console.WriteLine("");
          List<Order> listOrders = _or.Get(user);
          if (listOrders.Count == 0)
          {
            Console.WriteLine("You don't have previous orders");
            Console.WriteLine("");
          }
          else
          {
            int count = 1;
            Console.WriteLine($"ORDERS OF ALL TIME");
            Console.WriteLine("------------------");
            Console.WriteLine("");
            foreach (var o in listOrders)
            {
              decimal total = 0;
              Console.WriteLine("--------");
              Console.WriteLine($"Order {count} {o.Date}");
              Console.WriteLine("--------");
              Console.WriteLine("");
              long storeId = o.StoreId;
              string nameStore = _sr.GetName(storeId);
              Console.WriteLine($"Pizzeria: {nameStore}");
              List<OrderPizza> listOrderPizza = _opr.Get(o);
              foreach (var p in listOrderPizza)
              {
                int amount = p.Amount;
                long pizzaId = p.PizzaId;
                string namePizza = _pr.GetName(pizzaId);
                decimal price = _pr.GetPrice(pizzaId);
                total += amount*price;
                Console.WriteLine($"{amount} {namePizza} ${price*amount}");
                  
              }
              count += 1;
              Console.WriteLine("");
              Console.WriteLine($"The total of your order was ${total}");
              Console.WriteLine("");
            }
          }
        }
        
        public static void ClientViewCompletedOrdersByPeriod(User user, double days)
        {
          Console.WriteLine("================================");
          Console.WriteLine("");
          List<Order> listOrders = _or.GetPeriod(user, days);
          if (listOrders.Count == 0)
          {
            Console.WriteLine($"You don't have orders in the last {days} days");
            Console.WriteLine("");
          }
          else
          {
            int count = 1;
            Console.WriteLine($"ORDERS OF THE LAST {days} DAYS");
            Console.WriteLine("--------------------------");
            Console.WriteLine("");
            foreach (var o in listOrders)
            {
              decimal total = 0;
              Console.WriteLine("--------");
              Console.WriteLine($"Order {count} {o.Date}");
              Console.WriteLine("--------");
              Console.WriteLine("");
              long storeId = o.StoreId;
              string nameStore = _sr.GetName(storeId);
              Console.WriteLine($"Pizzeria: {nameStore}");
              List<OrderPizza> listOrderPizza = _opr.Get(o);
              foreach (var p in listOrderPizza)
              {
                int amount = p.Amount;
                long pizzaId = p.PizzaId;
                string namePizza = _pr.GetName(pizzaId);
                decimal price = _pr.GetPrice(pizzaId);
                total += amount*price;
                Console.WriteLine($"{amount} {namePizza} ${price*amount}");
                  
              }
              count += 1;
              Console.WriteLine("");
              Console.WriteLine($"The total of your order was ${total}");
              Console.WriteLine("");
            }
          }
        }
        
        public static Store ChooseAStore()
        {
          Console.WriteLine("-----------------------------");
          Console.WriteLine("");
          Console.WriteLine("Please choose a pizzeria from the following");
          Console.WriteLine("");
          ShowStores();
          Console.WriteLine("");

          Console.Write("Enter the pizzeria's number: ");
          string selection_store = Console.ReadLine();
          Console.WriteLine("");
          bool check3 = CheckIfNumLocationIsValid(selection_store);
              
          while (!check3)
          {              
            Console.Write("The option you selected is not valid, please try again: ");
            selection_store = Console.ReadLine();
            Console.WriteLine("");
            check3 = CheckIfNumLocationIsValid(selection_store);
          }

          Store store = _sr.GetStore(Int32.Parse(selection_store));

          return store;
        }
        
        public static string MenuforClient()
        {
          Console.WriteLine("========================================================================");
          Console.WriteLine("");
          Console.Write("Choose one of the following options");
          Console.WriteLine("");
          Console.WriteLine("");
          Console.WriteLine("1) MY PAST ORDERS");
          Console.WriteLine("2) MAKE AN ORDER");
          Console.WriteLine("3) LOG OUT");
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
          return selection;
        }
        
        public static string MenuChoosePeriod()
        {
          Console.WriteLine("================================");
          Console.WriteLine("");
          Console.Write("Choose one of the following options");
          Console.WriteLine("");
          Console.WriteLine("");
          Console.WriteLine("1) ALL ORDERS");
          Console.WriteLine("2) LAST 7 DAYS");
          Console.WriteLine("3) LAST 30 DAYS");
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

          return selection;
        }

        public static void ShowMenu(Dictionary<long, int> dict)
        { 
          foreach (var p in dict)
          {
            if (p.Value > 0)
            {
              Pizza pizza = _pr.GetPizza(p.Key);
              Console.WriteLine(pizza);
            }
          }
        }
        
        public static void ShowStores()
        {
          foreach (var s in _sr.Get())
          {
            Console.WriteLine(s);
          }
        }

        public static List<Pizza> PreOrder(User user, Store store)
        {
          List<Pizza> list = new List<Pizza>();
          List<StorePizza> listStorePizza = _spr.GetPizzasInStore(store);
          Dictionary<long, int> dict = new Dictionary<long, int>();
          foreach (var p in listStorePizza)
          {
            dict.Add(p.PizzaId, p.Inventory);
          }
          decimal maxTotal = 250M;                 // *** MAXTOTAL = 250
          int maxTotalAmount = 10;                // *** MAXTOTALAMOUNT = 50 
          decimal tempPrice;
          int tempAmount = 0;
          bool check = true;

          
          while (check)
          {
            if(tempAmount == maxTotalAmount)
            {
              Console.WriteLine($"You can't add more pizzas, you have reached the maximum n° of pizzas for an order, which is {maxTotalAmount}");
              Console.WriteLine("");
            }
            else
            {
              ShowMenu(dict);
              Console.WriteLine("");
              int selection_pizza = SelectPizza(dict);
              
              Pizza pizza = _pr.GetPizzaByNumMenu(selection_pizza); 
              tempPrice = list.Sum(l => l.Price);
              tempAmount = list.Count();
              if (tempPrice + pizza.Price > maxTotal)
              {
                Console.WriteLine($"You can't add this pizza, the total would go over ${maxTotal}");
                Console.WriteLine("");
              }
              else if (tempAmount < maxTotalAmount && (tempPrice + pizza.Price) <= maxTotal)
              {
                list.Add(pizza);
                tempAmount = list.Count();
                dict[pizza.PizzaId]--;
                
                PrintPartialOrder(list);
              }
            }
            if (tempAmount <= maxTotalAmount)
            {
              menuPizza:
              Console.WriteLine("-----------------------------");
              Console.WriteLine("");
              Console.WriteLine("Press 1: ADD A PIZZA");
              Console.WriteLine("Press 2: REMOVE LAST PIZZA ADDED");
              Console.WriteLine("Press 3: MY ORDER IS READY");
              Console.WriteLine("");
              Console.Write("Enter your option's number: ");
              string addPizza = Console.ReadLine();
              Console.WriteLine("");
              bool check2 = addPizza == "1" || addPizza == "2" || addPizza == "3";
              while (!check2)
              {
                Console.Write("The option you selected is not valid, please try again: ");
                addPizza = Console.ReadLine();
                Console.WriteLine("");            
                check2 = addPizza == "1" || addPizza == "2" || addPizza == "3";
              }
              if (addPizza == "1")
              {
                check = true;
              }
              else if (addPizza == "2")
              {
                list = RemovePizza(list, dict);
                tempAmount = list.Count();
                PrintPartialOrder(list);
                goto menuPizza;
              }
              else if (addPizza == "3")
              {
                CheckOut(list, user);
                check = false;
              }
            }
          }
          return list;
        }

        public static void PrintPartialOrder(List<Pizza> list)
        {
          if (list.Count > 0)
          {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("");
            Console.WriteLine("This is your order so far");
            Console.WriteLine("");
            foreach (var p in list)            
            {
              Console.WriteLine($"{p.Name} ${p.Price}");
            } 
            decimal sumPrices = list.Sum(l => l.Price);
            Console.WriteLine("");
            Console.WriteLine($"Your total so far is ${sumPrices}");
            Console.WriteLine("");
          }
          else
          {
            Console.WriteLine("Order is empty");
          }
        }
        
        public static List<Pizza> RemovePizza(List<Pizza> list, Dictionary<long, int> dict)
        {
          if (list.Count > 0)
          {
            Pizza pizza = list[list.Count - 1];
            dict[pizza.PizzaId]++;
            list.RemoveAt(list.Count -1);
          }
          else
          {
            Console.WriteLine("There is no pizza to remove");
          }
          return list;
        }
        
        public static bool HasItBeenMoreThan2Hours(User user)
        {
          bool check = true;
          List<Order> list = _or.Get(user);
          foreach (var o in list)
          {
            
            DateTime date = DateTime.Now;
            double minutes = date.Subtract(o.Date).TotalMinutes;

            if (minutes < 2*60)
            {
              check = false;
            }
          }
          return check;
        } 

        public static bool HasItBeenMoreThan24Hours(User user, Store store)
        {
          bool check = true;
          List<Order> list = _or.Get(user);
          if (list.Count() > 0)
          {
            int count = _or.Get24HoursAtStore(user, store);
            if (count > 0)
            {
              check = false;
            }
          }
          return check;
        }
        
        public static void CheckOut(List<Pizza> list, User user)
        {
          if (list.Count > 0)
          {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("");
            Console.WriteLine("This is your final order");
            Console.WriteLine("");
            foreach (var p in list)            
            {
              Console.WriteLine($"{p.Name} ${p.Price}");
            }
            decimal sumPrices2 = list.Sum(l => l.Price);
            Console.WriteLine("");
            Console.WriteLine($"Your total is ${sumPrices2}");
            Console.WriteLine(""); 
            Console.WriteLine($"{user.Name}, your order is on its way, enjoy!");
            Console.WriteLine("");
          }
          else
          {
            Console.WriteLine("NO ORDER HAS BEEN PLACED");
          }
        }

        public static int SelectPizza(Dictionary<long, int> dict)
        {
          Console.Write("Enter your pizza's number: ");
          string selection_pizza = Console.ReadLine();
          Console.WriteLine("");
          bool check = CheckIfNumMenuPizzaIsValid(selection_pizza, dict);
          while (!check)
          {
            Console.Write("The option you selected is not valid, please try again: ");
            selection_pizza = Console.ReadLine();
            Console.WriteLine("");            
            check = CheckIfNumMenuPizzaIsValid(selection_pizza, dict);
          }
          return Int32.Parse(selection_pizza);
        }
        
        public static bool CheckIfNumMenuPizzaIsValid(string nuMenu, Dictionary<long, int> dict)
        {
          int result;
          if (int.TryParse(nuMenu, out result))
          {
            Pizza pizza = _pr.GetPizzaByNumMenu(Int32.Parse(nuMenu));
            if (pizza != null)
            {
              foreach (var d in dict)
              {
                if(d.Key == pizza.PizzaId && d.Value > 0)
                {
                  return true;
                }   
              }
              return false;
            }
            else
            {
              return false;
            }
            
          }
          else
          {
            return false;
          }          
        }    

        public static bool CheckIfNumLocationIsValid(string nuMenu)
        {
          int result;
          if (int.TryParse(nuMenu, out result))
          {
            Store store = _sr.GetStore(Int32.Parse(nuMenu)); ///*******CHANGE METHOD
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
       
        public static void PostOrder(Store store, User user)
        {
          _os.Post(store, user);
        }

        public static void PostOrderPizza(Order order, Pizza pizza, int amount)
        {
          _ops.Post(order, pizza, amount);
        }

        public static void PostStorePizza(Store store, Pizza pizza)
        {
          _sps.Post(store, pizza);
        }

        public static void PostUser(string name, string password, string address)
        {
          _us.Post(name, password, address);
        }

        public static void PostStore(string name, string password, string address)
        {
          _ss.Post(name, password, address);
        }
        
        public static void UpdateInventory(Store store, Pizza pizza, int new_inventory)
        {
          _sps.Update(store, pizza, new_inventory);
        }

        public static Dictionary<Pizza, int> PizzaAmount(List<Pizza> list)
        {
          Dictionary<Pizza, int> RepeatedPizzaOrder = new Dictionary<Pizza, int>();

          for (int i = 0; i < list.Count(); i++)
          {
              if (RepeatedPizzaOrder.ContainsKey(list[i]))
              {
                RepeatedPizzaOrder[list[i]]++;
              }
              else
              {
                RepeatedPizzaOrder.Add(list[i], 1);
              }
          }
          return RepeatedPizzaOrder;
        }
  }
}