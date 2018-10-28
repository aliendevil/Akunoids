using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Akunoids.Objects
{
    public class Brick : SpriteObject
    {
        public bool IsVisable;
        public bool HasPowerUp;
        public bool IsCurrentlyModified;

        public Brick(Texture2D texture, Vector2 startPosition) 
            : base(OBJTYPES.BRICK, texture, startPosition, Vector2.Zero)
        {
            IsVisable = true;
            SetPowerUp();
            IsCurrentlyModified = false;
        }

        public override Rectangle GetCollisionBox()
        {
            if (IsVisable)
                return base.GetCollisionBox();
            else
                return Rectangle.Empty;
        }

        public void SetPowerUp()
        {
            HasPowerUp = ObjectManager.GetInstance().rand.Next(1, 100) % 2 == 0;
            //HasPowerUp = true;
        }


        public override void Update(GameTime gameTime)
        {
            if (!IsVisable)
            {
                if (HasPowerUp)
                {
                    ObjectManager.GetInstance().AddObjectByType(OBJTYPES.POWERUP, GetPosition());
                    HasPowerUp = false;
                }
            }
        }

        public override void Draw(SpriteBatch sb)
        {
            if (IsVisable)
            {
                base.Draw(sb);
            }
        }
    }
}
