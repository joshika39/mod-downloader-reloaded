using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

namespace ModDownloader.Views.Main.Ribbon;

public partial class Ribbon : ReactiveUserControl<RibbonViewModel>, IRibbonView
{
    public Ribbon()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}