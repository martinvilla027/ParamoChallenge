using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api.Contract.Request;
using Sat.Recruitment.Api.Contract.Response;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Api.Service;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UsersControllerTest
    {
        [Fact]
        public void UserCreatedSuccessfully()
        {
            //Arrange
            var userController = new UsersController(new UserService());
            var userRequest = new UserRequest
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = "124"
            };

            //Act
            var result = userController.CreateUser(userRequest) as ObjectResult;

            //Assert
            Assert.Equal(201, result!.StatusCode);
            Assert.Equal(typeof(UserResponse), result!.Value.GetType());
        }

        [Fact]
        public void UserAlreadyExist()
        {
            //Arrange
            var userController = new UsersController(new UserService());
            var userRequest = new UserRequest
            {
                Name = "Agustina",
                Email = "Agustina@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = "124"
            };

            //Act
            var result = userController.CreateUser(userRequest) as ObjectResult;

            //Assert
            Assert.Equal(400, result!.StatusCode);
            Assert.NotNull(result.Value);
        }
    }
}