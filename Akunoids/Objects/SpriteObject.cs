using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Akunoids.Objects
{
    public class SpriteObject
    {
        private Vector2 _vPosition;
        private Vector2 _vVelocity;
        private Texture2D _tTexture;
        private Rectangle _rBoundingBox;
        private Vector2 _startPos;
        private Vector2 _oldPos;

        private readonly OBJTYPES _type;

        public bool IsActive;  // TODO use this for tracking if this can be reused if false it is given to the next thing that wants that object (mainly used for powerups)

        public SpriteObject() { }
        public SpriteObject(OBJTYPES type, Texture2D texture)
        {
            IsActive = true;
            _type = type;
            _tTexture = texture;
            _startPos = Vector2.Zero;
            _oldPos = _startPos;
            _vPosition = Vector2.Zero;
            _vVelocity = Vector2.Zero;
            _rBoundingBox = new Rectangle(0, 0, _tTexture.Width, _tTexture.Height);
        }
        public SpriteObject(OBJTYPES type, Texture2D texture, Vector2 position, Vector2 velocity)
        {
            IsActive = true;
            _type = type;
            _tTexture = texture;
            _startPos = _vPosition = position;
            _oldPos = _startPos;
            _vVelocity = velocity;
            _rBoundingBox = new Rectangle(0, 0, _tTexture.Width, _tTexture.Height);
        }

        public OBJTYPES Type() { return _type; }
        public Vector2 GetPosition() { return _vPosition; }
        public Vector2 GetStartPosition() { return _startPos; }
        public Vector2 GetOldPosition() { return _oldPos; }

        public Vector2 GetVelocity() { return _vVelocity; }

        public Texture2D GetTexture() { return _tTexture; }

        public Rectangle GetBoundingBox() { return _rBoundingBox;  }

        public virtual Rectangle GetCollisionBox()
        {
            return new Rectangle((int)GetPosition().X, (int)GetPosition().Y, GetBoundingBox().Width, GetBoundingBox().Height);
        }

        public void SetPosition(Vector2 position)
        {
            _vPosition = position;
        }
        public void SetPosition(float x, float y)
        {
            _vPosition.X = x;
            _vPosition.Y = y;
        }

        public void SetStartPosition(Vector2 position)
        {
            _startPos = position;
        }

        public void SetOldPosition(Vector2 position)
        {
            _oldPos = position;
        }

        public void SetVelocity(Vector2 velocity)
        {
            _vVelocity = velocity;
        }
        public void SetVelocity(float x, float y)
        {
            _vVelocity.X = x;
            _vVelocity.Y = y;
        }

        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(GetTexture(), GetPosition(), GetBoundingBox(), Color.White);
        }

        public virtual void Update(GameTime gameTime)
        {
            _oldPos = _vPosition;
            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            _vPosition += _vVelocity;// * deltaTime;
        }
    }
}
