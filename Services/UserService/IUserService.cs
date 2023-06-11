using Small_API.Models;

namespace Small_API.Services.UserService
{
    public interface IUserService
    {
        Task<User> LogIn(string username, string password);
    }
}
