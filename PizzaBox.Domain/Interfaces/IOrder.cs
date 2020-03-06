using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Interfaces
{
  public interface IOrder
  {
    List<Pizza> ViewPizzasInOrder(long id);

    int ComputeOrderTotalCost(int id);

    bool AddOrder(List<Pizza> list, long storeid, long userid);
  }

}