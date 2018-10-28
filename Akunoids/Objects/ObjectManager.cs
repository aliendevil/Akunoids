using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using System.Linq;

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
        public Rectangle WindowBounds;

        private Texture2D _paddleTexture;
        private Texture2D _ballTexture;
        private Texture2D _brickTexture;
        private Texture2D _powerUpTexture;
        private Texture2D _akuTexture;

        public void LoadTextures(Game game, Rectangle windowBounds)
        {
            WindowBounds = windowBounds;
            _paddleTexture = game.Content.Load<Texture2D>(@"KyL_PaddleLarge");
            _ballTexture = game.Content.Load<Texture2D>(@"KyL_AkuBall");
            _brickTexture = game.Content.Load<Texture2D>(@"KyL_SJBrick1");
            _powerUpTexture = game.Content.Load<Texture2D>(@"KyL_SJBrick2");
            _akuTexture = game.Content.Load<Texture2D>(@"KyL_AkuAdd");
        }

        public int GetSize () { return _spriteObjects.Count; }
        public int GetNumberOfBricks() { return GetBricks().Count; }

        public Paddle GetPaddle() { return _spriteObjects.OfType<Paddle>().First(); }
        public Ball GetBall() { return _spriteObjects.OfType<Ball>().First(); }
        public List<Brick> GetBricks() { return _spriteObjects.OfType<Brick>().ToList(); }
        public Brick GetBrick(int index) { return _spriteObjects.OfType<Brick>().ToList()[index]; }
        public List<Brick> GetInactiveBricks() { return _spriteObjects.OfType<Brick>().ToList().FindAll(a => !a.IsActive); }
        // TODO: add a get random visable brick and a get random invisable brick methods (and not modified)

        public void AddObject(SpriteObject sObject) { _spriteObjects.Add(sObject); }

        public void AddObjectByType(OBJTYPES nType, Vector2 startPos)
        {
            switch(nType)
            {
                case OBJTYPES.PADDLE:
                    {
                        Paddle player1 = new Paddle(_paddleTexture, startPos);
                        _spriteObjects.Add(player1);
                        break;
                    }
                case OBJTYPES.BRICK:
                    {
                        Brick brick = new Brick(_brickTexture, startPos);
                        _spriteObjects.Add(brick);
                        break;
                    }
                case OBJTYPES.BALL:
                    {
                        Ball ball = new Ball(_ballTexture, startPos);
                        _spriteObjects.Add(ball);
                        break;
                    }
                case OBJTYPES.POWERUP:
                    {
                        // TODO check to see if we have any inactive before creating
                        PowerUp pUp = new PowerUp(_powerUpTexture, startPos);
                        _spriteObjects.Add(pUp);
                        break;
                    }
                case OBJTYPES.ADDBRICK:
                    {
                        var bricks = GetBricks();
                        Brick brick = bricks.Find(a => a.GetPosition() == startPos);
                        AddBrick ab = new AddBrick(_akuTexture, brick);
                        _spriteObjects.Add(ab);
                        break;
                    }
                case OBJTYPES.SUBBRICK:
                    {
                        break;
                    }
            }
        }

        // Update all objects
        public void UpdateObjects(GameTime gameTime)
        {
            var spriteObjects = new List<SpriteObject>(_spriteObjects);
            foreach (SpriteObject sObj in spriteObjects)
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
