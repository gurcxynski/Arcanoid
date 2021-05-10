using Arkanoid.Core;
using tainicom.Aether.Physics2D.Dynamics;

namespace Arkanoid.Components
{
    public abstract class BodyComponent : Component
    {
        public Body Body { get; }
        private PositionComponent _positionComponent;

        protected BodyComponent(Body body)
        {
            Body = body;
        }

        public override void Start(GameObject go)
        {
            _positionComponent = go.GetComponent<PositionComponent>();
            Body.Position = _positionComponent.Position;
            Body.Tag = go;
        }
        
        public override void Update(GameObject go)
        {
            _positionComponent.Position = Body.Position;
        }

        public BodyComponent FixedRotation()
        {
            Body.FixedRotation = true;
            return this;
        }

        public BodyComponent SetRestitution(float value)
        {
            Body.SetRestitution(value);
            return this;
        }

        public BodyComponent SetFriction(float value)
        {
            Body.SetFriction(value);
            return this;
        }

        public override void Dispose()
        {
            Body.Tag = null;
            Engine.Instance.PhysicsWorld.Remove(Body);
        }

        public BodyComponent SetBullet(bool value)
        {
            Body.IsBullet = value;
            return this;
        }
    }
}