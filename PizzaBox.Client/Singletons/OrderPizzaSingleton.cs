using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;
using System.Linq;

namespace PizzaBox.Client.Singletons
{

  public class OrderPizzaSingleton
  {
    private static readonly OrderPizzaRepository _opr = new OrderPizzaRepository();

    private static readonly OrderPizzaSingleton _ops = new OrderPizzaSingleton();

    public static OrderPizzaSingleton Instance
    {
      get
      {
        return _ops;
      }
    }
    
    public List<OrderPizza> Get()
    {
      return _opr.Get();
    }

    public bool Post(Order order, Pizza pizza, int amount)
    {
      var op = new OrderPizza();
      op.OrderPizzaId = _opr.Get().Count() + 1;
      op.OrderId = order.OrderId;
      op.PizzaId = pizza.PizzaId;
      op.Amount = amount;
      return _opr.Post(op);
    }
    
  }
}