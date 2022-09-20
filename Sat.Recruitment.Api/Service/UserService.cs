using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Sat.Recruitment.Api.Contract.Request;
using Sat.Recruitment.Api.Contract.Response;
using Sat.Recruitment.Api.Helper;

namespace Sat.Recruitment.Api.Service
{
    public class UserService : IUserService
    {
        public Result CreateUser(UserRequest request)
        {
            var result = new Result
            {
                Errors = ValidateRequest(request)
            };

            if (result.Errors.Any())
            {
                return result;
            }

            result = ValidateExistingUser(request);
            if (result.Errors.Any() && !result.IsSuccess)
            {
                return result;
            }

            var newUser = new UserResponse
            {
                Name = request.Name,
                Email = EmailHelper.NormalizeEmail(request.Email),
                Address = request.Address,
                Phone = request.Phone,
                UserType = request.UserType,
                Money = MoneyHelper.MoneyFromUserType(request)
            };

            result.User = newUser;
            return result;
        }

        private static List<string> ValidateRequest(UserRequest request)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(request.Name))
            {
                errors.Add("Name can't be null or empty");
            }

            if (string.IsNullOrEmpty(request.Email))
            {
                errors.Add("Email can't be null or empty");
            }

            if (string.IsNullOrEmpty(request.Address))
            {
                errors.Add("Address can't be null or empty");
            }

            if (string.IsNullOrEmpty(request.Phone))
            {
                errors.Add("Phone can't be null or empty");
            }

            return errors;
        }

        private static Result ValidateExistingUser(UserRequest request)
        {
            List<UserResponse> usersFromFile;
            var errorsList = new List<string>();
            var isSuccess = true;

            try
            {
                var reader = UserFileHelper.ReadUsersFromFile();
                usersFromFile = UserFileHelper.TransformUsersFromFile(reader);
            }
            catch
            {
                throw new Exception("Error reading the file");
            }

            var existingUser = usersFromFile.FirstOrDefault(u => u.Name == request.Name && u.Email == request.Email);
            if (existingUser != null)
            {
                isSuccess = false;
                errorsList.Add("User already exists, cannot be created");
                Debug.WriteLine("User already exists, cannot be created");
            }
            
            return new Result
            {
                IsSuccess = isSuccess,
                Errors = errorsList
            };
        }
    }
}
