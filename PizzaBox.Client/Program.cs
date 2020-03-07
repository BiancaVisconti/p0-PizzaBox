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

        private static readonly OrderPizzaSingleton _ops = OrderPizzaSingleton.Instance;

        private static readonly UserRepository _ur = new UserRepository();

        private static readonly StoreRepository _sr = new StoreRepository();

        private static readonly PizzaRepository _pr = new PizzaRepository();

        private static readonly OrderRepository _or = new OrderRepository();
        private static readonly OrderPizzaRepository _opr = new OrderPizzaRepository();

        private static void Main(string[] args)
        {   
            DoAll();
        }

        private static void DoAll()

        {
          string clientOrStore = ClientOrStore();

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
                    List<Pizza> list = PreOrder(user);
                    if (list.Count > 0)
                    {
                      PostOrder(store, user);
                      var order = _or.Get();
                      Order o = order[order.Count-1];
                      var dict = PizzaAmount(list);
                      foreach (var p in dict)
                      {
                        PostOrderPizza(o, p.Key, p.Value);    
                      }
                    }
                  }
                  else
                  {
                    Console.WriteLine("===================================================================");
                    Console.WriteLine("");
                    Console.WriteLine("YOU MADE AN ORDER WITHIN THE LAST 24 HOURS IN ANOTHER STORE");
                    Console.WriteLine("");
                    Console.WriteLine("REMEMBER, FOR THE FIRST 24 HOURS YOU CAN ONLY ORDER PIZZA FROM THE SAME PIZZERIA");
                    Console.WriteLine("");
                  } 
                }
                else
                {
                  Console.WriteLine("===================================================================");
                  Console.WriteLine("");
                  Console.WriteLine("YOU MADE AN ORDER WITHIN THE LAST 2 HOURS, YOU CANNOT ORDER NOW");
                  Console.WriteLine("");
                  Console.WriteLine("REMEMBER, FOR THE FIRST 24 HOURS YOU CAN ONLY ORDER PIZZA FROM THE SAME PIZZERIA");
                  Console.WriteLine("");
                }
                
              }
              else if (optionUser == "3")
              {
                Console.WriteLine($"Bye {user.Name}, hope to see you soon!");
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
                Console.WriteLine($"Bye {store.Name}, hope to see you soon!");
                finishMenu = true;
              }
            }
          }
            
        }

//========================================================================= LOGIN
        private static string ClientOrStore()
        {
          Console.WriteLine("");
          Console.WriteLine("WELCOME TO ARLINGTON'S FASTEST PIZZA DELIVERY APP!");
          Console.WriteLine("");
          Console.WriteLine("Are you a client or a store?");
          Console.WriteLine("");
          Console.WriteLine("Press 1: LOG AS CLIENT");
          Console.WriteLine("Press 2: LOG AS STORE");
          Console.WriteLine("");
          Console.Write("Enter your option's number: ");
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
          
          return who;
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

        private static Store LoginStore()
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

          Store store_ = _sr.GetStore(store, store_password);

          return store_;
        }
        
//========================================================================= STORES
        private static void StoreViewSalesAndRevenue(Store store)
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
            foreach (var o in listOrders)
            {
              List<OrderPizza> listOrderPizza = _opr.Get(o);
              foreach (var p in listOrderPizza)
              {
                totalAmount += p.Amount;
                int amount = p.Amount;
                long pizzaId = p.PizzaId;
                string namePizza = _pr.GetName(pizzaId);
                decimal price = _pr.GetPrice(pizzaId);
                totalRevenue += amount*price;
                decimal revenue = amount*price;
                Console.WriteLine($"{amount} {namePizza} ${revenue}");
                  
              }
            }
            Console.WriteLine("");
            Console.WriteLine($"Total number of pizzas sold: {totalAmount}");
            Console.WriteLine($"Total revenue: ${totalRevenue}");
            Console.WriteLine("");  
          }

        }

        private static void StoreViewSalesAndRevenuePerPeriod(Store store, double days)
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
            Console.WriteLine($"Sales and Revenue of the last {days} days");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("");
            decimal totalRevenue = 0;
            int totalAmount = 0;
            foreach (var o in listOrders)
            {
              List<OrderPizza> listOrderPizza = _opr.Get(o);
              foreach (var p in listOrderPizza)
              {
                totalAmount += p.Amount;
                int amount = p.Amount;
                long pizzaId = p.PizzaId;
                string namePizza = _pr.GetName(pizzaId);
                decimal price = _pr.GetPrice(pizzaId);
                totalRevenue += amount*price;
                decimal revenue = amount*price;
                Console.WriteLine($"{amount} {namePizza} ${revenue}");
                  
              }
            }
            Console.WriteLine("");
            Console.WriteLine($"Total number of pizzas sold: {totalAmount}");
            Console.WriteLine($"Total revenue: ${totalRevenue}");
            Console.WriteLine("");  
          }

        }

        private static void StoreViewCompletedOrdersPeriod(Store store, double days)
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
        private static void StoreViewCompletedOrders(Store store)
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
        
