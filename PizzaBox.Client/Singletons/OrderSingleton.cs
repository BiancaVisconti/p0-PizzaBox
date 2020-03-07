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

    //TODO: 
    public bool Post(Store store, User user)
    {
      var o = new Order() 
      {
        Store = store,
        User= user,
      };

      store.Orders = new List<Order>{o}; // p.crust = *crustId
      user.Orders = new List<Order>{o};
      

      return _or.Post(o);
    }
    
  }
}