using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Repositories
{
  public class OrderPizzaRepository : ARepository<OrderPizza>, IOrderPizza
  {
    private static readonly OrderPizzaRepository _opr = new OrderPizzaRepository();

    public List<OrderPizza> Get() 
    {
			return _db.OrderPizza.ToList();
    }

    public List<OrderPizza> Get(Order order)
    {
      List<OrderPizza> list = (_db.OrderPizza.Where(op => op.OrderId == order.OrderId).ToList());
      
      return list;
    }

    public bool Post(OrderPizza orderPizza)
    {
      _db.OrderPizza.Add(orderPizza);
      return _db.SaveChanges() == 1;
    }
    
  }
}