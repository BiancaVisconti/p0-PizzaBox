using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;
using System.Linq;

namespace PizzaBox.Client.Singletons
{

  public class PizzaSingleton
  {
    private static readonly PizzaRepository _pr = new PizzaRepository();

    private static readonly PizzaSingleton _ps = new PizzaSingleton();

    public static PizzaSingleton Instance
    {
      get
      {
        return _ps;
      }
    }

    public List<Pizza> Get()
    {
      return _pr.Get();
    }

    /*public bool Post()
    {
      var p = new Pizza();
      p.Name = name;
      p.Description = description;

    
      return _pr.Post(p);
    }
    */
    
  }
}