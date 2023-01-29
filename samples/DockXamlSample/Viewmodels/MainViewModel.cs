using DockXamlSample.Games;
using Microsoft.Xna.Framework;
using ReactiveUI;

namespace DockXamlSample.Viewmodels;

public class MainViewModel : ReactiveObject
{
    public MainViewModel()
    {
        MonkeyGame = new MonkeyGame();
        GamePong = new AutoPongGame();
        String1 = "Solution Explorer";
    }

    public MonkeyGame MonkeyGame { get; set; }

    public AutoPongGame GamePong { get; set; }

    public string String1 { get; set; }

    public Avalonia.Media.Color DiffuseColor
    {
        get => ToColor(MonkeyGame.DiffuseColor);
        set => MonkeyGame.DiffuseColor = ToVector3(value);
    }
    public Avalonia.Media.Color SpecularColor {
        get => ToColor(MonkeyGame.SpecularColor);
        set => MonkeyGame.SpecularColor = ToVector3(value);
    }
    public Avalonia.Media.Color AmbientLightColor {
        get => ToColor(MonkeyGame.AmbientLightColor);
        set => MonkeyGame.AmbientLightColor = ToVector3(value);
    }
    public Avalonia.Media.Color EmissiveColor {
        get => ToColor(MonkeyGame.EmissiveColor);
        set => MonkeyGame.EmissiveColor = ToVector3(value);
    }

    private static Avalonia.Media.Color ToColor(Vector3 v) =>
        new(byte.MaxValue, (byte)(v.X * byte.MaxValue), (byte)(v.Y * byte.MaxValue), (byte)(v.Z * byte.MaxValue));

    private static Vector3 ToVector3(Avalonia.Media.Color c) => new((float)c.R / (float)byte.MaxValue,
        (float)c.G / (float)byte.MaxValue, (float)c.B / (float)byte.MaxValue);
}
