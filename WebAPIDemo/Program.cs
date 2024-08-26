using Microsoft.EntityFrameworkCore;
using WebAPIDemo.Core.Models;
using WebAPIDemo.Core.Repositories;
using WebAPIDemo.Core.Repositories.IRepositories;
using WebAPIDemo.Services.Services;
using WebAPIDemo.Services.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

var dataAssemblyName = typeof(DatabaseServerContext).Assembly.GetName().Name;
builder.Services.AddDbContext<DatabaseServerContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IRoleService, RoleService>();
builder.Services.AddTransient<IEventGuidesService, EventGuidesService>();
builder.Services.AddTransient<IEventService, EventService>();
builder.Services.AddTransient<IEventMembersService, EventMembersService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);


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
