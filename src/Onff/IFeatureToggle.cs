using System;
using System.Threading.Tasks;

namespace Onff
{
    public interface IFeatureToggle
    {
        bool IsFeatureEnabled(string featureName);
        TResult Run<TResult>(Func<TResult> func, string featureName);
        void Run(Action action, string featureName);
        Task<TResult> RunAsync<TResult>(Func<Task<TResult>> func, string featureName);
        Task RunAsync(Func<Task> action, string featureName);
    }
}