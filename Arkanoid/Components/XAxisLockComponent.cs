using Arkanoid.Core;
using Microsoft.Xna.Framework;

namespace Arkanoid.Components
{
    public class XAxisLockComponent : Component
    {
        
        private BoxBodyComponent _bodyComponent;
        private float _yPosition;
        
        public override void Start(GameObject go)
        {
            _bodyComponent = go.GetComponent<BoxBodyComponent>();
            _yPosition = go.GetComponent<PositionComponent>().Position.Y;
        }

        public override void Update(GameObject go)
        {
            _bodyComponent.Body.Position = new Vector2(_bodyComponent.Body.Position.X, _yPosition);
            _bodyComponent.Body.LinearVelocity = new Vector2(_bodyComponent.Body.LinearVelocity.X, 0);
        }
    }
}