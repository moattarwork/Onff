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
    }
}