using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Databases;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Storing.Repositories
{
  public class PizzaRepository : ARepository<Pizza>, IPizza
  {
    private static readonly PizzaRepository _pr = new PizzaRepository();

    public override List<Pizza> Get() 
    {
			return Table.ToList();
    }

    public PizzaRepository() : base(_db.Pizza) 
    {

		}

    public string GetName(long pizzaId)
    {
      string pizzaName = (_db.Pizza.SingleOrDefault(p => p.PizzaId == pizzaId).Name);
      
      return pizzaName;
    }

    public decimal GetPrice(long pizzaId)
    {
      decimal pizzaPrice = (_db.Pizza.SingleOrDefault(p => p.PizzaId == pizzaId).Price);
      
      return pizzaPrice;
    }

    public Pizza GetPizzaByNumMenu(int id)
    {
      return _db.Pizza.SingleOrDefault(p => p.NumMenu == id);
    }

    
  }
}