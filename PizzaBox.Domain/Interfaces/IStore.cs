using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Interfaces
{
  public interface IStore
  {
    bool CheckIfAccountExists(string name, string password);

    long GetId(int numMenu);

    Store GetStore(string name, string password);

    long GetId(string name, string password);

    Store GetStore(int numMenu);

    Store GetStoreByNumMenu(int id);

    string GetName(long storeId);
  }
}