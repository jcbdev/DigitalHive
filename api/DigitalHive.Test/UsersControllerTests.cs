using NUnit.Framework;
using DigitalHive.Api.Controllers;
using DigitalHive.Api.Data;
using Moq;
using DigitalHive.Api.Data.Models;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using DigitalHive.Api.Data.Models.DAO;

namespace DigitalHive.Test
{
  

  public class UsersControllerTests
  {
    public static HttpStatusCode GetHttpStatusCode(IActionResult functionResult)
    {
        try
        {
            return (HttpStatusCode)functionResult
                .GetType()
                .GetProperty("StatusCode")
                .GetValue(functionResult, null);
        }
        catch
        {
            return HttpStatusCode.ExpectationFailed;
        }
    } 

    public static T GetValue<T>(IActionResult functionResult)
    {
        try
        {
            return (T)functionResult
                .GetType()
                .GetProperty("Value")
                .GetValue(functionResult, null);
        }
        catch
        {
            return default(T);
        }
    } 

    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void should_authenticate()
    {
      var userServiceMock = new Mock<IUserService>();
      userServiceMock.Setup(usm => usm.Authenticate(It.IsAny<AuthenticateRequest>())).Returns(new AuthenticateResponse(new User{
        ID = 1,
        Password = "somethingsomething",
        Role = "TestROle",
        Username = "testuser"
      }, "TOKENTOEKN"));

      var userController = new UsersController(userServiceMock.Object);
      var result = userController.Authenticate(new AuthenticateRequest() {
        username = "testuser",
        password = "somethingsomething"
      });
      Assert.That(GetHttpStatusCode(result), Is.EqualTo(HttpStatusCode.OK));
      Assert.That(GetValue<AuthenticateResponse>(result).Id, Is.EqualTo(1));
    }

    [Test]
    public void should_register_user()
    {
      var userServiceMock = new Mock<IUserService>();
      userServiceMock.Setup(usm => usm.Register(It.IsAny<RegisterRequest>())).Returns(new RegisterResponse(new User{
        ID = 1,
        Password = "somethingsomething",
        Role = "testR0le",
        Username = "testuser"
      }));

      var userController = new UsersController(userServiceMock.Object);
      var result = userController.RegisterUser(new RegisterRequest() {
        username = "testuser",
        password = "somethingsomething",
        role = "testR0le"
      });
      Assert.That(GetHttpStatusCode(result), Is.EqualTo(HttpStatusCode.OK));
      Assert.That(GetValue<RegisterResponse>(result).Id, Is.EqualTo(1));
    }
  }
}