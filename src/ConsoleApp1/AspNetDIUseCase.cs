using System;
using Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Performance
{
	[System.ComponentModel.Description("AspNetDI")]
	public class AspNetDIUseCase : UseCase
	{
        static IServiceProvider container;
		static AspNetDIUseCase()
		{
			var services = new ServiceCollection();
			services.AddTransient<IWebService, WebService>()
					.AddTransient<IAuthenticator, Authenticator>()
					.AddTransient<IStockQuote, StockQuote>()
					.AddTransient<IDatabase, Database>()
					.AddTransient<IErrorHandler, ErrorHandler>()
					.AddSingleton<ILogger, Logger>();

            container = services.BuildServiceProvider();

		}

		public override void Run()
		{
			var webApp = container.GetRequiredService<IWebService>();
			webApp.Execute();
		}
	}
}
