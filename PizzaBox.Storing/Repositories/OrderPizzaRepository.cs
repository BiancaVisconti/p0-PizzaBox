using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Repositories
{
  public class OrderPizzaRepository : ARepository<OrderPizza>
  {
    private static readonly OrderPizzaRepository _opr = new OrderPizzaRepository();

    public override List<OrderPizza> Get() 
    {
			return Table.ToList();

    }

    public OrderPizzaRepository() : base(_db.OrderPizza) 
    {

		}

    public List<OrderPizza> Get(Order order)
    {
      List<OrderPizza> list = (_db.OrderPizza.Where(op => op.OrderId == order.OrderId).ToList());
      
      return list;
    }
    
  }
}