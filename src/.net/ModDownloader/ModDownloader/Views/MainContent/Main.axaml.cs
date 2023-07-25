using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Backend.Extensions;
using ModDownloader.Views.Main;
using ReactiveUI;

namespace ModDownloader.Views.MainContent;

public partial class Main : ReactiveUserControl<MainViewModel>, IMainView
{
    public Main()
    {
        DataContext = this.CreateInstance<MainWindowViewModel>();
        // ViewModel's WhenActivated block will also get called.
        this.WhenActivated(disposables => { /* Handle view activation etc. */ });
        AvaloniaXamlLoader.Load(this);
    }
    
}