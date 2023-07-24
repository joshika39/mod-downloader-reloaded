using System;
using System.Linq;
using System.Reflection;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using ModDownloader.ViewModels;
using ModDownloader.Views;

namespace ModDownloader;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            ConfigureServices();
        }

        base.OnFrameworkInitializationCompleted();
    }
    
    private void ConfigureServices()
    {
        // Create a new service collection
        var services = new ServiceCollection();

        // Get all the types from the executing assembly that implement IMyViewModel
        var viewModelTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t is { IsAbstract: false, IsInterface: false } && t.GetInterfaces().Any(i => i.Name.StartsWith("I") && i.Name[1..] == t.Name));

        // Loop through the types and register them with their interfaces
        foreach (var viewModelType in viewModelTypes)
        {
            var interfaceType = viewModelType.GetInterfaces().FirstOrDefault(i => i.Name.StartsWith("I") && i.Name.Substring(1) == viewModelType.Name);
            if (interfaceType != null)
            {
                services.AddSingleton(interfaceType, viewModelType);
            }
        }

        // Build the service provider
        var serviceProvider = services.BuildServiceProvider();
        Resources[typeof(IServiceProvider)] = services;
    }
}
