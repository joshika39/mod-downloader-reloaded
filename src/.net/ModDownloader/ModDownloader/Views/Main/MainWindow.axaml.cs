using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Backend.Extensions;
using ReactiveUI;

namespace ModDownloader.Views.Main
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>, IMainWindow
    {
        public MainWindow()
        {
            DataContext = this.CreateInstance<MainWindowViewModel>();
            // ViewModel's WhenActivated block will also get called.
            this.WhenActivated(disposables => { /* Handle view activation etc. */ });
            AvaloniaXamlLoader.Load(this);
        }
    }
}
