using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;
using Xunit;

namespace PizzaBox.Testing.Specs
{
  public class StoreTests
  {
    [Fact]
    public void Test_RepositoryGet()
    {
      var sut = new StoreRepository();
      var actual = sut.Get();

      Assert.True(actual != null);
      Assert.True(actual.Count >= 0);
    }

    [Theory]
    [InlineData("MammaMia", "13131")]
    public void Test_RepositoryCheckIfAccountExists(string n, string p)
    {
      var sut = new StoreRepository();
      var actual = sut.CheckIfAccountExists(n, p);

      Assert.True(actual);
    }

    [Theory]
    [InlineData(1)]
    public void Test_RepositoryGetIdNumMenu(int n)
    {
      var sut = new StoreRepository();
      var actual = sut.GetId(n);

      Assert.IsType<long>(actual);
    }

    [Theory]
    [InlineData("MammaMia", "13131")]
    public void Test_RepositoryGetIdByNamePassword(string n, string p)
    {
      var sut = new StoreRepository();
      var actual = sut.GetId(n, p);

      Assert.IsType<long>(actual);
    }

    [Theory]
    [InlineData("MammaMia", "13131")]
    public void Test_RepositoryGetStore(string n, string p)
    {
      var sut = new StoreRepository();
      var actual = sut.GetStore(n, p);

      Assert.IsType<Store>(actual);
    }

    [Theory]
    [InlineData(1)]
    public void Test_RepositoryGetStoreByNumMenu(int n)
    {
      var sut = new StoreRepository();
      var actual = sut.GetStore(n);

      Assert.IsType<Store>(actual);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void Test_RepositoryGetName(long l)
    {
      var sut = new StoreRepository();
      var actual = sut.GetName(l);

      Assert.IsType<string>(actual);
    }
  }
}