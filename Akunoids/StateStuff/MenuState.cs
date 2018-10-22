using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Akunoids.StateStuff
{
    public class MenuState : IGameState
    {
        private readonly Game _game;
        private readonly StateManager _stateManager;
        private KeyboardState _oldState;

        public MenuState(Game game, StateManager stateManager)
        {
            _game = game;
            _stateManager = stateManager;
        }

        public void LoadContent()
        {
            //_font = _game.Content.Load<SpriteFont>(@"DefaultFont");
        }

        public void Update(GameTime gameTime)
        {
            var newState = Keyboard.GetState();
            if (_oldState.IsKeyUp(Keys.V) && newState.IsKeyDown(Keys.V))
                _stateManager.ChangeState();

            _oldState = newState;
        }

        public void Draw(GameTime gameTime)
        {
            //_spriteBatch.Begin();
            //_spriteBatch.DrawString(_font, "BATTLE", Vector2.Zero, Color.Red, 0.0f, Vector2.Zero, 4.0f,
            //    SpriteEffects.None, 1.0f);
            //_spriteBatch.End();
        }
    }
}
