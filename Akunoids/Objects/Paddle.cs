using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Akunoids.Objects
{
    public class Paddle : SpriteObject
    {
        private float _movementSpeed = 5.0f;
        private Rectangle _windowBounds;
        
        public Paddle(Texture2D playerTexture, Vector2 startPos, Rectangle windowBounds) 
            : base(OBJTYPES.PADDLE, playerTexture, startPos, Vector2.Zero)
        {
            _windowBounds = windowBounds;
        }

        override public void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            KeyboardState kb = Keyboard.GetState();
            if (kb.IsKeyDown(Keys.Left))
            {
                SetVelocity(-_movementSpeed, 0.0f);
                if (GetPosition().X <= 0.0f)
                {
                    SetVelocity(Vector2.Zero);
                    SetPosition(0.0f, GetPosition().Y);
                }
            }
            else if (kb.IsKeyDown(Keys.Right))
            {
                var maxXPos = _windowBounds.Width - GetTexture().Width;
                SetVelocity(_movementSpeed, 0.0f);
                if (GetPosition().X >= maxXPos)
                {
                    SetVelocity(Vector2.Zero);
                    SetPosition(maxXPos, GetPosition().Y);
                }
            }
            else
                SetVelocity(Vector2.Zero);

        }
    }
}