//======================================================================== CLIENTS        
        private static void ClientViewCompletedOrders(User user)
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
              Console.WriteLine($"Store: {nameStore}");
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
        private static void ClientViewCompletedOrdersByPeriod(User user, double days)
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
              Console.WriteLine($"Store: {nameStore}");
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
        

        private static Store ChooseAStore()
        {
          Console.WriteLine("-----------------------------");
          Console.WriteLine("");
          Console.WriteLine("Please choose a pizzeria from the following");
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
            Console.WriteLine("");
            check3 = CheckIfNumLocationIsValid(selection_store);
          }

          Store store = _sr.GetStore(Int32.Parse(selection_store));

          return store;
        }

        private static string MenuforClient()
        {
          Console.WriteLine("===================================================================");
          Console.WriteLine("");
          Console.Write("Choose one of the following options");
          Console.WriteLine("");
          Console.WriteLine("");
          Console.WriteLine("1) PAST ORDERS");
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

        private static string MenuChoosePeriod()
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


        private static string MenuForStore()
        {
          Console.WriteLine("===================================================================");
          Console.WriteLine("");
          Console.Write("Choose one of the following options");
          Console.WriteLine("");
          Console.WriteLine("1) PAST ORDERS");
          Console.WriteLine("2) SALES AND REVENUE");
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

        private static List<Pizza> PreOrder(User user)
        {
          List<Pizza> list = new List<Pizza>();
          decimal maxTotal = 250M;                 // *** MAXTOTAL = 250
          int maxTotalAmount = 50;                // *** MAXTOTALAMOUNT = 50 
          bool check = true;
          
          while (check)
          {
            ShowMenu();
            Console.WriteLine("");
            int selection_pizza = SelectPizza();
            

            Pizza pizza = _pr.GetPizzaByNumMenu(selection_pizza);
            decimal tempPrice = list.Sum(l => l.Price);
            int tempAmount = list.Count();
            if (tempPrice + pizza.Price > maxTotal)
            {
              Console.WriteLine($"You can't add this pizza, the total would go over ${maxTotal}");
              Console.WriteLine("");
            }
            else
            {
              list.Add(pizza);
              tempAmount = list.Count();
              
              PrintPartialOrder(list);
            }

            if (tempAmount < maxTotalAmount)
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
                list = RemovePizza(list);
                PrintPartialOrder(list);
                goto menuPizza;
              }
              else if (addPizza == "3")
              {
                CheckOut(list, user);
                check = false;
              }
            
            }
            else //tempAmount == maxTotalAmount
            {
              Console.WriteLine($"You have reached the maximum amount of pizzas for an order, which is {maxTotalAmount}");
              CheckOut(list, user);
              check = false;
            } 
          }
          
          return list;
        }

        private static void PrintPartialOrder(List<Pizza> list)
        {
          if (list.Count > 0)
          {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("");
            Console.WriteLine("THIS IS YOUR ORDER SO FAR:");
            Console.WriteLine("");
            foreach (var p in list)            
            {
              Console.WriteLine($"{p.Name} ${p.Price}");
            } 
            decimal sumPrices = list.Sum(l => l.Price);
            Console.WriteLine("");
            Console.WriteLine($"Your total so far is {sumPrices}");
            Console.WriteLine("");
          }
          else
          {
            Console.WriteLine("Order is empty");
          }
          
          
        }
        
        private static List<Pizza> RemovePizza(List<Pizza> list)
        {
          if (list.Count > 0)
          {
            list.RemoveAt(list.Count -1);
          }
          else
          {
            Console.WriteLine("There is no pizza to remove");
          }

          return list;
        }

        private static bool HasItBeenMoreThan2Hours(User user)
        {
          bool check = true;
          List<Order> list = _or.Get(user);
          foreach (var o in list)
          {
            
            DateTime date = new DateTime(2020, 03, 07, 04, 00, 00);
            //double minutes = DateTime.Now.Subtract(o.Date).TotalMinutes;
            double minutes = date.Subtract(o.Date).TotalMinutes;

            if (minutes < 2*60)
            {
              check = false;
            }
          }
          return check;
        } 

        private static bool HasItBeenMoreThan24Hours(User user, Store store)
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

        private static void CheckOut(List<Pizza> list, User user)
        {
          if (list.Count > 0)
          {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("");
            Console.WriteLine("THIS IS YOUR FINAL ORDER:");
            Console.WriteLine("");
            foreach (var p in list)            
            {
              Console.WriteLine($"{p.Name} ${p.Price}");
            }
            decimal sumPrices2 = list.Sum(l => l.Price);
            Console.WriteLine("");
            Console.WriteLine($"Your total is {sumPrices2}");
            Console.WriteLine(""); 
            Console.WriteLine($"{user.Name}, your order is on its way, enjoy!");
            Console.WriteLine("");
          }
          else
          {
            Console.WriteLine("No order has been placed");
          }

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


        private static void PostOrder(Store store, User user)
        {
          _os.Post(store, user);
        }

        private static void PostOrderPizza(Order order, Pizza pizza, int amount)
        {
          _ops.Post(order, pizza, amount);
        }

        private static Dictionary<Pizza, int> PizzaAmount(List<Pizza> list)
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
