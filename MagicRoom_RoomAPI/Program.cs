using MagicHouse_HouseAPI;
using MagicHouse_HouseAPI.Data;
using MagicHouse_HouseAPI.Repository;
using MagicHouse_HouseAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File("Log/HouseLogs.txt", rollingInterval:RollingInterval.Day).CreateLogger();

builder.Host.UseSerilog();
builder.Services.AddScoped<IHouseRepository, HouseRepository>();
builder.Services.AddScoped<IRoomNumberRepository,RoomNumberRepository>();
builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddControllers().AddNewtonsoftJson();//.AddXmlSerializerFormatters();

builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("conns"));
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
