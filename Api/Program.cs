using Application.Interfaces.Persistence;
using FluentValidation;
using Infrastructure.Presistance;
using Microsoft.EntityFrameworkCore;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDbContext>(op => op.UseSqlite("Data Source=app.db"));

builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

builder.Services.AddMediatR(opt => opt.RegisterServicesFromAssembly(typeof(Application.IAssemblyMarker).Assembly));

builder.Services
	.AddFluentValidationAutoValidation()
	.AddValidatorsFromAssembly(typeof(Application.IAssemblyMarker).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();