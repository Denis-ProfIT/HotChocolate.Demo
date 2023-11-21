using HotChocolate.Server;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGraphQLServer()
    .AddFiltering()
    .AddQueryType<UserQuery>()
    .AddDiagnosticEventListener<MyExecutionEventListener>();

var app = builder.Build();
app.MapGraphQL();

app.Run();