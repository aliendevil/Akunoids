using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Akunoids.Objects
{
    public class Brick : SpriteObject
    {
        public bool IsActive;
        public bool HasPowerUp;
        public bool IsModified;

        public Brick(Texture2D texture, Vector2 startPosition) 
            : base(OBJTYPES.BRICK, texture, startPosition, Vector2.Zero)
        {
            IsActive = true;
            HasPowerUp = ObjectManager.GetInstance().rand.Next(1, 100) % 2 == 0;
            IsModified = false;
        }

        public override Rectangle GetCollisionBox()
        {
            if (IsActive)
                return base.GetCollisionBox();
            else
                return Rectangle.Empty;
        }


        public override void Update(GameTime gameTime)
        {
            if (!IsActive)
            {
                if (HasPowerUp)
                {
                    // TODO add powerup
                }
            }
        }

        public override void Draw(SpriteBatch sb)
        {
            if (IsActive)
            {
                base.Draw(sb);
            }
        }
    }
}
