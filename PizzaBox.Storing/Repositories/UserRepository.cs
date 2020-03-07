using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Databases;

namespace PizzaBox.Storing.Repositories
{
  public class UserRepository : ARepository<User> //: IUser
  {
    private static readonly UserRepository _ur = new UserRepository();

    public override List<User> Get() 
    {
			return Table.ToList();
    }

    public UserRepository() : base(_db.User) 
    {

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

    // public static bool HasItBeen2Hours(long userId)
    // {
    //   List<Order> list = OrderRepository.Get();
      
    //   return _db.Order.SingleOrDefault(o => o.UserId == userId).
    // }

    // public List<User> Get()
    // {
    //   return _db.User.Include(u => u.Name).Include(u => u.Address).ToList();
    // }

    // public User Get(long id)
    // {
    //   return _db.User.SingleOrDefault(u => u.UserId == id);
    // }
  
    // //INSERT
    // public bool Post(User user)
    // {
    //   _db.User.Add(user);
    //   return _db.SaveChanges() == 1;
    // }

  }
}