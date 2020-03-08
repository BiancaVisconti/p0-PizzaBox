using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;
using Xunit;

namespace PizzaBox.Testing.Specs
{
  public class OrderTests
  {
    Order o = new Order();
    Store s = new Store();
    User u = new User();
    double d;
    OrderRepository sut = new OrderRepository();
    
    [Fact]
    public void Test_RepositoryGet()
    {
      var actual = sut.Get();

      Assert.True(actual != null);
      Assert.True(actual.Count >= 0);
    }

    [Fact]
    public void Test_RepositoryGetStore()
    {
      var actual = sut.Get(s);

      Assert.True(actual != null);
      Assert.True(actual.Count >= 0);
    }

    [Fact]
    public void Test_RepositoryGetUser()
    {
      var actual = sut.Get(u);

      Assert.True(actual != null);
      Assert.True(actual.Count >= 0);
    }


    [Fact]
    public void Test_RepositoryGetPeriodStore()
    {
      var actual = sut.GetPeriod(s, d);

      Assert.True(actual != null);
      Assert.True(actual.Count >= 0);
    }

    [Fact]
    public void Test_RepositoryGetPeriodUser()
    {
      var actual = sut.GetPeriod(u, d);

      Assert.True(actual != null);
      Assert.True(actual.Count >= 0);
    }

    [Fact]
    public void Test_RepositoryGet2Hours()
    {
      var actual = sut.Get2Hours(u);

      Assert.True(actual >= 0);
    }

    [Fact]
    public void Test_RepositoryGet24Hours()
    {
      var actual = sut.Get24HoursAtStore(u, s);

      Assert.True(actual >= 0);
    }
  }
}