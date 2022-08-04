using API.Models.Github.Responses;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers.Github.Users
{
    public interface IUsersApi
    {
        [Get("/users")]
        Task<List<UserResponse>> Users();

        [Get("/users/{userName}")]
        Task<UserDetailsResponse> GetUserDetails(string userName);
    }
}
