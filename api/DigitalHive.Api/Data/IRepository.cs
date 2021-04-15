using DigitalHive.Api.Data.Models;

namespace DigitalHive.Api.Data {
  public interface IRepository {
    public void CreateUser(User user);
  }
}