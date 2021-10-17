using Domain.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Infrastructure.Data;
using Infrastructure.Repository;
using Infrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace WebApi
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

			//services.AddSwaggerGen(c => {
			//	c.SwaggerDoc("v1", new OpenApiInfo
			//	{
			//		Title = "Employee.API",
			//		Version = "v1"
			//	});
			//});
			#region AutoMapper Configuration
			//var mapperConfig = new MapperConfiguration(mc =>
			//{
			//	mc.AddProfile(new MapperConfig());

			//});

			//var mapper = mapperConfig.CreateMapper();
			//services.AddSingleton(mapper);
			#endregion
			//services.AddMediatR(typeof(CreateEmployeeHandler).GetTypeInfo().Assembly);
			services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
			services.AddTransient<IProductRepository, ProductRepository>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
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
