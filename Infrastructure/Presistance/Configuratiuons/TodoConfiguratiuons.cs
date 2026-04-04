namespace Infrastructure.Presistance.Configuratiuons;

public class TodoConfiguratiuons : IEntityTypeConfiguration<Todo>
{
	public void Configure(EntityTypeBuilder<Todo> builder)
	{
		builder.Property(t => t.Title)
			.IsRequired()
			.HasMaxLength(200);
	}
}
