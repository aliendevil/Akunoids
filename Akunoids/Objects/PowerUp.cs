using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Akunoids.Objects
{
    public class PowerUp : SpriteObject
    {
        private int _type;
        public bool IsVisible;

        public PowerUp(Texture2D texture, Vector2 startPos) : base(OBJTYPES.POWERUP, texture, startPos, new Vector2(0, 3.0f))
        {
            IsVisible = true;
            //_type = ObjectManager.GetInstance().rand.Next((int)POWERUPS.MAX_POWERUPS - 1);
            _type = (int)POWERUPS.AKU;
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
            if (!IsActive)
                return;

            base.Update(gameTime);

            ObjectManager objMan = ObjectManager.GetInstance();

            // Missed it
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
                        List<Brick> inactiveBricks = objMan.GetInactiveBricks();
                        int index = objMan.rand.Next(1, inactiveBricks.Count) - 1;
                        Brick addBrick = inactiveBricks[index];
                        if (!addBrick.IsCurrentlyModified)
                        {
                            objMan.AddObjectByType(OBJTYPES.ADDBRICK, addBrick.GetPosition());
                            IsActive = false;
                            IsVisible = false;
                            addBrick.IsCurrentlyModified = true;
                            break;
                        }
                        break;
                    case (int)POWERUPS.JACK:
                        List<Brick> bricks = objMan.GetBricks();
                        foreach (Brick subBrick in bricks)
                        {
                            if (subBrick.IsVisable)
                            {
                                if (!subBrick.IsCurrentlyModified)
                                {
                                    objMan.AddObjectByType(OBJTYPES.SUBBRICK, subBrick.GetPosition());
                                    IsActive = false;
                                    IsVisible = false;
                                    subBrick.IsCurrentlyModified = true;
                                    break;
                                }
                            }
                        }
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
