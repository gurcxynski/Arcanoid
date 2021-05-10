using Arkanoid.Core;
using Microsoft.Xna.Framework;

namespace Arkanoid.Components
{
    public class PositionComponent : Component
    {
        public Vector2 Position;

        public PositionComponent(Vector2 position)
        {
            Position = position;
        }
        
        public PositionComponent(float x, float y)
        {
            Position = new Vector2(x, y);
        }
    }
}