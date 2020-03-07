using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;
using System.Linq;

namespace PizzaBox.Client.Singletons
{

  public class PizzeriaSingleton
  {
    private static readonly PizzaRepository _pr = new PizzaRepository();
    private static readonly PizzeriaSingleton _ps = new PizzeriaSingleton();

    public static PizzeriaSingleton Instance
    {
      get
      {
        return _ps;
      }
    }

    private PizzeriaSingleton() {}
    
    public List<Pizza> Get()
    {
      return _pr.Get();
    }
    
  }
}