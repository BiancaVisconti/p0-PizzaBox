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

    protected DbSet<T> Table = null;

    public ARepository(DbSet<T> table) {
			Table = table;
		}
		public virtual List<T> Get() {
			return Table.ToList();
		}
		public T Get(long id) {
			return Table.SingleOrDefault(t => t.GetId() == id);
		}
		public bool Post(T entity) {
			Table.Add(entity);
			return _db.SaveChanges() == 1;
		}
		public bool Put(T entity) {
			T t = Get(entity.GetId());
			t = entity;
			return _db.SaveChanges() == 1;
		}
		public bool Delete(T entity) {
			Table.Remove(entity);
			return _db.SaveChanges() == 1;
		}
  }
}