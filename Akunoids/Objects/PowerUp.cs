using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Akunoids.Objects
{
    public class PowerUp : SpriteObject
    {
        private int _type;
        public bool IsVisible;

        public PowerUp(Texture2D texture, Vector2 startPos) : base(OBJTYPES.POWERUP, texture, startPos, new Vector2(0, 3.0f))
        {
            IsVisible = true;
            _type = ObjectManager.GetInstance().rand.Next((int)POWERUPS.MAX_POWERUPS - 1);
        }

        public int GetPowerUp()
        {
            return _type;
        }

        public override void Draw(SpriteBatch sb)
        {
            if (IsVisible)
            {
               base.Draw(sb);
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            ObjectManager objMan = ObjectManager.GetInstance();

            if (GetPosition().Y > objMan.WindowBounds.Height)
            {
                IsVisible = false;
                SetVelocity(Vector2.Zero);
            }

            Paddle p1 = objMan.GetPaddle();
            if (GetCollisionBox().Intersects(p1.GetCollisionBox()))
            {
                IsVisible = false;
                SetVelocity(Vector2.Zero);

                switch (_type)
                {
                    case (int)POWERUPS.AKU:
                        break;
                    case (int)POWERUPS.JACK:
                        break;
                    case (int)POWERUPS.PSIZE:
                        break;
                    case (int)POWERUPS.SPEEDBALL:
                        break;
                    case (int)POWERUPS.SPEEDP:
                        break;
                }
            }
        }
    }
}
