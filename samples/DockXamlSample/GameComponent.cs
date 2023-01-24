using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DockXamlSample.Games;
using Microsoft.Xna.Framework;
using MonoGame.Framework;

namespace DockXamlSample
{

    public class GameComponent : Game
    {
        public GameComponent()
        {
            GameSource = new MonkeyGame();
        }
        public Game GameSource { get; set; }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Red);
            base.Draw(gameTime);
        }

    }
}
