using CommunityToolkit.Mvvm.ComponentModel;
using System.Reactive.Disposables;

namespace WpfAppBase.ViewModels;

public abstract partial class ViewModelBase : ObservableValidator, IDisposable
{
    protected CompositeDisposable Disposables { get; } = [];

    public void Dispose()
    {
        Disposables.Dispose();
    }
}
