using BuisnessObjects;
using DataManagers;
using DataManagers.Interface;
using ProcessManager;
using ProcessManager.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IRepository,Repository>();
builder.Services.AddScoped<IEmployeeProcessManager, EmployeeProcessManager>();
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
