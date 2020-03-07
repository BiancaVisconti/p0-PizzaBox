using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Storing.Databases;

namespace PizzaBox.Storing.Repositories
{
  public abstract class ARepository<T> where T : AModel
  {
    protected static readonly PizzaBoxDbContext _db = new PizzaBoxDbContext();

  }
}