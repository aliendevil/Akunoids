using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;

namespace Akunoids.Objects
{
    public class ObjectManager
    {
        // Singleton
        private ObjectManager()
        {
            _spriteObjects = new List<SpriteObject>();
        }

        private static readonly ObjectManager _instance = new ObjectManager();

        public static ObjectManager GetInstance() { return _instance; }

        // Variables
        private List<SpriteObject> _spriteObjects;

        public Random rand = new Random();
        public int GetSize () { return _spriteObjects.Count; }
        public int GetNumberOfBricks() { return GetBricks().Count; }

        public Paddle GetPaddle() { return (Paddle)_spriteObjects.Find(x => x.Type().Equals(OBJTYPES.PADDLE)); }
        public Ball GetBall() { return (Ball)_spriteObjects.Find(x => x.Type().Equals(OBJTYPES.BALL)); }
        public List<SpriteObject> GetBricks() { return _spriteObjects.FindAll(x => x.Type().Equals(OBJTYPES.BRICK)); }

        public void AddObject(SpriteObject sObject) { _spriteObjects.Add(sObject); }

        public void AddObjectByType(OBJTYPES nType, Texture2D texture, Vector2 startPos, Rectangle windowBounds)
        {
            switch(nType)
            {
                case OBJTYPES.PADDLE:
                    {
                        Paddle player1 = new Paddle(texture, startPos, windowBounds);
                        _spriteObjects.Add(player1);
                        break;
                    }
                case OBJTYPES.BRICK:
                    {
                        Brick brick = new Brick(texture, startPos);
                        _spriteObjects.Add(brick);
                        break;
                    }
                case OBJTYPES.BALL:
                    {
                        Ball ball = new Ball(texture, startPos, windowBounds);
                        _spriteObjects.Add(ball);
                        break;
                    }
            }
        }

        // Update all objects
        public void UpdateObjects(GameTime gameTime)
        {
            foreach (SpriteObject sObj in _spriteObjects)
                sObj.Update(gameTime);
        }

        // Draw all objects
        public void DrawObjects(SpriteBatch sb)
        {
            foreach (SpriteObject sObj in _spriteObjects)
                sObj.Draw(sb);
        }
    }
}
