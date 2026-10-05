using Microsoft.Extensions.DependencyInjection;
using R86.Wpf.Hosting;
using System.ComponentModel;
using System.Windows.Controls;
using WpfAppBase.ViewModels;

namespace WpfAppBase.Views;

public abstract partial class ViewBase<T> : UserControl where T : ViewModelBase
{
    public T ViewModel { get; }

    protected ViewBase()
    {
        if (DesignerProperties.GetIsInDesignMode(this))
        {
            ViewModel = default!;
            return;
        }

        this.DataContext = ViewModel = HostedApplication.Current.Services.GetRequiredService<T>();
    }
}
