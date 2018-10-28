using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akunoids.Objects
{
    class AddBrick : SpriteObject
    {
        private TimeSpan _timer;
        private TimeSpan _animationSpeed;
        private List<Rectangle> _frames;
        private int _frameIndex;

        public AddBrick(Texture2D texture, Brick brick) : base(OBJTYPES.ADDBRICK, texture)
        {
            SetPosition(brick.GetPosition().X - 100, brick.GetPosition().Y - 65);
            SetVelocity(Vector2.Zero);
            brick.IsCurrentlyModified = true;
            _animationSpeed = TimeSpan.FromMilliseconds(200);
            _frameIndex = 0;

            _frames = new List<Rectangle>
            {
                new Rectangle(30, 0, 115, 110),
                new Rectangle(115, 0, 190, 110),
                new Rectangle(190, 0, 275, 110),
                new Rectangle(275, 0, 370, 110),
                new Rectangle(370, 0, 463, 110),
                new Rectangle(463, 0, 568, 110),
                new Rectangle(568, 0, 680, 110),
                new Rectangle(17, 110, 130, 228),
                new Rectangle(130, 110, 250, 228),
                new Rectangle(250, 110, 430, 228),
                new Rectangle(433, 110, 614, 228),
                new Rectangle(250, 110, 430, 228),
                new Rectangle(24, 228, 150, 334),
                new Rectangle(463, 0, 568, 110),
                new Rectangle(150, 228, 250, 334),
                new Rectangle(275, 0, 370, 110),
                new Rectangle(190, 0, 275, 110),
                new Rectangle(115, 0, 190, 110),
                new Rectangle(30, 0, 115, 110),
                new Rectangle()
            };

        }

        public override void Draw(SpriteBatch sb)
        {
            if (!IsActive)
                return;

            sb.Draw(GetTexture(), GetPosition(), _frames[_frameIndex], Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            if (!IsActive)
                return;

            _timer += gameTime.ElapsedGameTime;
            if (_timer > _animationSpeed)
            {
                // reset the timer
                _timer -= _animationSpeed;
                // change the frame
                _frameIndex++;
            }


            // Move to the next animation and add a brick
            else if (_frameIndex == 10)
            {
                // Add a brick
                //if (!m_bAdded)
                //{
                //    for (int i = 0; i < pOM->GetSize(); i++)
                //    {
                //        pBrick = dynamic_cast<CBrickClass*>(pOM->GetBrick(i));
                //        // only if it actually is a brick
                //        if (pBrick)
                //        {
                //            // only if this is the same brick we started with
                //            if (pBrick->GetPosition() == m_vAddBrickPos)
                //            {
                //                // switch it to visible
                //                if (pBrick->GetHit())
                //                {
                //                    pBrick->SetHit(false);
                //                    m_bAdded = true;
                //                    return;
                //                }
                //            }
                //        }
                //    }
                //}
                return;
            }
            // We're all done with it so...
            else if (_frameIndex == _frames.Count - 1)
            {
                _frameIndex = 0;
                IsActive = false;
                // change the brick back to allow it to be used again.
                //for (int i = 0; i < pOM->GetSize(); i++)
                //{
                //    pBrick = dynamic_cast<CBrickClass*>(pOM->GetBrick(i));
                //    if (pBrick)
                //    {
                //        if (pBrick->GetPosition() == m_vAddBrickPos)
                //        {
                //            pBrick->SetModifiedFlag(false);
                //            break;
                //        }
                //    }
                //}
                //// delete this animation as it is no longer needed.
                //pOM->DeleteObject(this);
            }
        }
    }
}
