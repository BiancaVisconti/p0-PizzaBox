using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Databases;

namespace PizzaBox.Storing.Repositories
{
  public class UserRepository : ARepository<User>, IUser
  {
    private static readonly UserRepository _ur = new UserRepository();
    private static readonly OrderRepository _or = new OrderRepository();

    public List<User> Get() 
    {
			return _db.User.ToList();
    }

    public bool CheckIfAccountExists(string name, string password)
    {
      if (_db.User.SingleOrDefault(u => u.Name == name && u.Password == password) != null)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public bool CheckIfUsernameExists(string name)
    {
      if (_db.User.SingleOrDefault(s => s.Name == name) != null)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public long GetId(string name, string password)
    {
      long id = (_db.User.SingleOrDefault(u => u.Name == name && u.Password == password).UserId);
      
      return id;
    }

    public User GetUser(string name, string password)
    {
      return _db.User.SingleOrDefault(u => u.Name == name && u.Password == password);
    }

    public string GetName(long userId)
    {
      string userName = (_db.User.SingleOrDefault(u => u.UserId == userId).Name);
      
      return userName;
    }

    public bool Post(User user)
    {
      _db.User.Add(user);
      return _db.SaveChanges() == 1;
    }

    public bool HasItBeenMoreThan2Hours(User user)
    {
      bool check = true;
      List<Order> list = _or.Get(user);
      foreach (var o in list)
      {
        
        DateTime date = DateTime.Now;
        double minutes = date.Subtract(o.Date).TotalMinutes;

        if (minutes < 2*60)
        {
          check = false;
        }
      }
      return check;
    } 

    public bool HasItBeenMoreThan24Hours(User user, Store store)
    {
      bool check = true;
      List<Order> list = _or.Get(user);
      if (list.Count() > 0)
      {
        int count = _or.Get24HoursAtStore(user, store);
        if (count > 0)
        {
          check = false;
        }
      }
      return check;
    }


  }
}