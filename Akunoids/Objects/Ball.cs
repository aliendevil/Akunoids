using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Akunoids.Objects
{
    public class Ball : SpriteObject
    {
        private float _movementSpeed = 5.0f;

        private bool _isInPlay;
        private float _fRotation;
        private float _fScale;
        private float _fSpinSpeed;

        public Ball(Texture2D texture, Vector2 startPos)
            : base(OBJTYPES.BALL, texture, startPos, Vector2.Zero)
        {
            SetPosition(startPos);
            SetVelocity(Vector2.Zero);
            _isInPlay = false;
            _fRotation = 1.0f;
            _fScale = 1.0f;
            _fSpinSpeed = 0.1f;
        }

        private Vector2 GetCenterPoint()
        {
            return GetBoundingBox().Center.ToVector2();
        }

        public override void Update(GameTime gameTime)
        {
            ObjectManager obj = ObjectManager.GetInstance();
            Paddle p1 = obj.GetPaddle();
            KeyboardState kb = Keyboard.GetState();
            if (!_isInPlay)
            {
                SetVelocity(p1.GetVelocity());

                if (kb.IsKeyDown(Keys.Space))
                {
                    SetVelocity(_movementSpeed, -_movementSpeed);
                    _isInPlay = true;
                }
            }
            else
            {
                // Wall Collision
                // Right wall
                if ((GetPosition().X + GetBoundingBox().Width) >= obj.WindowBounds.Width)
                    SetVelocity(GetVelocity().X * -1, GetVelocity().Y);
                // Left wall
                if (GetPosition().X <= 0)
                    SetVelocity(GetVelocity().X * -1, GetVelocity().Y);
                // Top wall
                if (GetPosition().Y <= 0)
                    SetVelocity(GetVelocity().X, GetVelocity().Y * -1);
                // Bottom wall
                if ((GetPosition().Y + GetBoundingBox().Height) >= obj.WindowBounds.Height || kb.IsKeyDown(Keys.R))
                {
                    // reset ball
                    _isInPlay = false;
                    SetVelocity(Vector2.Zero);
                    SetPosition(GetStartPosition());
                    _fRotation = 1.0f;
                    _fSpinSpeed = 0.1f;
                    // reset paddle
                    p1.SetPosition(p1.GetStartPosition());
                }

                // Paddle Collision
                Rectangle currentRect = GetCollisionBox();
                Rectangle paddleRect = p1.GetCollisionBox();

                if (currentRect.Intersects(paddleRect)) //TODO seriously ??? sad... just sad...
                {
                    if (GetOldPosition().X < GetPosition().X)
                        SetVelocity(GetVelocity().X, GetVelocity().Y * -1);
                    else if (GetOldPosition().X > GetPosition().X)
                        SetVelocity(GetVelocity().X, GetVelocity().Y * -1);
                    else
                        SetVelocity(GetVelocity() * -1);
                }

                // Brick Collision
                foreach(Brick brick in obj.GetBricks())
                {
                    if (brick.GetCollisionBox().Intersects(GetCollisionBox())) // TODO this is terrible collision detection
                    {
                        SetVelocity(GetVelocity() * -1);
                        brick.IsVisable = false;
                        break;
                    }
                }
            }

            // Update the position
            base.Update(gameTime);
            // Update the rotation
            _fRotation += _fSpinSpeed;
        }

        public override void Draw(SpriteBatch sb)
        {
            //sb.Draw(GetTexture(), GetPosition(), GetBoundingBox(), Color.White);
            sb.Draw(GetTexture(), GetPosition() + GetCenterPoint(), GetBoundingBox(), Color.White, _fRotation, GetCenterPoint(), _fScale, SpriteEffects.None, 1.0f);
        }
    }
}
