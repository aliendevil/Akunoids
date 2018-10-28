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
        private bool _isBrickAdded = false;
        private Brick _brick;

        public AddBrick(Texture2D texture, Brick brick) : base(OBJTYPES.ADDBRICK, texture)
        {
            _brick = brick;
            SetPosition(brick.GetPosition().X - 100, brick.GetPosition().Y - 65);
            SetVelocity(Vector2.Zero);
            brick.IsCurrentlyModified = true;
            _animationSpeed = TimeSpan.FromMilliseconds(200);
            _frameIndex = 0;

            _frames = new List<Rectangle>
            {
                new Rectangle(30, 0, 85, 110),
                new Rectangle(115, 0, 75, 110),
                new Rectangle(190, 0, 85, 110),
                new Rectangle(275, 0, 95, 110),
                new Rectangle(370, 0, 93, 110),
                new Rectangle(463, 0, 105, 110),
                new Rectangle(568, 0, 112, 110),
                new Rectangle(17, 110, 113, 118),
                new Rectangle(130, 110, 120, 118),
                new Rectangle(250, 110, 180, 118),
                new Rectangle(433, 110, 181, 118),
                new Rectangle(250, 110, 180, 118),
                new Rectangle(24, 228, 126, 106),
                new Rectangle(463, 0, 105, 110),
                new Rectangle(150, 228, 100, 106),
                new Rectangle(275, 0, 95, 110),
                new Rectangle(190, 0, 85, 110),
                new Rectangle(115, 0, 75, 110),
                new Rectangle(30, 0, 85, 110),
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
                if (!_isBrickAdded)
                {
                    if (!_brick.IsVisable)
                    {
                        _brick.IsVisable = true;
                        _isBrickAdded = true;
                        _brick.SetPowerUp();
                    }
                }
            }
            // We're all done with it so...
            else if (_frameIndex == _frames.Count - 1)
            {
                _frameIndex = 0;
                // change the brick back to allow it to be used again.
                _brick.IsActive = true;
                _brick.IsCurrentlyModified = false;
                // delete this animation as it is no longer needed.
                IsActive = false;
            }
        }
    }
}
