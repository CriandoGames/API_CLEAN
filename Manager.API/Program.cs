using Manager.API.ConfiguraService;
using Manager.API.ViewModels;
using Manager.Domain.Entities;
using Manager.Infra.Context;
using Manager.Infra.Interfaces;
using Manager.Infra.Repositories;
using Manager.Services.DTO;
using Manager.Services.Interfaces;
using Manager.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//inject dependencies


builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region DI
builder.Services.AddEntityFrameworkNpgsql()
 .AddDbContext<ManagerContext>(options =>
 options.UseNpgsql(builder.Configuration.GetConnectionString("Local")));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
#endregion


#region AutoMapper

var autoMapperConfig = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.CreateMap<UserCreateDTO, User>().ReverseMap();
    cfg.CreateMap<UserOutputDTO, User>().ReverseMap();
    cfg.CreateMap<CreateUserViewModel, UserCreateDTO>().ReverseMap();

});

builder.Services.AddSingleton(autoMapperConfig.CreateMapper());

#endregion

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
