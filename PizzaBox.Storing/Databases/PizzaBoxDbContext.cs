using PizzaBox.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PizzaBox.Storing.Databases
{
  public class PizzaBoxDbContext : DbContext
  {
    public DbSet<Pizza> Pizza { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Store> Store { get; set; }
    public DbSet<Order> Order { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer("server=localhost;database=pizzaboxdb;user id=sa;password=Password12345;");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<User>().HasKey(u => u.UserId);

      builder.Entity<User>().HasMany(u => u.Orders).WithOne(o => o.User);

      builder.Entity<User>().HasData(new User[]
      {
        new User() { Name = "BiancaVisconti", Password = "12345", Address = "Central 960"},
        new User() { Name = "SilvanaRoncagliolo", Password = "67890", Address = "Street 4250"},
        new User() { Name = "JuanitoPerez", Password = "asasa", Address = "Calle 13"},
        new User() { Name = "MariaSoto", Password = "trebol", Address = "Avenida 89"}
        
      });

      builder.Entity<Store>().HasKey(s => s.StoreId);

      builder.Entity<Store>().HasMany(u => u.Orders).WithOne(o => o.Store);

      builder.Entity<Store>().HasData(new Store[]
      {
        new Store() { Name = "MammaMía", Password = "13131", Address = "Cooper 786", NumMenu = 1},
        new Store() { Name = "DiegoPizza", Password = "58585", Address = "Mitchel 83", NumMenu = 2},
        new Store() { Name = "MyPizza", Password = "lolol", Address = "Mesquite 476", NumMenu = 3},
        new Store() { Name = "TuPizza", Password = "trole", Address = "Abram 34", NumMenu = 4}
        
      });

      builder.Entity<Order>().HasKey(o => o.OrderId);
      builder.Entity<Pizza>().HasKey(p => p.PizzaId);
      builder.Entity<OrderPizza>().HasKey(op => new { op.PizzaId, op.OrderId });

      builder.Entity<Pizza>().HasMany(p => p.OrderPizzas).WithOne(pt => pt.Pizza).HasForeignKey(pt => pt.PizzaId);
      builder.Entity<Order>().HasMany(o => o.OrderPizzas).WithOne(op => op.Order).HasForeignKey(op => op.OrderId);

      builder.Entity<Order>().HasData(new Order[]
      {
        //new Order()
        
      });
      
      builder.Entity<Pizza>().HasData(new Pizza[]
      {
        new Pizza() { Name = "SMALL HAWAIIAN PIZZA", Description = "tomato sauce, vegan mozzarella, pineapple, green pepper, onions", Price = 5.00M, Inventory = 30, NumMenu = 1},
        new Pizza() { Name = "MEDIUM HAWAIIAN PIZZA", Description = "tomato sauce, vegan mozzarella, pineapple, green pepper, onions", Price = 9.50M, Inventory = 18, NumMenu = 2},
        new Pizza() { Name = "LARGE HAWAIIAN PIZZA", Description = "tomato sauce, vegan mozzarella, pineapple, green pepper, onions", Price = 13.90M, Inventory = 12, NumMenu = 3},
        new Pizza() { Name = "SMALL EXQUISITE PIZZA", Description = "tomato sauce, vegan mozzarella, tomatos, avocado, tofu, onions", Price = 6.00M, Inventory = 24, NumMenu = 4},
        new Pizza() { Name = "MEDIUM EXQUISITE PIZZA", Description = "tomato sauce, vegan mozzarella, tomatos, avocado, tofu, onions", Price = 11.00M, Inventory = 30, NumMenu = 5},
        new Pizza() { Name = "LARGE EXQUISITE PIZZA", Description = "tomato sauce, vegan mozzarella, tomatos, avocado, tofu, onions", Price = 15.50M, Inventory = 17, NumMenu = 6}
        
      });
    }
  }
}