using System.Collections.Generic;

namespace PizzaBox.Domain.Interfaces
{
  public interface IUser
  {
    //List<Order> ViewOrdersHistory(long UserId);

    bool HasItBeen24Hours(long userId);

    bool HasItBeen2Hours(long userId);
  }
}