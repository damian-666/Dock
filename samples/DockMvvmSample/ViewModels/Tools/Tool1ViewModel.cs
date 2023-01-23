using Avalonia.Data;
using Dock.Model.Mvvm.Controls;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework;

namespace DockMvvmSample.ViewModels.Tools;

//test.. see if there is a name conflict
using Color = Avalonia.Media.Color;

public class Tool1ViewModel : Tool
{
    

    


    public Game1 GameSource => new Game1();



}

public class Game1 : Microsoft.Xna.Framework.Game
{
    protected override void LoadContent()
    {
        base.LoadContent();
    }

    protected override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
    {

        GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.Beige);
        base.Draw(gameTime);
    }
}
