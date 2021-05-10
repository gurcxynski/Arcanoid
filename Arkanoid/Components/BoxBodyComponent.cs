using Arkanoid.Core;
using Microsoft.Xna.Framework;
using tainicom.Aether.Physics2D.Dynamics;

namespace Arkanoid.Components
{
    public class BoxBodyComponent : BodyComponent
    {
        public BoxBodyComponent(float width, float height, float density, BodyType bodyType) : base(
            Engine.Instance.PhysicsWorld.CreateRectangle(width, height, density, Vector2.Zero, 0, bodyType))
        {
        }
    }
}