using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Onff
{
    public class FeatureToggleBuilder : IFeatureToggleBuilder
    {
        private const string FeaturesSection = "Features";
        
        private readonly IConfiguration _configuration;

        public FeatureToggleBuilder(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }

        public IFeatureToggle Build()
        {
            var section = _configuration.GetSection(FeaturesSection);
            if (section == null)
                return new FeatureToggle(new List<Feature>());
            
            var features = section.GetChildren().Select(c => new Feature(c.Key, bool.Parse(c.Value))).ToList();
            return new FeatureToggle(features);
        }
    }
}