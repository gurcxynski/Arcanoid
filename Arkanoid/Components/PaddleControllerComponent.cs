using Arkanoid.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Arkanoid.Components
{
    public class PaddleControllerComponent : Component
    {
        private BoxBodyComponent _bodyComponent;
        private readonly float _velocity;
        private readonly float _drag;

        public PaddleControllerComponent(float velocity, float drag)
        {
            _velocity = velocity;
            _drag = drag;
        }
        
        public override void Start(GameObject go)
        {
            _bodyComponent = go.GetComponent<BoxBodyComponent>();
        }
        
        public override void Update(GameObject go)
        {
            _bodyComponent.Body.LinearVelocity *= _drag;
            if (Engine.Instance.KeyboardState.IsKeyDown(Keys.D))
            {
                _bodyComponent.Body.ApplyForce(new Vector2(_velocity, 0));
            }
            if (Engine.Instance.KeyboardState.IsKeyDown(Keys.A))
            {
                _bodyComponent.Body.ApplyForce(new Vector2(-1 * _velocity, 0));
            }
        }
    }
}