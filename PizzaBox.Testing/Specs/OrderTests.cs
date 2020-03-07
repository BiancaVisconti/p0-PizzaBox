using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;
using Xunit;

namespace PizzaBox.Testing.Specs
{
  public class OrderTests
  {
    [Fact]
    public void Test_RepositoryGet()
    {
      var sut = new OrderRepository();
      var actual = sut.Get();

      Assert.True(actual != null);
      Assert.True(actual.Count >= 0);
    }

    [Fact]
    public void Test_RepositoryGetStore(Store s)
    {
      var sut = new OrderRepository();
      var actual = sut.Get(s);

      Assert.True(actual != null);
      Assert.True(actual.Count >= 0);
    }

    [Fact]
    public void Test_RepositoryGetUser(User u)
    {
      var sut = new OrderRepository();
      var actual = sut.Get(u);

      Assert.True(actual != null);
      Assert.True(actual.Count >= 0);
    }

    [Fact]
    public void Test_RepositoryGetPeriodStore(Store s, double d)
    {
      var sut = new OrderRepository();
      var actual = sut.GetPeriod(s, d);

      Assert.True(actual != null);
      Assert.True(actual.Count >= 0);
    }

    [Fact]
    public void Test_RepositoryGetPeriodUser(User u, double d)
    {
      var sut = new OrderRepository();
      var actual = sut.GetPeriod(u, d);

      Assert.True(actual != null);
      Assert.True(actual.Count >= 0);
    }

    [Fact]
    public void Test_RepositoryGet2Hours(User u)
    {
      var sut = new OrderRepository();
      var actual = sut.Get2Hours(u);

      Assert.True(actual >= 0);
    }

    [Fact]
    public void Test_RepositoryGet24Hours(User u, Store s)
    {
      var sut = new OrderRepository();
      var actual = sut.Get24HoursAtStore(u, s);

      Assert.True(actual >= 0);
    }

    [Fact]
    public void Test_RepositoryPost(Order o)
    {
      var sut = new OrderRepository();
      var actual = sut.Post(o);

      Assert.True(actual);
    }


  }
}