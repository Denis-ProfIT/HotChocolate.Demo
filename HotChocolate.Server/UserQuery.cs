namespace HotChocolate.Server;

public class UserQuery
{
    [UseFiltering]
    public IQueryable<User> GetUsers()
    {
        return new List<User>
        {
            new() { Name = "UserWithAddress", Address = "Address" },
            new() { Name = "UserWithoutAddress", Address = null }
        }.AsQueryable();
    }
}