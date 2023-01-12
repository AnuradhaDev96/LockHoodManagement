using Microsoft.EntityFrameworkCore;
using MSS_API.Data;
using MSS_API.Interfaces;
using MSS_API.Repository;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//add cors
builder.Services.AddCors(options => 
{
options.AddDefaultPolicy( builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); 

// Add mapping profile
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add dependency injections
builder.Services.AddScoped<IWorkshopRepository, WorkshopRepository>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<IHumanResourceRepository, HumanResourceRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
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

app.UseCors(builder => 
{
    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
});

app.MapControllers();

app.Run();
