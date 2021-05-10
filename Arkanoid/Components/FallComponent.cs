using Arkanoid.Core;
using Arkanoid.Events;

namespace Arkanoid.Components
{
    public class FallComponent : Component
    {
        private readonly float _fallSpeed;
        private readonly float _killLimit;

        private PositionComponent _positionComponent;

        public FallComponent(float fallSpeed, float killLimit)
        {
            _fallSpeed = fallSpeed;
            _killLimit = killLimit;
        }

        public override void Start(GameObject go)
        {
            _positionComponent = go.GetComponent<PositionComponent>();
        }

        public override void Update(GameObject go)
        {
            _positionComponent.Position.Y -= _fallSpeed * Engine.Instance.GameTime.ElapsedGameTime.Milliseconds / 1000f;
            if (_positionComponent.Position.Y < _killLimit)
            {
                Engine.Instance.EventQueue.Enqueue(new DestroyEvent(go));
            }
        }
    }
}