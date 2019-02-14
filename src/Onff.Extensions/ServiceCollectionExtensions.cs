using System;
using Microsoft.Extensions.DependencyInjection;

namespace Onff.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFeatureToggling(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSingleton<IFeatureToggleBuilder, FeatureToggleBuilder>();
            
            services.AddSingleton(sp =>
            {
                var builder = sp.GetRequiredService<IFeatureToggleBuilder>();
                var featureToggle = builder.Build();
                
                Features.SetFeatureToggle(featureToggle);

                return featureToggle;
            });

            return services;
        }
    }
}
