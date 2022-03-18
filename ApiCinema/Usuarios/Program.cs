using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Usuarios.Data;
using Usuarios;
using Usuarios.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<UserDbContext>(opts => opts.UseNpgsql(builder.Configuration.GetConnectionString("UserConnection")), ServiceLifetime.Transient);
builder.Services.AddIdentity<CustomIdentityUser, IdentityRole<int>>(
       opts => opts.SignIn.RequireConfirmedEmail = true
       ).AddEntityFrameworkStores<UserDbContext>().AddDefaultTokenProviders();
builder.Services.AddScoped<EmailService, EmailService>();
builder.Services.AddScoped<CadastroService, CadastroService>();
builder.Services.AddScoped<TokenService, TokenService>();
builder.Services.AddScoped<LoginService, LoginService>();
builder.Services.AddScoped<LogoutService, LogoutService>();

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
