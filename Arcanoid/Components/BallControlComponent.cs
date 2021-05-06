using Arcanoid.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arcanoid.Components
{
    public class BallControlComponent : Component
    {
        private VelocityComponent _velocityComponent;
        private PositionComponent _positionComponent;
        private Vector2 _size;
        public override void Start(GameObject go)
        {
            _velocityComponent = go.GetComponent<VelocityComponent>();
            _positionComponent = go.GetComponent<PositionComponent>();
            _size = new Vector2(go.GetComponent<TextureComponent>().Texture.Width, go.GetComponent<TextureComponent>().Texture.Height);

        }
        public override void Update(GameObject go, float UpdateTime, KeyboardState kstate, GameWindow window, bool IsCollision)
        {
            if (kstate.IsKeyDown(Keys.Space) && _velocityComponent.Velocity.Y == 0)
            {
                _velocityComponent.Velocity = new Vector2(_velocityComponent.Velocity.X, 100);
                //return;
            }

            if (_positionComponent.Position.X + _size.X > window.ClientBounds.Width || _positionComponent.Position.X <= 0)
                _velocityComponent.Velocity = new Vector2(-_velocityComponent.Velocity.X, _velocityComponent.Velocity.Y);

            if (_positionComponent.Position.Y + _size.Y > window.ClientBounds.Height - 50 && IsCollision)
                _velocityComponent.Velocity = new Vector2(_velocityComponent.Velocity.X, -_velocityComponent.Velocity.Y);
            if(_positionComponent.Position.Y + _size.Y > window.ClientBounds.Height)
                {
                    _positionComponent.Position = new Vector2(window.ClientBounds.Width / 2, 50);
                    _velocityComponent.Velocity = new Vector2(0, 0);
                }


            if (_positionComponent.Position.Y < 0)
                _velocityComponent.Velocity = new Vector2(_velocityComponent.Velocity.X, -_velocityComponent.Velocity.Y);

            /*if (kstate.IsKeyDown(Keys.Space) && _velocityComponent.Velocity.Y == 100)
            {
                _velocityComponent.Velocity = new Vector2(0, 0);
                return;
            }*/

        }
    }
}
