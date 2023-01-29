using Microsoft.Xna.Framework;

namespace DockXamlSample
{

    public class GameComponent : Game
    {
        public GameComponent()
        {
        }

        public Game GameSource { get; set; }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Red);
            base.Draw(gameTime);
        }

    }
}
