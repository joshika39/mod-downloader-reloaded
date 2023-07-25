using System;
using System.Reactive.Disposables;
using Lamar;
using ReactiveUI;

namespace ModDownloader.Core;

public abstract class AWindowViewModel : ReactiveObject, IActivatableViewModel, IWindowViewModel
{
    public ViewModelActivator Activator { get; }
    public IWindow Window { get; }

    protected IContainer Container { get; }
    
    protected AWindowViewModel(
        IContainer container,
        IWindow window)
    {
        Container = container ?? throw new ArgumentNullException(nameof(container));
        Window = window ?? throw new ArgumentNullException(nameof(window));
        
        Activator = new ViewModelActivator();
        this.WhenActivated((CompositeDisposable disposables) =>
        {
            /* handle activation */
            Disposable.Create(() => { /* handle deactivation */ }).DisposeWith(disposables);
        });
    }
}
