global using Color = Avalonia.Media.Color;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.Xna.Framework;
//using MonoGame.Framework;




 namespace DockMvvmSample
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public Game1 GameSource => new Game1();

        protected override void LoadContent()
        {
            base.LoadContent();
        }
        
        protected override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {

            GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.Aqua);
            base.Draw(gameTime);
        }

    }
}
