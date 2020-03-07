using System;
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

    private static readonly OrderRepository _or = new OrderRepository();


    //TODO: 
    public override List<Order> Get() 
    {
			return Table.ToList();

    }

    public OrderRepository() : base(_db.Order) 
    {

		}

    public List<Order> Get(Store store)
    {
      List<Order> list = (_db.Order.Where(o => o.StoreId == store.StoreId).ToList());
      
      return list;
    }

    public List<Order> GetPeriod(Store store, double days)
    {
      List<Order> list = (_db.Order.Where(o => o.StoreId == store.StoreId && o.Date.AddHours(days*24) >= DateTime.Now).ToList());
      
      return list;
    }

    public List<Order> GetPeriod(User user, double days)
    {
      List<Order> list = (_db.Order.Where(o => o.UserId == user.UserId && o.Date.AddHours(days*24) >= DateTime.Now).ToList());
      
      return list;
    }
    

    public List<Order> Get(User user)
    {
      List<Order> list = (_db.Order.Where(o => o.UserId == user.UserId).ToList());
      
      return list;
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