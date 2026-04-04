namespace Infrastructure.Presistance;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDbContext
{
	public DbSet<Todo> Todos => Set<Todo>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		var fks = modelBuilder.Model
			.GetEntityTypes()
			.SelectMany(e => e.GetForeignKeys())
			.Where(e => !e.IsOwnership);

		foreach (var fk in fks)
			fk.DeleteBehavior = DeleteBehavior.Restrict;


		modelBuilder.ApplyConfigurationsFromAssembly(typeof(Infrastructure.IAssemblyMarker).Assembly);
	}
}
