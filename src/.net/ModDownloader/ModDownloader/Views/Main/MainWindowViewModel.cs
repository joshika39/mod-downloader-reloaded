using System;
using System.Diagnostics;
using System.Reactive;
using Lamar;
using ModDownloader.Core;
using ReactiveUI;

namespace ModDownloader.Views.Main
{
    public class MainWindowViewModel : ABaseViewModel, IMainWindowViewModel
    {
        private string _description = string.Empty;

        public string Greeting => "Welcome to Avalonia!";
        public string Description
        {
            get => _description;
            set => this.RaiseAndSetIfChanged(ref _description, value);
        }

        private string _userName = string.Empty;

        public string UserName
        {
            get => _userName;
            set => this.RaiseAndSetIfChanged(ref _userName, value);
        }

        public ReactiveCommand<Unit, Unit> SubmitCommand { get; }

        public MainWindowViewModel(IContainer container)
        {
            IObservable<bool> isInputValid = this.WhenAnyValue(
                x => x.UserName,
                x => !string.IsNullOrWhiteSpace(x) && x.Length > 7
                );
        
            SubmitCommand = ReactiveCommand.Create(OnSubmitCommand, isInputValid);
        }
        private void OnSubmitCommand()
        {
            Debug.WriteLine("The submit command was run.");
        }

    
    }
}
