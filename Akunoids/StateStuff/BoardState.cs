using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Akunoids.Objects;

namespace Akunoids.StateStuff
{
    public class BoardState : IGameState
    {
        private readonly Game _game;
        private readonly StateManager _stateManager;
        private readonly SpriteBatch _spriteBatch;

        private KeyboardState _oldState;

        private Rectangle _windowBounds;

        private Texture2D _background;

        public BoardState(Game game, StateManager stateManager)
        {
            _game = game;
            _stateManager = stateManager;
            _spriteBatch = new SpriteBatch(_game.GraphicsDevice);
        }

        public void LoadContent()
        {
            _background = _game.Content.Load<Texture2D>(@"KyL_Background01");
            _windowBounds = _game.GraphicsDevice.Viewport.Bounds;
            var playerStart = new Vector2((_windowBounds.Width >> 1) - 64, _windowBounds.Height - 41);
            var ballStart = new Vector2((_windowBounds.Width >> 1) - 16, _windowBounds.Height - 74);
            ObjectManager objManager = ObjectManager.GetInstance();
            objManager.LoadTextures(_game, _windowBounds);
            objManager.AddObjectByType(OBJTYPES.PADDLE, playerStart);
            objManager.AddObjectByType(OBJTYPES.BALL, ballStart);

            //objManager.AddObjectByType(OBJTYPES.BRICK, _game.Content.Load<Texture2D>(@"KyL_SJBrick1"), new Vector2(100,100), _windowBounds);
            float fPosX, fPosY;
            fPosX = 80;
            fPosY = 64;
            for (int i = 0; i < 40; i++)
            {
                // increment x
                if (i != 0)
                    fPosX += 64;
                // if we have hit the right side reset and move down a row
                //if (fPosX >= (_windowBounds.Right - 64))
                if (i != 0 && i % 10 == 0)
                {
                    fPosX = 80;
                    fPosY += 42;
                }
                objManager.AddObjectByType(OBJTYPES.BRICK, new Vector2(fPosX, fPosY));
                continue;
            }
        }

        public void Update(GameTime gameTime)
        {
            var newState = Keyboard.GetState();
            if (_oldState.IsKeyUp(Keys.B) && newState.IsKeyDown(Keys.B))
                _stateManager.ChangeState();

            _oldState = newState;

            ObjectManager.GetInstance().UpdateObjects(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            _windowBounds = _game.GraphicsDevice.Viewport.Bounds;

            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            _spriteBatch.Draw(_background, _windowBounds, Color.White);
            ObjectManager.GetInstance().DrawObjects(_spriteBatch);
            _spriteBatch.End();
        }
    }
}
