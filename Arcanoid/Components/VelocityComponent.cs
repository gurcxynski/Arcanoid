using Arcanoid.Core;
using Microsoft.Xna.Framework;

namespace Arcanoid.Components
{
    public class VelocityComponent : Component
    {
        private PositionComponent _positionComponent;

        public Vector2 Velocity { get; set; } = new Vector2(0, 0);

        public override void Start(GameObject go)
        {
            _positionComponent = go.GetComponent<PositionComponent>();
        }

        public override void Update(GameObject go)
        {
            _positionComponent.Position += Velocity;
        }
    }
}