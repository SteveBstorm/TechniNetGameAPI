//using DemoASPMVC_DAL.Interface;
//using DemoASPMVC_DAL.Services;
using GameDAL_EF.Interface;
using GameDAL_EF.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Data.SqlClient;
using System.Text;
using TechniNetGameAPI.Hubs;
using TechniNetGameAPI.Tools;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddTransient(sp => new SqlConnection(builder.Configuration.GetConnectionString("default")));

//Serices ADO
//builder.Services.AddScoped<IGameService, GameDBService>();
//builder.Services.AddScoped<IGenreService, GenreService>();
//builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IGenreService, GenreService>();

builder.Services.AddScoped<TokenManager>();

builder.Services.AddSingleton<ChatHub>();

//Ajout de la sécurité par JWT
//Création des role

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", o => o.RequireRole("Admin"));
    options.AddPolicy("ModoPolicy", o => o.RequireRole("Admin", "Modo"));

    options.AddPolicy("IsConnected", o => o.RequireAuthenticatedUser());
});

// Expliquer à l'api comment valider le token
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
        options => options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateLifetime = true,
            ValidateIssuer = true,
            ValidIssuer = "monserverapi.com",
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(TokenManager._secretKey)),
            ValidateAudience = false
        }
        
    );

builder.Services.AddCors(o => o.AddPolicy("myPolicy", options => 
    options.WithOrigins("http://localhost:4200")
    .AllowAnyMethod().AllowAnyHeader().AllowCredentials()));

builder.Services.AddCors(o => o.AddPolicy("AndroidPolicy", options =>
    options.WithOrigins("http://machin.com")
    .WithMethods("GET").AllowAnyHeader().AllowCredentials()));

builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//Cors Wildcard
//app.UseCors(o => o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()) ;

app.UseCors("myPolicy");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapHub<ChatHub>("chathub");

app.MapControllers();

app.Run();
