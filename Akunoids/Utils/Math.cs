using Akunoids.Objects;
using Microsoft.Xna.Framework;


namespace Akunoids.Utils
{
    public static class Math
    {
        public static SpriteObject AccelerateObject(SpriteObject obj, float acceleration, float dt)
        {
            var x = obj.GetPosition().X;
            var y = obj.GetPosition().Y;
            var dx = obj.GetVelocity().X;
            var dy = obj.GetVelocity().Y;
            var x2 = x + (dt * dx) + (acceleration * dt * dt * 0.5f);
            var y2 = y + (dt * y) + (acceleration * dt * dt * 0.5f);
            var dx2 = dx + (acceleration * dt) * (dx > 0 ? 1 : -1);
            var dy2 = dy + (acceleration * dt) * (dy > 0 ? 1 : -1);
            var newObj = new SpriteObject();
            newObj.SetPosition(new Vector2(x2 - x, y2 - y));
            newObj.SetVelocity(dx2, dy2);
            newObj.SetStartPosition(new Vector2(x2, y2));
            return newObj; // need to return a position and velocity (not really a whole new sprite object)

        }
    }
}
