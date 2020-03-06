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
    public override List<User> Get() 
    {
			return Table.Include(u => u.Name).Include(u => u.Address).ToList();

    }

    public UserRepository() : base(_db.User) 
    {

		}

    private static readonly UserRepository _ur = new UserRepository();

    // public static UserRepository Instance
    // {
    //   get
    //   {
    //     return _ur;
    //   }
    // }

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


    // private static readonly PizzaBoxDbContext _db = new PizzaBoxDbContext();

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