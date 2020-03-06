using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Databases;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Storing.Repositories
{
  public class PizzaRepository : ARepository<Pizza> //: IPizza
  {
    public override List<Pizza> Get() 
    {
			return Table.ToList();
    }

    public PizzaRepository() : base(_db.Pizza) 
    {

		}

    public Pizza GetPizzaByNumMenu(int id)
    {
      return _db.Pizza.SingleOrDefault(p => p.NumMenu == id);
    }

    // private static readonly PizzaBoxDbContext _db = new PizzaBoxDbContext();

    // public List<Pizza> Get()
    // {
    //   return _db.Pizza.ToList();
    // }

    // public Pizza Get(long id)
    // {
    //   return _db.Pizza.SingleOrDefault(p => p.PizzaId == id);
    // }

    // public Pizza GetPizzaByNumMenu(int id)
    // {
    //   return _db.Pizza.SingleOrDefault(p => p.NumMenu == id);
    // }

    // public decimal GetTotalPrice()
    // {
    //   return _db.Pizza.Sum(p => p.Price);
    // }

    // //INSERT
    // public bool Post(Pizza pizza)
    // {
    //   _db.Pizza.Add(pizza);
    //   return _db.SaveChanges() == 1;
    // }

    // //UPDATE
    // public bool Put(Pizza pizza)
    // {
    //   Pizza p = Get(pizza.PizzaId);
    //   p = pizza;

    //   return _db.SaveChanges() == 1;

    // }
  }
}