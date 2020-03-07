using PizzaBox.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace PizzaBox.Storing.Databases
{
  public class PizzaBoxDbContext : DbContext
  {
    public DbSet<Pizza> Pizza { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Store> Store { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<OrderPizza> OrderPizza { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer("server=localhost;database=pizzaboxdb;user id=sa;password=Password12345;");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<User>().HasKey(u => u.UserId);

      builder.Entity<User>().HasMany(u => u.Orders).WithOne(o => o.User);

      builder.Entity<User>().Property(u => u.UserId).ValueGeneratedNever();

      builder.Entity<User>().HasData(new User[]
      {
        new User() { UserId = 1, Name = "BiancaVisconti", Password = "12345", Address = "Central 960"},
        new User() { UserId = 2, Name = "SilvanaRoncagliolo", Password = "67890", Address = "Street 4250"},
        new User() { UserId = 3, Name = "JuanitoPerez", Password = "asasa", Address = "Calle 13"},
        new User() { UserId = 4, Name = "MariaSoto", Password = "trebol", Address = "Avenida 89"}
      });

      builder.Entity<Store>().HasKey(s => s.StoreId);

      builder.Entity<Store>().HasMany(u => u.Orders).WithOne(o => o.Store);

      builder.Entity<Store>().Property(u => u.StoreId).ValueGeneratedNever();

      builder.Entity<Store>().HasData(new Store[]
      {
        new Store() { StoreId = 1, Name = "MammaMía", Password = "13131", Address = "Cooper 786", NumMenu = 1},
        new Store() { StoreId = 2, Name = "DiegoPizza", Password = "58585", Address = "Mitchel 83", NumMenu = 2},
        new Store() { StoreId = 3, Name = "MiPizza", Password = "lolol", Address = "Mesquite 476", NumMenu = 3},
        new Store() { StoreId = 4, Name = "TuPizza", Password = "trole", Address = "Abram 34", NumMenu = 4}
        
      });

      builder.Entity<Order>().HasKey(o => o.OrderId);

      builder.Entity<Order>().HasMany(o => o.OrderPizzas).WithOne(op => op.Order);

      builder.Entity<Order>().Property(o => o.OrderId).ValueGeneratedNever();

      builder.Entity<Order>().HasData(new Order[]
      {
        new Order() { OrderId = 1, Date = new DateTime(2020, 03, 01, 07, 09, 14), StoreId = 1, UserId = 1},
        new Order() { OrderId = 2, Date = new DateTime(2020, 02, 17, 07, 09, 14), StoreId = 2, UserId = 2},
        new Order() { OrderId = 3, Date = new DateTime(2020, 03, 05, 07, 09, 14), StoreId = 1, UserId = 2},
        new Order() { OrderId = 4, Date = new DateTime(2020, 03, 06, 23, 00, 00), StoreId = 1, UserId = 1},
        new Order() { OrderId = 5, Date = new DateTime(2020, 03, 06, 10, 09, 00), StoreId = 2, UserId = 2}
      });
      
      
      builder.Entity<OrderPizza>().HasKey(op => op.OrderPizzaId);

      builder.Entity<OrderPizza>().Property(op => op.OrderPizzaId).ValueGeneratedNever();

      builder.Entity<OrderPizza>().HasData(new OrderPizza[]
      {
        new OrderPizza() { OrderPizzaId = 1, OrderId = 1, PizzaId = 3, Amount = 2},
        new OrderPizza() { OrderPizzaId = 2, OrderId = 1, PizzaId = 5, Amount = 3},
        new OrderPizza() { OrderPizzaId = 3, OrderId = 2, PizzaId = 2, Amount = 1},
        new OrderPizza() { OrderPizzaId = 4, OrderId = 3, PizzaId = 3, Amount = 1},
        new OrderPizza() { OrderPizzaId = 5, OrderId = 4, PizzaId = 6, Amount = 2},
        new OrderPizza() { OrderPizzaId = 6, OrderId = 5, PizzaId = 2, Amount = 1}      
      });
      
      builder.Entity<Pizza>().HasKey(p => p.PizzaId);

      builder.Entity<Pizza>().HasMany(p => p.OrderPizzas).WithOne(op => op.Pizza);
      
      builder.Entity<Pizza>().Property(p => p.PizzaId).ValueGeneratedNever();
      
      builder.Entity<Pizza>().HasData(new Pizza[]
      {
        new Pizza() { PizzaId = 1, Name = "SMALL HAWAIIAN PIZZA", Description = "thin crust, tomato sauce, vegan mozzarella, pineapple, green pepper, onions", Price = 5.00M, NumMenu = 1},
        new Pizza() { PizzaId = 2, Name = "MEDIUM HAWAIIAN PIZZA", Description = "thin crust, tomato sauce, vegan mozzarella, pineapple, green pepper, onions", Price = 9.50M, NumMenu = 2},
        new Pizza() { PizzaId = 3, Name = "LARGE HAWAIIAN PIZZA", Description = "thin crust, tomato sauce, vegan mozzarella, pineapple, green pepper, onions", Price = 13.90M, NumMenu = 3},
        new Pizza() { PizzaId = 4, Name = "SMALL EXQUISITE PIZZA", Description = "flatbread, tomato sauce, vegan mozzarella, tomatos, avocado, tofu, onions", Price = 6.00M, NumMenu = 4},
        new Pizza() { PizzaId = 5, Name = "MEDIUM EXQUISITE PIZZA", Description = "flatbread, tomato sauce, vegan mozzarella, tomatos, avocado, tofu, onions", Price = 11.00M, NumMenu = 5},
        new Pizza() { PizzaId = 6, Name = "LARGE EXQUISITE PIZZA", Description = "flatbread, tomato sauce, vegan mozzarella, tomatos, avocado, tofu, onions", Price = 15.50M, NumMenu = 6}
      });
    }
  }
}