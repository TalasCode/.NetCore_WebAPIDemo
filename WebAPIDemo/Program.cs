using Microsoft.EntityFrameworkCore;
using WebAPIDemo.Core.Models;
using WebAPIDemo.Core.Repositories;
using WebAPIDemo.Core.Repositories.IRepositories;
using WebAPIDemo.Services.Services;
using WebAPIDemo.Services.Services.IServices;
using System.Text.Json.Serialization; // Add this using directive

var builder = WebApplication.CreateBuilder(args);

var dataAssemblyName = typeof(DatabaseServerContext).Assembly.GetName().Name;
builder.Services.AddDbContext<DatabaseServerContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve; // Configure JSON options to handle circular references
    });

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IRoleService, RoleService>();
builder.Services.AddTransient<IEventGuidesService, EventGuidesService>();
builder.Services.AddTransient<IEventService, EventService>();
builder.Services.AddTransient<IEventMembersService, EventMembersService>();
builder.Services.AddTransient<IMemberService, MemberService>();

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
