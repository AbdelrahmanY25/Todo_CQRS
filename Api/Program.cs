var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddProblemDetails();

builder.Services
	.AddDbContext<ApplicationDbContext>(op => op.UseSqlServer(connectionString));

builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

builder.Services.AddMediatR(configuration => 
{
	configuration.RegisterServicesFromAssembly(typeof(Application.IAssemblyMarker).Assembly);
	configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

builder.Services
	.AddFluentValidationAutoValidation()
	.AddValidatorsFromAssembly(typeof(Application.IAssemblyMarker).Assembly);

builder.Host.UseSerilog((context, configuration) => 
	configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddHealthChecks()
	.AddSqlServer(name: "Database", connectionString: connectionString);

var app = builder.Build();

if (app.Environment.IsDevelopment())
	app.MapOpenApi();

app.UseHttpsRedirection();

app.UseExceptionHandler();

app.UseSerilogRequestLogging();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/health", new HealthCheckOptions
{
	ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();