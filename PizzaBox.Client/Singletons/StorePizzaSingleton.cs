using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;
using System.Linq;

namespace PizzaBox.Client.Singletons
{

  public class StorePizzaSingleton
  {
    private static readonly StorePizzaRepository _spr = new StorePizzaRepository();

    private static readonly StorePizzaSingleton _sps = new StorePizzaSingleton();

    public static StorePizzaSingleton Instance
    {
      get
      {
        return _sps;
      }
    }
    
    public List<StorePizza> Get()
    {
      return _spr.Get();
    }


    public bool Update(Store store, Pizza pizza, int new_inventory)
    {
      var sp = _spr.Get(store, pizza);
      sp.Inventory = new_inventory;
      return _spr.Update(sp);
    }
    
  }
}