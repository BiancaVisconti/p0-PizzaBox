using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
  public class Order : AModel
  {
    public long OrderId { get; set; }

    public DateTime Date { get; }

    public int NumOfPizza { get; }

    public List<Pizza> ListOfPizza { get; }

    public long StoreId;

    public long UserId;

    #region NAVIGATIONAL PROPERTIES
    public Store Store { get; set; }

    public User User { get; set; }

    public List<OrderPizza> OrderPizzas { get; set; }

    #endregion

    public Order()
    {
      OrderId = DateTime.Now.Ticks;

      Date = DateTime.Now;

      //ListOfPizza = new List<Pizza>();
      
    }

    public override long GetId()
    {
      return OrderId;
    }

  }

}