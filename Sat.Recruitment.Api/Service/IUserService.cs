using Sat.Recruitment.Api.Contract.Request;
using Sat.Recruitment.Api.Contract.Response;

namespace Sat.Recruitment.Api.Service
{
    public interface IUserService
    {
        Result CreateUser(UserRequest request);
    }
}
