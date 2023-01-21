using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using DockDemoMonoGame.ViewModels;
using DockDemoMonoGame.Views;

namespace DockDemoMonoGame
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktopLifetime)
            {
                desktopLifetime.MainWindow = new MainWindow();
            }

            if (ApplicationLifetime is ISingleViewApplicationLifetime singleLifetime)
            {
                singleLifetime.MainView = new MainViewMonoG();
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
