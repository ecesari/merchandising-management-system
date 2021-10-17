using MerchandisingManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MerchandisingManagement.Infrastructure.Data
{
	public class MerchandisingManagementContext : DbContext
	{
		public MerchandisingManagementContext(DbContextOptions<MerchandisingManagementContext> options) : base(options) { }
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
	
	}
}
