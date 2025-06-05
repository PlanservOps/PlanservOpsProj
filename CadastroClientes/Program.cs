using CadastroCliente.Context;
using CadastroClientes.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IFormularioService, FormularioService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTudo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();


app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("PermitirTudo");

app.MapControllers();

app.Run();
