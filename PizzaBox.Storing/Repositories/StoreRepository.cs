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
			return Table.ToList();

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

    public long GetId(int numMenu)
    {
      long id = (_db.Store.SingleOrDefault(s => s.NumMenu == numMenu).StoreId);
      
      return id;
    }

    public long GetId(string name, string password)
    {
      long id = (_db.Store.SingleOrDefault(s => s.Name == name && s.Password == password).StoreId);
      
      return id;
    }

    public Store GetStore(int numMenu)
    {
      return _db.Store.SingleOrDefault(s => s.NumMenu == numMenu);

    }

    public Store GetStoreByNumMenu(int id)
    {
      return _db.Store.SingleOrDefault(s => s.NumMenu == id);
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