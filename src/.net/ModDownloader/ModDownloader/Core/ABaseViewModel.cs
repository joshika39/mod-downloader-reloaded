using System.Reactive.Disposables;
using ReactiveUI;

namespace ModDownloader.Core;

public abstract class ABaseViewModel : ReactiveObject, IActivatableViewModel, IWindowViewModel
{
    public ViewModelActivator Activator { get; }
    
    protected ABaseViewModel()
    {
        Activator = new ViewModelActivator();
        this.WhenActivated((CompositeDisposable disposables) =>
        {
            /* handle activation */
            Disposable.Create(() => { /* handle deactivation */ }).DisposeWith(disposables);
        });
    }
}
