using Assignment_Functional.Services;

namespace Assignment_Functional.Methods;

internal class UserService : IUserService
{
    private static List<User> _users = new List<User>();
    public static User GetUserById(int userId)
    {
        var user = _users.FirstOrDefault(u => u.Id == userId);
        if (user == null)
        {
            throw new NotFoundException("User not found.");
        }
        return user;
    }
    public void AddUser(User user)
    {
        if (_users.Any(u => u.Email == user.Email))
        {
            throw new ConflictException("User with this email already exists");
        }
        _users.Add(user);
    }
    public User GetUserByEmail(string email)
    {
        return _users.FirstOrDefault(u => u.Email == email) ?? throw new NotFoundException("User not found");
    }
}
