using Arkanoid.Core;

namespace Arkanoid.Components
{
    public class ConstantVelocityComponent : Component
    {
        private CircleBodyComponent _bodyComponent;
        private readonly float _velocity;

        public ConstantVelocityComponent(float velocity)
        {
            _velocity = velocity;
        }

        public override void Start(GameObject go)
        {
            _bodyComponent = go.GetComponent<CircleBodyComponent>();
        }

        public override void Update(GameObject go)
        {
            _bodyComponent.Body.LinearVelocity *= _velocity / _bodyComponent.Body.LinearVelocity.Length();
        }
    }
}