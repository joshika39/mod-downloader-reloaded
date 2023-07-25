using System;
using System.Linq;
using System.Reflection;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Lamar;
using Microsoft.Extensions.DependencyInjection;
using ModDownloader.Core;
using ModDownloader.Views;
using ModDownloader.Views.Main;

namespace ModDownloader;

public partial class App : Application
{
    public static IContainer Container { get; set; }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            Container = new Container(cfg =>
            {
                cfg.Scan(scan =>
                {
                    scan.AssemblyContainingType<Program>();
                    scan.AddAllTypesOf<IWindowViewModel>();
                    scan.WithDefaultConventions();
                });
            });
            
            var test = Container.GetService<IMainWindowViewModel>();
        }

        base.OnFrameworkInitializationCompleted();
    }
}
