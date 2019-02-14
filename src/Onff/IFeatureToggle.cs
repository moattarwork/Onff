namespace Onff
{
    public interface IFeatureToggle
    {
        bool IsFeatureEnabled(string name);
    }
}