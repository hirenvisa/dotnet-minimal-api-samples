using Customers.API.Infrastructure;
using Customers.API.Service;
using MapsterMapper;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlite<CustomerDbContext>("Data Source=customerdb");
builder.Services.AddSingleton<IMapper, Mapper>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapControllers();
app.Run();

