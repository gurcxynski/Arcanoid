using Arkanoid.Core;
using Microsoft.Xna.Framework;
using tainicom.Aether.Physics2D.Dynamics;

namespace Arkanoid.Components
{
    public class CircleBodyComponent : BodyComponent
    {
        public CircleBodyComponent(float radius, float density, BodyType bodyType) : base(
            Engine.Instance.PhysicsWorld.CreateCircle(radius, density, Vector2.Zero, bodyType))
        {
        }
    }
}