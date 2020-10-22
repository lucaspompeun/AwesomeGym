using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwesomeGym.API.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace AwesomeGym.API
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
			services.AddSwaggerGen(c =>
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "AwesomeGym API", Version = "v1" })
			);

			var connectionString = Configuration.GetConnectionString("AwesomeGymCn");

			//Caso queira utilizar banco de dados em mem�ria, basta usar:
			//services.AddDbContext<AwesomeGymDbContext>(options =>
			//	options.UseInMemoryDatabase("AwesomeGymCn"));

			services.AddDbContext<AwesomeGymDbContext>(options =>
				options.UseSqlServer(connectionString));
			
			services.AddControllers();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "AwesomeGym API");
			});

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
