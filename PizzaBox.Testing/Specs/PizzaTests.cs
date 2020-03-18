using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;
using Xunit;

namespace PizzaBox.Testing.Specs
{
  public class PizzaTests
  {
    PizzaRepository sut = new PizzaRepository();
    
    [Fact]
    public void Test_RepositoryGet()
    {
      var actual = sut.Get();

      Assert.True(actual != null);
      Assert.True(actual.Count >= 0);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void Test_RepositoryGetName(int l)
    {
      var actual = sut.GetName(l);

      Assert.IsType<string>(actual);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void Test_RepositoryGetPrice(int l)
    {
      var actual = sut.GetPrice(l);

      Assert.IsType<decimal>(actual);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void Test_RepositoryGetPizzaByNumMenu(int i)
    {
      var actual = sut.GetPizzaByNumMenu(i);

      Assert.IsType<Pizza>(actual);
    }

  }
}