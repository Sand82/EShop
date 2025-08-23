var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

//Configure 5the HTTP request pipeline.

app.Run();
 