using Arcanoid.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

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

        public override void Update(GameObject go, float UpdateTime, KeyboardState kstate, GameWindow window, bool IsCollision)
        {
            _positionComponent.Position += Velocity * UpdateTime;
        }
    }
}