using Arcanoid.Core;
using Microsoft.Xna.Framework;

namespace Arcanoid.Components
{
    public class PositionComponent : Component
    {
        public Vector2 Position { get; set; } = new Vector2();
    }
}