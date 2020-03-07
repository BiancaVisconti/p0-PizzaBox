using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;
using System.Linq;
using System;

namespace PizzaBox.Client.Singletons
{

  public class PizzeriaSingleton
  {
    
    private static readonly PizzaRepository _pr = new PizzaRepository();
    private static readonly PizzeriaSingleton _ps = new PizzeriaSingleton();

    public static PizzeriaSingleton Instance
    {
      get
      {
        return _ps;
      }
    }

    private PizzeriaSingleton() {}


    public static string ClientOrStore2()
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

    /*
    
    public List<Pizza> Get()
    {
      return _pr.Get();
    }

    */
    
  }
}