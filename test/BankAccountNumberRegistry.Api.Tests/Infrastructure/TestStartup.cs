namespace BankAccountNumberRegistry.Api.Tests.Infrastructure
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Api.Infrastructure;
    using Api.Infrastructure.Configuration;
    using Autofac;
    using Autofac.Extensions.DependencyInjection;
    using Be.Vlaanderen.Basisregisters.Api;
    using Be.Vlaanderen.Basisregisters.Api.Exceptions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Swashbuckle.AspNetCore.Swagger;

    public class TestStartup
    {
        private IContainer _applicationContainer;

        private readonly IConfiguration _configuration;

        public TestStartup(
            IConfiguration configuration) =>
            _configuration = configuration;

        /// <summary>Configures services for the application.</summary>
        /// <param name="services">The collection of services to configure the application with.</param>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services
                .ConfigureDefaultForApi<Startup>(
                    (provider, description) => new Info
                    {
                        Version = description.ApiVersion.ToString(),
                        Title = "Bank Account Number Registry API",
                        Description = GetApiLeadingText(description),
                        Contact = new Contact
                        {
                            Name = "Informatie Vlaanderen",
                            Email = "informatie.vlaanderen@vlaanderen.be",
                            Url = "https://legacy.basisregisters.vlaanderen"
                        }
                    },
                    new[]
                    {
                        typeof(Startup).GetTypeInfo().Assembly.GetName().Name,
                    },
                    _configuration.GetSection("Cors").GetChildren().Select(c => c.Value).ToArray());

            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);
            _applicationContainer = containerBuilder.Build();

            return new AutofacServiceProvider(_applicationContainer);
        }

        public void Configure(
            IServiceProvider serviceProvider,
            IApplicationBuilder app,
            IHostingEnvironment env,
            IApplicationLifetime appLifetime,
            ILoggerFactory loggerFactory,
            IApiVersionDescriptionProvider apiVersionProvider)
        {
            app.UseDefaultForApi(new StartupOptions
            {
                ApplicationContainer = _applicationContainer,
                ServiceProvider = serviceProvider,
                HostingEnvironment = env,
                ApplicationLifetime = appLifetime,
                LoggerFactory = loggerFactory,
                Api =
                {
                    VersionProvider = apiVersionProvider,
                    Info = groupName => $"Basisregisters Vlaanderen - Bank Account Number Registry API {groupName}",
                    CustomExceptionHandlers = new IExceptionHandler[]
                    {
                        new ValidationExceptionHandling(),
                    }
                },
                MiddlewareHooks =
                {
                    AfterMiddleware = x => x.UseMiddleware<AddNoCacheHeadersMiddleware>(),
                },
            });
        }

        private static string GetApiLeadingText(ApiVersionDescription description)
            => $"Momenteel leest u de documentatie voor versie {description.ApiVersion} van de Basisregisters Vlaanderen Bank Account Number Registry API{string.Format(description.IsDeprecated ? ", **deze API versie is niet meer ondersteund * *." : ".")}";
    }
}
