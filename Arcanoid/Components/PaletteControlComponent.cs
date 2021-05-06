using Arcanoid.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arcanoid.Components
{
    public class PaletteControlComponent : Component
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
            if (kstate.IsKeyDown(Keys.Left))
                _velocityComponent.Velocity = new Vector2(-100, 0);
            if (kstate.IsKeyDown(Keys.Right))
                _velocityComponent.Velocity = new Vector2(100, 0);
            if (_positionComponent.Position.X + _size.X >= window.ClientBounds.Width)
                _velocityComponent.Velocity = new Vector2(-100, 0);
            if(_positionComponent.Position.X <= 0)
                _velocityComponent.Velocity = new Vector2(100, 0);
        }
    }
}
