using Arkanoid.Components;
using Arkanoid.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using tainicom.Aether.Physics2D.Dynamics;

namespace Arkanoid.GameObjects.Bricks
{
    public class IndestructibleBrick : GameObject
    {
        public IndestructibleBrick(Vector2 position) : base("IndestructibleBrick")
        {
            var texture = Engine.Instance.ContentManager.Load<Texture2D>("2block");
            
            AddComponent(new PositionComponent(position))
                .AddComponent(new TextureComponent(texture, 4, 2))
                .AddComponent(new BoxBodyComponent(4, 2, 1f, BodyType.Static));
        }
    }
}