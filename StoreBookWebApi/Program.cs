using AuthCommon;
using BusinessObjects;
using DataManagers;
using DataManagers.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProcessManager;
using ProcessManager.Interface;
using ServiceFactory;
using StoreBookWebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var authOptions = builder.Configuration.GetSection("Auth").Get<AuthOptions>();
var connectionString = builder.Configuration.GetConnectionString("PostgreConnetction");

builder.Services.AddControllers();
builder.Services.AddCors(setup =>
               setup.AddPolicy("AllowAll", builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAutoMapper(typeof(StoreBookWebApiMapper));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthorization();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        // ????????, ????? ?? ?????????????? ???????? ??? ????????? ??????
        ValidateIssuer = true,
        // ??????, ?????????????? ????????
        ValidIssuer = authOptions.Issuer,
        // ????? ?? ?????????????? ??????????? ??????
        ValidateAudience = true,
        // ????????? ??????????? ??????
        ValidAudience = authOptions.Audience,
        // ????? ?? ?????????????? ????? ?????????????
        ValidateLifetime = true,
        // ????????? ????? ????????????
        IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),
        // ????????? ????? ????????????
        ValidateIssuerSigningKey = true,
    };

});
builder.Services.AddProcessManagers();
builder.Services.AddDataManagers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StoreDBContext>(options=>options.UseNpgsql(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseCors("AllowAll");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
