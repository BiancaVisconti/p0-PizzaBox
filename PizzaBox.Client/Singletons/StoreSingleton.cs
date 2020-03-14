using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;
using System.Linq;

namespace PizzaBox.Client.Singletons
{

  public class StoreSingleton
  {
    private static readonly StoreRepository _sr = new StoreRepository();

    private static readonly StoreSingleton _ss = new StoreSingleton();

    public static StoreSingleton Instance
    {
      get
      {
        return _ss;
      }
    }

    public List<Store> Get()
    {
      return _sr.Get();
    }

    public bool Post(string name, string password, string address)
    {
      var s = new Store();
      s.Name = name;
      s.Password = password;
      s.Address = address;
      int numMenu = _sr.Get().Count;
      s.NumMenu = numMenu + 1;
    
      return _sr.Post(s);
    }
    
  }
}