using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchandisingManagement.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace MerchandisingManagement.Infrastructure.Data
{
	public class MerchandisingManagementContextSeed
	{
		public static async Task SeedAsync(MerchandisingManagementContext context, ILoggerFactory loggerFactory, int? retry = 0)
		{
			var retryForAvailability = retry.Value;

			try
			{
				context.Database.EnsureCreated();

				if (!context.Categories.Any())
				{
					context.Categories.AddRange(SeedCategories());
					await context.SaveChangesAsync();
				}

				if (!context.Products.Any())
				{
					context.Products.AddRange(SeedProducts());
					await context.SaveChangesAsync();
				}
			}
			catch (Exception exception)
			{
				if (retryForAvailability < 10)
				{
					retryForAvailability++;
					var log = loggerFactory.CreateLogger<MerchandisingManagementContextSeed>();
					log.LogError(exception.Message);
					await SeedAsync(context, loggerFactory, retryForAvailability);
				}
				throw;
			}
		}

		private static IEnumerable<Category> SeedCategories()
		{
			return new List<Category>()
			{
				new Category() { Name = "Apparel",MinimumStockQuantity = 20},
				new Category() { Name = "Electronics",MinimumStockQuantity = 5},
			};
		}

		private static IEnumerable<Product> SeedProducts()
		{
			return new List<Product>()
			{
				new Product() { Title = "Sweater", CategoryId = 1 , StockQuantity = 30,Description = "Sweater for cold weathers"},
				new Product() { Title = "Socks", CategoryId = 1 , StockQuantity = 30,Description = "Socks!"},
				new Product() { Title = "AirPods", CategoryId = 2 , StockQuantity = 10,Description = "Bluetooth headphones"},
				new Product() { Title = "Gaming Keyboard", CategoryId = 2 , StockQuantity = 0,Description = "Keyboard designed for gamers"},

			};
		}

	}
}
