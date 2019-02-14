using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Onff.Extensions;

namespace Onff.UnitTests
{
    public class FeatureToggleFixture
    {
        public FeatureToggleFixture()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", false)
                .Build();
            
            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(configuration);
            services.AddFeatureToggling();

            ServiceProvider = services.BuildServiceProvider();
        }
        
        public IServiceProvider ServiceProvider { get; }
    }
}