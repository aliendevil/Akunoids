using Microsoft.Xna.Framework;

namespace Akunoids.StateStuff
{
    public interface IGameState
    {
        void LoadContent();
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime);
    }
}
