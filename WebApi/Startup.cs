using System.IO;
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
using Microsoft.Extensions.Logging;

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
			services.AddMediatR(typeof(Startup));
			
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
