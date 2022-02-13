using BuisnessObjects;
using DataManagers;
using DataManagers.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.IdentityModel.Tokens;
using ProcessManager;
using ProcessManager.Interface;
using ServiceFactory;
using StoreBookWebApi;
using StoreBookWebApi.Token;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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
        // ��������, ����� �� �������������� �������� ��� ��������� ������
        ValidateIssuer = true,
        // ������, �������������� ��������
        ValidIssuer = AuthOptions.ISSUER,
        // ����� �� �������������� ����������� ������
        ValidateAudience = true,
        // ��������� ����������� ������
        ValidAudience = AuthOptions.AUDIENCE,
        // ����� �� �������������� ����� �������������
        ValidateLifetime = true,
        // ��������� ����� ������������
        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
        // ��������� ����� ������������
        ValidateIssuerSigningKey = true,
    };

});
builder.Services.AddProcessManagers();
builder.Services.AddDataManagers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StoreDBContext>();

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
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllers();

app.Run();
