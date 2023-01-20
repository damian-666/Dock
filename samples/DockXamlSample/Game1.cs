using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MonoGame.Framework;

namespace DockXamlSample
{

    public class Game1 : Game
    {
        public Game1 GameSource => new Game1();

        protected override void LoadContent()
        {
            base.LoadContent();
        }
        
        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Red);
            base.Draw(gameTime);
        }

    }
}
