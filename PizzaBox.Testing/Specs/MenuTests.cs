using System.Collections.Generic;
using PizzaBox.Client.Singletons;
using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing.Specs
{
  public class MenuTests
  {
    List<Order> lo = new List<Order>();
    List<Pizza> lp = new List<Pizza>();
    Store s = new Store();
    User u = new User();
    
    [Fact]
    public void Test_LoginUser()
    {
      var actual = MenuSingleton.LoginUser();

      Assert.True(actual != null);
    }

    [Fact]
    public void Test_LoginStore()
    {
      var actual = MenuSingleton.LoginStore();

      Assert.True(actual != null);
    }

    [Fact]
    public void Test_MenuForStore()
    {
      var actual = MenuSingleton.MenuForStore();

      Assert.IsType<string>(actual);
    }

    [Fact]
    public void Test_CalculateSalesAndRevenue()
    {
      var actual = MenuSingleton.CalculateSalesAndRevenue(lo);

      Assert.True(actual.Count >= 0);
    }

    [Fact]
    public void Test_PreOrder()
    {
      var actual = MenuSingleton.PreOrder(u);

      Assert.True(actual.Count >= 0);
    }

    [Fact]
    public void Test_RemovePizza()
    {
      var actual = MenuSingleton.RemovePizza(lp);

      Assert.True(actual.Count >= 0);
    }

    [Fact]
    public void Test_PizzaAmount()
    {
      var actual = MenuSingleton.PizzaAmount(lp);

      Assert.True(actual.Count >= 0);
    }
  }
}