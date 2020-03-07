using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;
using Xunit;

namespace PizzaBox.Testing.Specs
{
  public class PizzaTests
  {
    [Fact]
    public void Test_RepositoryGet()
    {
      var sut = new PizzaRepository();
      var actual = sut.Get();

      Assert.True(actual != null);
      Assert.True(actual.Count >= 0);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void Test_RepositoryGetName(long l)
    {
      var sut = new PizzaRepository();
      var actual = sut.GetName(l);

      Assert.IsType<string>(actual);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void Test_RepositoryGetPrice(long l)
    {
      var sut = new PizzaRepository();
      var actual = sut.GetPrice(l);

      Assert.IsType<decimal>(actual);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void Test_RepositoryGetPizzaByNumMenu(int i)
    {
      var sut = new PizzaRepository();
      var actual = sut.GetPizzaByNumMenu(i);

      Assert.IsType<Pizza>(actual);
    }

  }
}