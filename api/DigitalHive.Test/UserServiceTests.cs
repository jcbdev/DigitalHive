using NUnit.Framework;
using DigitalHive.Api.Controllers;
using DigitalHive.Api.Data;
using Moq;
using Microsoft.Extensions.Options;
using DigitalHive.Api.Helpers;
using DigitalHive.Api.Data.Models.DAO;
using System.Linq;
using DigitalHive.Api.Data.Models;

namespace DigitalHive.Test
{
  public class UsersServiceTests
  {

    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void should_authenticate_user()
    {
      var options = Options.Create<AppSettings>(new AppSettings()
      {
        Secret = "BLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAH"
      });
      var repositoryMock = new Mock<IRepository>();
      repositoryMock.Setup(r => r.GetUser("testuser")).Returns(new User()
      {
        ID = 1,
        Password = "TestPassword",
        Role = "Manager",
        Username = "testuser"
      });
      var _userService = new UserService(options, repositoryMock.Object);
      var result = _userService.Authenticate(new AuthenticateRequest()
      {
        Username = "testuser",
        Password = "TestPassword"
      });
      Assert.That(result, Is.Not.Null);
      Assert.That(result.Id, Is.EqualTo(1));
      Assert.That(result.Username, Is.EqualTo("testuser"));
      Assert.That(result.Token, Is.Not.Null);
    }

    [Test]
    public void should_not_authenticate_user_with_bad_password()
    {
      var options = Options.Create<AppSettings>(new AppSettings()
      {
        Secret = "BLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAH"
      });
      var repositoryMock = new Mock<IRepository>();
      repositoryMock.Setup(r => r.GetUser("testuser")).Returns(new User()
      {
        ID = 1,
        Password = "TestPassword",
        Role = "Manager",
        Username = "testuser"
      });
      var _userService = new UserService(options, repositoryMock.Object);
      var result = _userService.Authenticate(new AuthenticateRequest()
      {
        Username = "testuser",
        Password = "BadPassword"
      });
      Assert.That(result, Is.Null);
    }

    [Test]
    public void should_list_users()
    {
      var options = Options.Create<AppSettings>(new AppSettings()
      {
        Secret = "BLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAH"
      });
      var repositoryMock = new Mock<IRepository>();
      var users = new [] {
        new User()
        {
          ID = 1,
          Password = "TestPassword",
          Role = "Manager",
          Username = "testuser"
        },
        new User()
        {
          ID = 2,
          Password = "TestPassword2",
          Role = "Manager",
          Username = "testuser2"
        },
      };

      repositoryMock.Setup(r => r.ListUsers()).Returns(users);
      var _userService = new UserService(options, repositoryMock.Object);
      var result = _userService.GetAll();
      Assert.That(result.Count(), Is.Not.Null);
    }

    [Test]
    public void should_get_user_by_id()
    {
      var options = Options.Create<AppSettings>(new AppSettings()
      {
        Secret = "BLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAH"
      });
      var repositoryMock = new Mock<IRepository>();
      var users = new [] {
        new User()
        {
          ID = 1,
          Password = "TestPassword",
          Role = "Manager",
          Username = "testuser"
        },
        new User()
        {
          ID = 2,
          Password = "TestPassword2",
          Role = "Manager",
          Username = "testuser2"
        },
      };

      repositoryMock.Setup(r => r.GetUserById(2)).Returns(users[1]);
      var _userService = new UserService(options, repositoryMock.Object);
      var result = _userService.GetById(2);
      Assert.That(result, Is.EqualTo(users[1]));
    }

    [Test]
    public void should_register_new_user()
    {
      var options = Options.Create<AppSettings>(new AppSettings()
      {
        Secret = "BLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAHBLAH"
      });
      var repositoryMock = new Mock<IRepository>();
      repositoryMock.Setup(r => r.RegisterUser(It.IsAny<User>())).Returns(new User() {
        ID = 1,
        Password = "newpassword",
        Username = "newuser",
        Role = "Manager"
      });
      var _userService = new UserService(options, repositoryMock.Object);
      var result = _userService.Register(new RegisterRequest() {
        Username = "newuser",
        Password = "newpassword",
        Role = "Manager",
      });
      Assert.That(result.Id, Is.EqualTo(1));
    }
  }
}