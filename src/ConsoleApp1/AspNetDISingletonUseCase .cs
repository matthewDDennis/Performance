using System;
using Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Performance
{
	[System.ComponentModel.Description("AspNetDISingletonUseCase ")]
	public class AspNetDISingletonUseCase : UseCase
	{
        static IServiceProvider container;
		static AspNetDISingletonUseCase()
		{
			var services = new ServiceCollection();
			services.AddSingleton<IWebService, WebService>()
					.AddSingleton<IAuthenticator, Authenticator>()
					.AddSingleton<IStockQuote, StockQuote>()
					.AddSingleton<IDatabase, Database>()
					.AddSingleton<IErrorHandler, ErrorHandler>()
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
