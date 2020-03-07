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
        new User() { UserId = 1, Name = "BiancaVisconti", Password = "bianca", Address = "Central 960"},
        new User() { UserId = 2, Name = "SilvanaRoncagliolo", Password = "silvana", Address = "Street 4250"},
        new User() { UserId = 3, Name = "MacarenaRodriguez", Password = "maca", Address = "Calle 13"},
        new User() { UserId = 4, Name = "VictoriaTorres", Password = "vicky", Address = "3 Poniente"},
        new User() { UserId = 5, Name = "Rufuz", Password = "beio", Address = "Avenida Beio 15"},
        new User() { UserId = 6, Name = "NancyCastro", Password = "nancy", Address = "15 Norte"},
        new User() { UserId = 7, Name = "JennyLoe", Password = "jenny", Address = "Avenida Beio 15"},
        new User() { UserId = 8, Name = "Fernanda", Password = "ferna", Address = "Blanca Estela 76"},
        new User() { UserId = 9, Name = "Francisca", Password = "fran", Address = "Los Pellines 950"},
        new User() { UserId = 10, Name = "Sofia", Password = "sofia", Address = "Lomas de Montenar 1190"}
      });

      builder.Entity<Store>().HasKey(s => s.StoreId);

      builder.Entity<Store>().HasMany(u => u.Orders).WithOne(o => o.Store);

      builder.Entity<Store>().Property(u => u.StoreId).ValueGeneratedNever();

      builder.Entity<Store>().HasData(new Store[]
      {
        new Store() { StoreId = 1, Name = "MammaMia", Password = "13131", Address = "Cooper 786", NumMenu = 1},
        new Store() { StoreId = 2, Name = "DiegoPizza", Password = "58585", Address = "Mitchel 83", NumMenu = 2},
        new Store() { StoreId = 3, Name = "MiPizza", Password = "lolol", Address = "Mesquite 476", NumMenu = 3},
        new Store() { StoreId = 4, Name = "TuPizza", Password = "trole", Address = "Abram 34", NumMenu = 4},
        new Store() { StoreId = 5, Name = "Mangiata", Password = "comer", Address = "Cooper 132", NumMenu = 5},
        new Store() { StoreId = 6, Name = "PizzaLover", Password = "pizza", Address = "Mesquite 87", NumMenu = 6}
        
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
        new Order() { OrderId = 5, Date = new DateTime(2020, 03, 06, 15, 09, 00), StoreId = 2, UserId = 2},
        new Order() { OrderId = 6, Date = new DateTime(2020, 03, 01, 15, 00, 00), StoreId = 6, UserId = 9},
        new Order() { OrderId = 7, Date = new DateTime(2020, 01, 06, 12, 30, 00), StoreId = 5, UserId = 10},
        new Order() { OrderId = 8, Date = new DateTime(2019, 11, 12, 14, 25, 00), StoreId = 4, UserId = 7},
        new Order() { OrderId = 9, Date = new DateTime(2019, 12, 31, 20, 00, 00), StoreId = 3, UserId = 8}
      });
      
      
      builder.Entity<OrderPizza>().HasKey(op => op.OrderPizzaId);

      builder.Entity<OrderPizza>().Property(op => op.OrderPizzaId).ValueGeneratedNever();

      builder.Entity<OrderPizza>().HasData(new OrderPizza[]
      {
        new OrderPizza() { OrderPizzaId = 1, OrderId = 1, PizzaId = 3, Amount = 2},
        new OrderPizza() { OrderPizzaId = 2, OrderId = 1, PizzaId = 5, Amount = 3},
        new OrderPizza() { OrderPizzaId = 3, OrderId = 2, PizzaId = 2, Amount = 1},
        new OrderPizza() { OrderPizzaId = 4, OrderId = 3, PizzaId = 4, Amount = 1},
        new OrderPizza() { OrderPizzaId = 5, OrderId = 4, PizzaId = 6, Amount = 2},
        new OrderPizza() { OrderPizzaId = 6, OrderId = 5, PizzaId = 2, Amount = 1},
        new OrderPizza() { OrderPizzaId = 7, OrderId = 6, PizzaId = 7, Amount = 3},
        new OrderPizza() { OrderPizzaId = 8, OrderId = 6, PizzaId = 8, Amount = 1},
        new OrderPizza() { OrderPizzaId = 9, OrderId = 7, PizzaId = 9, Amount = 7},
        new OrderPizza() { OrderPizzaId = 10, OrderId = 7, PizzaId = 6, Amount = 2},
        new OrderPizza() { OrderPizzaId = 11, OrderId = 8, PizzaId = 5, Amount = 3},
        new OrderPizza() { OrderPizzaId = 12, OrderId = 8, PizzaId = 1, Amount = 1},
        new OrderPizza() { OrderPizzaId = 13, OrderId = 9, PizzaId = 9, Amount = 2},
        new OrderPizza() { OrderPizzaId = 14, OrderId = 9, PizzaId = 7, Amount = 1}
      });
      
      builder.Entity<Pizza>().HasKey(p => p.PizzaId);

      builder.Entity<Pizza>().HasMany(p => p.OrderPizzas).WithOne(op => op.Pizza);
      
      builder.Entity<Pizza>().Property(p => p.PizzaId).ValueGeneratedNever();
      
      builder.Entity<Pizza>().HasData(new Pizza[]
      {
        new Pizza() { PizzaId = 1, Name = "SMALL HAWAIIAN PIZZA", Description = "thin crust, tomato sauce, vegan cheese, pineapple, green pepper, onions", Price = 5.00M, NumMenu = 1},
        new Pizza() { PizzaId = 2, Name = "MEDIUM HAWAIIAN PIZZA", Description = "thin crust, tomato sauce, vegan cheese, pineapple, green pepper, onions", Price = 9.50M, NumMenu = 2},
        new Pizza() { PizzaId = 3, Name = "LARGE HAWAIIAN PIZZA", Description = "thin crust, tomato sauce, vegan cheese, pineapple, green pepper, onions", Price = 13.90M, NumMenu = 3},
        new Pizza() { PizzaId = 4, Name = "SMALL EXQUISITE PIZZA", Description = "flatbread, tomato sauce, vegan cheese, tomatos, avocado, tofu, onions", Price = 6.00M, NumMenu = 4},
        new Pizza() { PizzaId = 5, Name = "MEDIUM EXQUISITE PIZZA", Description = "flatbread, tomato sauce, vegan cheese, tomatos, avocado, tofu, onions", Price = 11.00M, NumMenu = 5},
        new Pizza() { PizzaId = 6, Name = "LARGE EXQUISITE PIZZA", Description = "flatbread, tomato sauce, vegan cheese, tomatos, avocado, tofu, onions", Price = 15.50M, NumMenu = 6},
        new Pizza() { PizzaId = 7, Name = "SMALL DELICIOUS PIZZA", Description = "thick crust, pesto sauce, vegan cheese, onions, red pepper, mushrooms", Price = 5.50M, NumMenu = 7},
        new Pizza() { PizzaId = 8, Name = "MEDIUM DELICIOUS PIZZA", Description = "thick crust, pesto sauce, vegan cheese, onions, red pepper, mushrooms", Price = 10.50M, NumMenu = 8},
        new Pizza() { PizzaId = 9, Name = "LARGE DELICIOUS PIZZA", Description = "thick crust, pesto sauce, vegan cheese, onions, red pepper, mushrooms", Price = 16.50M, NumMenu = 9}
      });
    }
  }
}