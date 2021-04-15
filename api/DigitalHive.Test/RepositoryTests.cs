using NUnit.Framework;
using DigitalHive.Api;
using Microsoft.EntityFrameworkCore;
using DigitalHive.Api.Data;
using DigitalHive.Api.Data.Models;

namespace DigitalHive.Test
{
  public class RepositoryTests
  {
    private DbContextOptions<DigitalHiveContext> _options;

    [SetUp]
    public void Setup()
    {
      _options = new DbContextOptionsBuilder<DigitalHiveContext>()
        .UseInMemoryDatabase(databaseName: "MovieListDatabase")
        .Options;
    }

    [Test]
    public void should_register_user()
    {
      using (var context = new DigitalHiveContext(_options))
      {
        var repository = new Respository(context);

        User user = new User() {
          Username = "testuser",
          Password = "1234",
          Role = "Manager"
        };

        var result = repository.RegisterUser(user);

        Assert.That(result.ID != 0, "Expected a new ID to be returned for user");
      }
    }

    [Test]
    public void should_retrieve_existing_user() {
      User savedUser;
      using (var context = new DigitalHiveContext(_options))
      {
        var repository = new Respository(context);

        User user = new User() {
          Username = "existinguser",
          Password = "1234",
          Role = "Manager"
        };

        savedUser = repository.RegisterUser(user);

      }

      using (var context = new DigitalHiveContext(_options))
      {
        var repository = new Respository(context);
        var result = repository.GetUser("existinguser");
        Assert.AreEqual(result.ID, savedUser.ID, "Users do not match as expected");
      }
    }
  }
}