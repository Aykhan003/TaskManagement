namespace Assignment_Functional.Methods;

internal class User
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public User(int id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
}
