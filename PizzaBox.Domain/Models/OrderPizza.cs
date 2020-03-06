using System;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class OrderPizza
  {
    public long PizzaId { get; set; }
    public Pizza Pizza { get; set; }
    public long OrderId { get; set; }
    public Order Order { get; set; }
  }
}