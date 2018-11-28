using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PageModelTest
{

	public class Startup
	{
		private IConfiguration configuration;

		public Startup(IConfiguration config)
		{
			configuration = config;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc()
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
			services.AddHttpClient<Pages.FeedbackClient>(client => client.BaseAddress = new Uri(configuration["feedbacksEndpoint"]));

		}

		public void Configure(IApplicationBuilder app)
		{
			app.UseMvc();
		}
	}
}

