using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyRoadMap.Domain.Model;
using MyRoadMap.Domain.Repositories;
using MyRoadMap.Domain.Services;
using MyRoadMap.Domain.Services.Base;
using MyRoadMap.Domain.Services.Interfaces;
using MyRoadMap.Domain.Validators.Base;
using MyRoadMap.Infrastructure;
using MyRoadMap.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var appSettings = builder.Configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();

builder.Services.AddDbContext<MyRoadMapContext>(options => options
    .UseNpgsql(appSettings.ConnectionString)
    .UseSnakeCaseNamingConvention());

builder.Services.AddScoped(typeof(Validator<>));
builder.Services.AddScoped<IRoadMapService, RoadMapService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(IQueryService<>), typeof(QueryService<>));
builder.Services.AddScoped(typeof(ICrudService<>), typeof(CrudService<>));

builder.Services.AddControllers();

builder.Services.Configure<ApiBehaviorOptions>(opt =>
{
    opt.SuppressModelStateInvalidFilter = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
