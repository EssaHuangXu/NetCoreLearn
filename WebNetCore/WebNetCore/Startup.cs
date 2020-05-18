using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebNetCore.Models;
using WebNetCore.Services;

namespace WebNetCore
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddScoped<IRepository<Student>, InMemoryRepository>();
			services.AddSingleton<IWelcomeService, WelComeService>();
			services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env,IConfiguration configuration,
			IWelcomeService welcomeService, ILogger<Startup> logger)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.Use((next) =>
			{
				logger.LogInformation("App Use");
				return async httpContext =>
				{
					logger.LogInformation(" -----async HttpContext------");
					if (httpContext.Request.Path.StartsWithSegments("/first"))
					{
						logger.LogInformation(" -----async First------");
						await httpContext.Response.WriteAsync("First!");
					}
					else
					{
						logger.LogInformation(" -----async Others------");
						await next(httpContext);
					}
				};
			});
			//app.UseWelcomePage(new WelcomePageOptions()
			//{
			//	 Path = "/Welcome"
			//});
			app.UseStaticFiles();
			//启动默认的路由 例如：网站根路径 =》 HomeController/Index
			app.UseMvc(builder =>
			{
				// 约定路由
				builder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
				// 标签路由 在Controller中配置

			});

			app.Run(async (context) =>
			{
				//throw new Exception("No Exception");
				var message = welcomeService.GetMessage();
				await context.Response.WriteAsync(message);
			});
		}
	}
}
