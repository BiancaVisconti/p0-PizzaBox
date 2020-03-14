using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;
using System.Linq;

namespace PizzaBox.Client.Singletons
{

  public class UserSingleton
  {
    private static readonly UserRepository _ur = new UserRepository();

    private static readonly UserSingleton _us = new UserSingleton();

    public static UserSingleton Instance
    {
      get
      {
        return _us;
      }
    }

    public List<User> Get()
    {
      return _ur.Get();
    }

    public bool Post(string name, string password, string address)
    {
      var u = new User();
      u.Name = name;
      u.Password = password;
      u.Address = address;
    
      return _ur.Post(u);
    }
    
  }
}