using HotChocolate.Client;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();
serviceCollection.AddGraphQlClient()
    .ConfigureHttpClient(client => client.BaseAddress = new Uri("http://localhost:5039/graphql"));

IServiceProvider services = serviceCollection.BuildServiceProvider();

var client = services.GetRequiredService<GraphQlClient>();

var filter = new UserFilterInput
{
    Address = new StringOperationFilterInput
    {
        Eq = null
    }
};

var result = client.GetUsers.ExecuteAsync(filter);

if (result.Result.Data is not null)
{
    foreach (var user in result.Result.Data.Users)
    {
        Console.WriteLine($"Name: {user.Name}, Address: {user.Address}");
    }
}
else
{
    Console.WriteLine("Data is empty");
}

Console.ReadLine();