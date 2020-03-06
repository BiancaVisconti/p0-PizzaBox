using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Databases;

namespace PizzaBox.Storing.Repositories
{
  public class OrderRepository : ARepository<Order> //: IOrder
  {
    public override List<Order> Get() 
    {
			return Table.Include(o => o.OrderPizzas).Include(o => o.Date).Include(o => o.NumOfPizza).ToList();

    }

    public OrderRepository() : base(_db.Order) 
    {

		}
    //private static readonly PizzaBoxDbContext _db = new PizzaBoxDbContext();

    // public List<Order> Get()
    // {
    //   return _db.Order.Include(o => o.OrderPizzas).Include(o => o.Date).Include(o => o.NumOfPizza).ToList();
    // }

    // public Order Get(long id)
    // {
    //   return _db.Order.SingleOrDefault(o => o.OrderId == id);
    // }
  
    // //INSERT
    // public bool Post(Order order)
    // {
    //   _db.Order.Add(order);
    //   return _db.SaveChanges() == 1;
    // }

  }
}