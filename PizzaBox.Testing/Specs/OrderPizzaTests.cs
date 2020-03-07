using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;
using Xunit;

namespace PizzaBox.Testing.Specs
{
  public class OrderPizzaTests
  {
    Order o = new Order();
    OrderPizza op = new OrderPizza();
    OrderPizzaRepository sut = new OrderPizzaRepository();
    
    [Fact]
    public void Test_RepositoryGet()
    {
      var actual = sut.Get();

      Assert.True(actual != null);
      Assert.True(actual.Count >= 0);
    }

    [Fact]
    public void Test_RepositoryGetOrder()
    {
      var actual = sut.Get(o);

      Assert.True(actual != null);
      Assert.True(actual.Count >= 0);
    }

    /*[Fact]
    public void Test_RepositoryPost()
    {
      var actual = sut.Post(op);

      Assert.True(actual);
    }
    */


  }
}