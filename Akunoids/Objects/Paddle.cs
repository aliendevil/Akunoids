using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Akunoids.Objects
{
    public class Paddle : SpriteObject
    {
        private float _movementSpeed = 5.0f;
        
        public Paddle(Texture2D playerTexture, Vector2 startPos) 
            : base(OBJTYPES.PADDLE, playerTexture, startPos, Vector2.Zero)
        {
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
                var maxXPos = ObjectManager.GetInstance().WindowBounds.Width - GetTexture().Width;
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
