using System.Reactive.Disposables;
using ReactiveUI;

namespace ModDownloader.ViewModels;

public abstract class ABaseViewModel : ReactiveObject, IActivatableViewModel
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
