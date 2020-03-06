using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;
using System.Linq;

namespace PizzaBox.Client.Singletons
{

  public class OrderSingleton
  {
    private static readonly OrderRepository _or = new OrderRepository();

    private static readonly OrderSingleton _os = new OrderSingleton();

    public static OrderSingleton Instance
    {
      get
      {
        return _os;
      }
    }

    private OrderSingleton() {}
    
    public List<Order> Get()
    {
      return _or.Get();
    }


    // public bool Post()
    // {
    //   var p = new Order();

    //   crust.Pizzas = new List<Pizza>{p}; // p.crust = *crustId
    //   size.Pizzas = new List<Pizza>{p};

    //   return _pr.Post(p);
    // }
    
  }
}