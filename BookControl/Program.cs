using BookControl.Entities;
using BookControl.Repositories;
using BookControl.Services.Implementation;
using BookControl.Services.Interface;
using BookControl.Services.Profiles;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .WriteTo.Console().CreateLogger();
builder.Logging.AddSerilog(logger);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configuring context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
});

//Registering services
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();

builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<BookProfile>();
    config.AddProfile<CustomerProfile>();
    config.AddProfile<OrderProfile>();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
