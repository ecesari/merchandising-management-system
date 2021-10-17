using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
	public interface IMerchandisingDbContext
	{
		DbSet<Category> Categories { get; set; }

		DbSet<Domain.Entities.Product> Products { get; set; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
