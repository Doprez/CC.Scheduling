using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using ServiceManager.Persistance.Data;

var builder = WebApplication.CreateBuilder(args);
Env.Load();
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


/*builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ServiceDbContext>(options =>
{
	options.UseNpgsql(Environment.GetEnvironmentVariable("DatabaseConnection"));
});*/

builder.Services.AddDbContext<ServiceDbContext>(options =>
{
	options.UseNpgsql(Environment.GetEnvironmentVariable("DatabaseConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetService<ServiceDbContext>();
	context.Database.EnsureCreated();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
