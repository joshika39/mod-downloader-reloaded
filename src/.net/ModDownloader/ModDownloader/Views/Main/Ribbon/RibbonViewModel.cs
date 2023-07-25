using System;
using Lamar;
using ModDownloader.Core;
using ModDownloader.Views.MainContent;

namespace ModDownloader.Views.Main.Ribbon;

public class RibbonViewModel : AUserControlViewModel, IRibbonViewModel
{
    private readonly IMainView _mainView;

    public RibbonViewModel(
        IContainer container, 
        IView view,
        IMainView mainView) : base(container, view)
    {
        _mainView = mainView ?? throw new ArgumentNullException(nameof(mainView));
    }
}