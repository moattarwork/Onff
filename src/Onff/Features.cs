using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Onff
{
    public static class Features
    {
        private static IFeatureToggle _featureToggle;
        
        public static void SetFeatureToggle(IFeatureToggle featureToggle)
        {
            _featureToggle = featureToggle;
        }

        public static bool IsEnabled(string featureName) => _featureToggle.IsFeatureEnabled(featureName);

        public static TResult Run<TResult>(Func<TResult> func, string featureName)
            => _featureToggle.Run(func, featureName);
        public static void Run(Action action, string featureName)
            => _featureToggle.Run(action, featureName);        
        
        public static Task<TResult> RunAsync<TResult>(Func<Task<TResult>> func, string featureName)
            => _featureToggle.RunAsync(func, featureName);
        public static Task RunAsync<TResult>(Func<Task> action, string featureName)
            => _featureToggle.RunAsync(action, featureName);
    }
}


