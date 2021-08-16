using AutoMapper;
using GenericApi.Bl.Config;
using GenericApi.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GenericApi.Bl.IoC;
using GenericApi.Model.DataContext;
using GenericApi.Model.IoC;
using GenericApi.Services.IoC;
using System;
using GenericApi.Core.Settings;

namespace GenericApi
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
			
			#region App Settings

			services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));
			services.Configure<FileStoreSettings>(Configuration.GetSection("FileStoreSettings"));

			#endregion

			#region CORS

			services.AddCors(options =>
			{
				options.AddPolicy("MainPolicy",
					  builder =>
					  {
						  builder
								 .AllowAnyHeader()
								 .AllowAnyMethod()
								 .AllowCredentials();

						  //TODO: remove this line for production
						  builder.SetIsOriginAllowed(x => true);
					  });
			});

			#endregion

			#region External Dependencies

			services.ConfigSqlServerDbContext(Configuration.GetConnectionString("DefaultConnection"));
            services.AddControllers(options => options.EnableEndpointRouting = false)
                .AddNewtonsoftJson();
            services.AddControllers(options => options.EnableEndpointRouting = false).ConfigFluentValidation();
			services.configAutoMapper();
			services.ConfigSerilog();

			#endregion

			#region Api Libraries

			services.ConfigJwtAuth(Configuration);
			services.AddSwagger();
			services.AddAppOData();

			#endregion

			#region App Registries

			services.AddModelRegistry();
			services.AddBlRegistry();
			services.AddServiceRegistry();

			#endregion

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, WorkShopDbContext context)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseAppSwagger();

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseCors("MainPolicy");

			app.UseMvc(routeBuilder => routeBuilder.UseAppOData());
		}
	}
}
