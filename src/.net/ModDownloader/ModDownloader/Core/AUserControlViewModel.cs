using System;
using Lamar;
using ReactiveUI;

namespace ModDownloader.Core;

public abstract class AUserControlViewModel : ReactiveObject, IUserControlViewModel
{
    public IView View { get; }
    
    protected IContainer Container;
    
    protected AUserControlViewModel(
        IContainer container,
        IView view)
    {
        Container = container ?? throw new ArgumentNullException(nameof(container));
        View = view ?? throw new ArgumentNullException(nameof(view));
    }
}