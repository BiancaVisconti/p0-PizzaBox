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

    public List<Order> Get()
    {
      return _or.Get();
    }

    public bool Post(Store store, User user)
    {
      var o = new Order();
      o.OrderId = _or.Get().Count() + 1;
      o.StoreId = store.StoreId;
      o.UserId = user.UserId;
    
      return _or.Post(o);
    }
    
  }
}