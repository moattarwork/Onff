using System;
using System.Collections.Generic;
using System.Linq;

namespace Onff
{
    public class FeatureToggle : IFeatureToggle
    {
        private readonly List<Feature> _features;

        public FeatureToggle(List<Feature> features)
        {
            _features = features;
        }

        public bool IsFeatureEnabled(string name)
        {
            var feature = _features.FirstOrDefault(m => m.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));

            return feature?.IsEnabled ?? false;
        }
    }
}