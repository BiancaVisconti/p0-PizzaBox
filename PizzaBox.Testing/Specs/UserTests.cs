using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;
using Xunit;

namespace PizzaBox.Testing.Specs
{
  public class UserTests
  {
    [Fact]
    public void Test_RepositoryGet()
    {
      var sut = new UserRepository();
      var actual = sut.Get();

      Assert.True(actual != null);
      Assert.True(actual.Count >= 0);
    }

    [Theory]
    [InlineData("BiancaVisconti", "12345")]
    public void Test_RepositoryCheckIfAccountExists(string n, string p)
    {
      var sut = new UserRepository();
      var actual = sut.CheckIfAccountExists(n, p);

      Assert.True(actual);
    }

    [Theory]
    [InlineData("BiancaVisconti", "12345")]
    public void Test_RepositoryGetIdByNamePassword(string n, string p)
    {
      var sut = new UserRepository();
      var actual = sut.GetId(n, p);

      Assert.IsType<long>(actual);
    }

    [Theory]
    [InlineData("BiancaVisconti", "12345")]
    public void Test_RepositoryGetUser(string n, string p)
    {
      var sut = new UserRepository();
      var actual = sut.GetUser(n, p);

      Assert.IsType<User>(actual);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void Test_RepositoryGetName(long l)
    {
      var sut = new UserRepository();
      var actual = sut.GetName(l);

      Assert.IsType<string>(actual);
    }
  }
}