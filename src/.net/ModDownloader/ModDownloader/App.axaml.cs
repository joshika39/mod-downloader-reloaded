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
using ModDownloader.Views.Main.Ribbon;
using ModDownloader.Views.MainContent;

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
                    scan.AddAllTypesOf<IUserControlViewModel>();
                    scan.AddAllTypesOf<IWindow>();
                    scan.AddAllTypesOf<IView>();
                    scan.WithDefaultConventions();
                });

                cfg.AddSingleton<IMainViewModel, MainViewModel>();
            });
            
            var test = Container.GetService<IMainWindowViewModel>();
            var test2 = Container.GetService<IMainViewModel>();
            var ribbon = Container.GetService<IRibbonViewModel>();
        }

        base.OnFrameworkInitializationCompleted();
    }
}
