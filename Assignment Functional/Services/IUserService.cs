using Assignment_Functional.Methods;

namespace Assignment_Functional.Services;

internal interface IUserService
{
    public void AddUser(User user);
    public User GetUserByEmail(string email);
}
