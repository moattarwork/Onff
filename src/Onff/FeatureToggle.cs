using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onff
{
    public class FeatureToggle : IFeatureToggle
    {
        private readonly List<Feature> _features;

        public FeatureToggle(List<Feature> features)
        {
            _features = features;
        }

        public bool IsFeatureEnabled(string featureName)
        {
            if (featureName == null) throw new ArgumentNullException(nameof(featureName));
            
            var feature = _features.FirstOrDefault(m => m.Name.Equals(featureName, StringComparison.CurrentCultureIgnoreCase));
            return feature?.IsEnabled ?? false;
        }

        public TResult Run<TResult>(Func<TResult> func, string featureName)
        {
            return IsFeatureEnabled(featureName) ? func() : default(TResult);
        }

        public void Run(Action action, string featureName)
        {
            if (IsFeatureEnabled(featureName))
                action();
        }

        public Task<TResult> RunAsync<TResult>(Func<Task<TResult>> func, string featureName)
        {
            return IsFeatureEnabled(featureName) ? func() : Task.FromResult(default(TResult));
        }

        public Task RunAsync(Func<Task> action, string featureName)
        {
            return IsFeatureEnabled(featureName) ? action() : Task.CompletedTask;
        }
    }
}