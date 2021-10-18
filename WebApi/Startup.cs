using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using MerchandisingManagement.Application.Common.Mappers;
using MerchandisingManagement.Domain.Repositories;
using MerchandisingManagement.Infrastructure.Data;
using MerchandisingManagement.Infrastructure.Repository;
using MerchandisingManagement.Infrastructure.Repository.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatR;
using MerchandisingManagement.Application.Product.Commands;
using MerchandisingManagement.Application.Product.Queries.GetProducts;
using MerchandisingManagement.Application.Product.Queries.GetProductsByStockRange;
using MerchandisingManagement.Application.Product.Queries.SearchProducts;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore;

namespace MerchandisingManagement.WebApi
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddDbContext<MerchandisingManagementContext>(options =>
				options.UseSqlServer(
					Configuration.GetConnectionString("MerchandisingManagementDB")), ServiceLifetime.Singleton);
			
			#region MediatR
			services.AddMediatR(typeof(Startup));
			services.AddMediatR(typeof(CreateProductCommand).GetTypeInfo().Assembly);
			services.AddMediatR(typeof(UpdateProductCommand).GetTypeInfo().Assembly);
			services.AddMediatR(typeof(DeleteProductCommand).GetTypeInfo().Assembly);
			services.AddMediatR(typeof(SearchProductsQuery).GetTypeInfo().Assembly);
			services.AddMediatR(typeof(GetProductsByStockRangeQuery).GetTypeInfo().Assembly);
			services.AddMediatR(typeof(GetProductsQuery).GetTypeInfo().Assembly); 
			#endregion
			#region AutoMapper Configuration
			var mapperConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new MapperConfig());

			});

			var mapper = mapperConfig.CreateMapper();
			services.AddSingleton(mapper);
			#endregion
			#region Dependencies
			services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
			services.AddTransient<IProductRepository, ProductRepository>();
			#endregion

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Version = "v1",
					Title = "ToDo API",
					Description = "A simple example ASP.NET Core Web API",
					TermsOfService = new Uri("https://example.com/terms"),
					Contact = new OpenApiContact
					{
						Name = "Shayne Boyer",
						Email = string.Empty,
						Url = new Uri("https://twitter.com/spboyer"),
					},
					License = new OpenApiLicense
					{
						Name = "Use under LICX",
						Url = new Uri("https://example.com/license"),
					}
				});
			});

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetRequiredService<MerchandisingManagementContext>();
				context.Database.EnsureCreated();
			}

			// Enable middleware to serve generated Swagger as a JSON endpoint.
			app.UseSwagger();

			// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.)
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
				//c.RoutePrefix = string.Empty;
			});

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
