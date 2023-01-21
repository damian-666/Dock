using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace DockDemoMonoGame.Views;

public partial class MainViewMonoG : UserControl
{
    public MainViewMonoG()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}

