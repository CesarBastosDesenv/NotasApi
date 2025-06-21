using Nota.application.Interfaces;
using Nota.application.Services;
using Nota.Infra.Data.Context;
using Nota.Infra.Data.Interfaces;
using Nota.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});
;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("ApiConnection");

builder.Services.AddDbContext<ApiContext>(Options => {
                      Options.UseSqlServer(connectionString, dbOpts => dbOpts.MigrationsAssembly(typeof(Program).Assembly.FullName));
                   });

builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();      
builder.Services.AddScoped<ITarefaService, TarefaService>();

builder.Services.AddCors(
    options => {
        options.AddPolicy("cors",builder => {
            builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
    }
);

var app = builder.Build();

app.UseCors("cors");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers().AllowAnonymous();;

app.Run();
