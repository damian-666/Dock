using Microsoft.Xna.Framework;
using ReactiveUI;

namespace DockXamlSample.Viewmodels;

public class MainViewModel : ReactiveObject
{
    public MainViewModel()
    {
        String1 = "Solution Explorer";
    }

    public Game Game { get; set; } = new();

    public string String1 { get; set; }
}
