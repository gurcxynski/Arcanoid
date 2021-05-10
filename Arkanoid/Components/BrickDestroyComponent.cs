using System;
using Arkanoid.Core;
using Arkanoid.Events;
using tainicom.Aether.Physics2D.Dynamics;
using tainicom.Aether.Physics2D.Dynamics.Contacts;

namespace Arkanoid.Components
{
    public class BrickDestroyComponent : Component
    {
        private BoxBodyComponent _bodyComponent;
        private readonly Action<GameObject, GameObject, Contact> _onTrigger;
        private bool _isConsumed = false;

        public BrickDestroyComponent(Action<GameObject, GameObject, Contact> onTrigger)
        {
            _onTrigger = onTrigger;
        }

        public override void Start(GameObject go)
        {
            _bodyComponent = go.GetComponent<BoxBodyComponent>();
            _bodyComponent.Body.OnCollision += OnTrigger;
        }

        public override void Dispose()
        {
            _bodyComponent.Body.OnCollision -= OnTrigger;
        }

        public override void Update(GameObject go)
        {
            _isConsumed = false;
        }

        private bool OnTrigger(Fixture a, Fixture b, Contact contact)
        {
            if (_isConsumed) return true;
            Engine.Instance.EventQueue.Enqueue(new OnHitEvent(_onTrigger, a.Body.Tag as GameObject,
                b.Body.Tag as GameObject, contact));
            _isConsumed = true;

            return true;
        }
    }
}