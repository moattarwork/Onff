# Onff
Onff is a feature toggling library for .net standard.

[![Build status](https://ci.appveyor.com/api/projects/status/ocjpch6uo9w20c49?svg=true)](https://ci.appveyor.com/project/moattarwork/onff)
[![NuGet Status](https://img.shields.io/nuget/v/Foil.svg)](https://www.nuget.org/packages/Onff/)

The package can be downloaded from NuGet using

```console
install-package Onff
Install-package Onff.Extensions
```

or

```console
dotnet add package Onff
dotnet add package Onff.Extensions
```

## Usage

The package consists of extensions to register relative services in ServiceCollection.

```csharp
    services.AddFeatureToggling();
.
.
.

    public class SampleService
    {
        private readonly IFeatureToggle _featureToggle;

        public SampleService(IFeatureToggle featureToggle)
        {
            _featureToggle - featureToggle;
        }

        public virtual void Call()
        {
            if (_featureToggle.IsFeatureEnabled("FeatureName"))
            {
                // Do something related to the feature
            }

            // OR

            if (Features.IsEnabled("FeatureName))
            {
                // Do something related to the feature
            }

        }
    }
```

Also every section of the code can be run due to status of a feature
By using **Features** static class

```csharp

public static TResult Run<TResult>(Func<TResult> func, string featureName);
public static void Run(Action action, string featureName);
public static Task<TResult> RunAsync<TResult>(Func<Task<TResult>> func, string featureName);
public static Task RunAsync<TResult>(Func<Task> action, string featureName);

```

Or by using **IFeatureToggle** class

```csharp

public TResult Run<TResult>(Func<TResult> func, string featureName);
public void Run(Action action, string featureName);
public Task<TResult> RunAsync<TResult>(Func<Task<TResult>> func, string featureName);
public Task RunAsync<TResult>(Func<Task> action, string featureName);

```
