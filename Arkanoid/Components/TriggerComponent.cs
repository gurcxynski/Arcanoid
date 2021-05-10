using System;
using Arkanoid.Core;
using Microsoft.Xna.Framework;
using tainicom.Aether.Physics2D.Dynamics;
using tainicom.Aether.Physics2D.Dynamics.Contacts;

namespace Arkanoid.Components
{
    public class TriggerComponent : Component
    {
        public Body Body { get; }
        private PositionComponent _positionComponent;
        private readonly Action<GameObject, GameObject, Contact> _onTrigger;
        private bool _isConsumed = false;

        public TriggerComponent(float width, float height, Action<GameObject, GameObject, Contact> onTrigger )
        {
            _onTrigger = onTrigger;
            Body = Engine.Instance.PhysicsWorld.CreateRectangle(width, height, 1, Vector2.Zero);
            Body.SetIsSensor(true);
        }

        public override void Start(GameObject go)
        {
            _positionComponent = go.GetComponent<PositionComponent>();
            Body.Position = _positionComponent.Position;
            Body.Tag = go;
            Body.OnCollision += OnTrigger;
        }
        
        public override void Update(GameObject go)
        {
            _isConsumed = false;
            Body.Position = _positionComponent.Position;
        }

        private bool OnTrigger(Fixture a, Fixture b, Contact contact)
        {
            if (_isConsumed) return true;
            _onTrigger(a.Body.Tag as GameObject, b.Body.Tag as GameObject, contact);
            _isConsumed = true;

            return true;
        }
        
        public override void Dispose()
        {
            Body.Tag = null;
            Engine.Instance.PhysicsWorld.Remove(Body);
        }
    }
}