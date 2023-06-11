using Small_API.Models;

namespace Small_API.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<User> LogIn(string username, string password)
        {
            var user = await _context.Users.Where((x) => x.Username == username).FirstOrDefaultAsync();

            if (user is null) return null;

            if (user.Password == password) return user;

            return null;
        }
    }
}
