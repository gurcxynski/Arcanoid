using System;
using Arkanoid.Core;
using tainicom.Aether.Physics2D.Dynamics.Contacts;

namespace Arkanoid.Events
{
    public class OnHitEvent : Event
    {
        private readonly GameObject _a;
        private readonly GameObject _b;
        private readonly Contact _contact;
        private readonly Action<GameObject, GameObject, Contact> _onTrigger;

        public OnHitEvent(Action<GameObject, GameObject, Contact> onTrigger, GameObject a, GameObject b,
            Contact contact)
        {
            _onTrigger = onTrigger;
            _a = a;
            _b = b;
            _contact = contact;
        }

        public override void Execute()
        {
            _onTrigger(_a, _b, _contact);
        }
    }
}