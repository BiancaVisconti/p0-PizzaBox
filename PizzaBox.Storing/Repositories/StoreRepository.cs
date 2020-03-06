using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Databases;

namespace PizzaBox.Storing.Repositories
{
  public class StoreRepository : ARepository<Store> //: IStore
  {

    public override List<Store> Get() 
    {
			return Table.Include(s => s.StoreId).ToList();

    }

    public StoreRepository() : base(_db.Store) 
    {

		}

    public bool CheckIfAccountExists(string name, string password)
    {
      if (_db.Store.SingleOrDefault(s => s.Name == name && s.Password == password) != null)
      {
        return true;
      }
      else
      {
        return false;
      }
    }
    // private static readonly PizzaBoxDbContext _db = new PizzaBoxDbContext();

    // public List<Store> Get()
    // {
    //   return _db.Store.ToList();
    // }

    // public Store Get(long id)
    // {
    //   return _db.Store.SingleOrDefault(s => s.StoreId == id);
    // }
  
    // //INSERT
    // public bool Post(Store store)
    // {
    //   _db.Store.Add(store);
    //   return _db.SaveChanges() == 1;
    // }
  }
}