using AuthCommon;
using BusinessObjects;
using ServiceFactory;
using StoreBookWebApi;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var authOptions = builder.Configuration.GetSection("Auth");
var connectionString = builder.Configuration.GetConnectionString("PostgreConnetction");

builder.Services.Configure<AuthOptions>(authOptions);
builder.Services.AddCors(setup =>
               setup.AddPolicy("AllowAll", builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDataManagers();
builder.Services.AddProcessManagers();
builder.Services.AddAutoMapper(typeof(AuthMapper));
builder.Services.AddDbContext<StoreDBContext>(options => options.UseNpgsql(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();

app.UseCors("AllowAll");

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
