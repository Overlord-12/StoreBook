using BuisnessObjects;
using DataManagers;
using DataManagers.Interface;
using ProcessManager;
using ProcessManager.Interface;
using ServiceFactory;
using StoreBookWebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAutoMapper(typeof(StoreBookWebApiMapper));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddProcessManagers();
builder.Services.AddDataManagers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StoreDBContext>();

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
