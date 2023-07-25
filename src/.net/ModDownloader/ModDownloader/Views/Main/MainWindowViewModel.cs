using System;
using System.Diagnostics;
using System.Reactive;
using Lamar;
using ModDownloader.Core;
using ModDownloader.Views.Main.Ribbon;
using ModDownloader.Views.MainContent;
using ReactiveUI;

namespace ModDownloader.Views.Main
{
    public class MainWindowViewModel : AWindowViewModel, IMainWindowViewModel
    {
        public IRibbonViewModel RibbonViewModel { get; }
        public IMainViewModel MainViewModel { get; }
        
        public string Greeting => "Welcome to Avalonia!";

        public MainWindowViewModel(
            IContainer container, 
            IMainWindow window,
            IRibbonViewModel ribbonViewModel,
            IMainViewModel mainViewModel) : base(container, window)
        {
            RibbonViewModel = ribbonViewModel ?? throw new ArgumentNullException(nameof(ribbonViewModel));
            MainViewModel = mainViewModel ?? throw new ArgumentNullException(nameof(mainViewModel));
            
        }
    }
}
