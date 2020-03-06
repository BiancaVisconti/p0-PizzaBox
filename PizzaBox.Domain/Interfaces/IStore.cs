using System.Collections.Generic;

namespace PizzaBox.Domain.Interfaces
{
  public interface IStore
  {
    //List<Order> ViewCompletedOrders(long StoreId)


    int SalesNum(long id);

    int SalesRevenue(long id);

    int TotalInventoryPerPizza(long id);

    bool AddNewPizzaToMenu(string name);

    bool RemovePizzaFromMenu(string name);
  }
}