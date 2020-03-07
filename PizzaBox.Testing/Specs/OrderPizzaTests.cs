using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;
using Xunit;

namespace PizzaBox.Testing.Specs
{
  public class OrderPizzaTests
  {
    [Fact]
    public void Test_RepositoryGet()
    {
      var sut = new OrderPizzaRepository();
      var actual = sut.Get();

      Assert.True(actual != null);
      Assert.True(actual.Count >= 0);
    }

    [Fact]
    public void Test_RepositoryGetOrder(Order o)
    {
      var sut = new OrderPizzaRepository();
      var actual = sut.Get(o);

      Assert.True(actual != null);
      Assert.True(actual.Count >= 0);
    }

    [Fact]
    public void Test_RepositoryPost(OrderPizza op)
    {
      var sut = new OrderPizzaRepository();
      var actual = sut.Post(op);

      Assert.True(actual);
    }


  }
}