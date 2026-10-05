using R86.Wpf.Hosting;

namespace WpfAppBase;

public partial class App : HostedApplication<App>
{
    public App()
    {
        // if we add somthing to App.xaml, uncomment the following line

        /* 
         InitializeComponent();
        */
    }

    protected override async Task StartAsync(CancellationToken cancellationToken)
    {
        // TODO: Show splash screen
        await Task.CompletedTask;

        this.MainWindow = new MainWindow();

        this.MainWindow.Show();

        // TODO: Close splash screen
    }
}
