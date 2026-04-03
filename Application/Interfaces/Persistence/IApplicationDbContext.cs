using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces.Persistence;

public interface IApplicationDbContext
{
	DbSet<Todo> Todos { get; }

	Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
