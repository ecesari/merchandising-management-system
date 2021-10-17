using System.Threading;
using System.Threading.Tasks;
using MerchandisingManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MerchandisingManagement.Application.Common.Interfaces
{
	public interface IMerchandisingDbContext
	{
		DbSet<Category> Categories { get; set; }

		DbSet<Domain.Entities.Product> Products { get; set; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
