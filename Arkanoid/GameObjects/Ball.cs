using Arkanoid.Components;
using Arkanoid.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using tainicom.Aether.Physics2D.Dynamics;

namespace Arkanoid.GameObjects
{
    public class Ball : GameObject
    {
        public Ball(Vector2 position, Vector2 velocity) : base("Ball")
        {
            var texture = Engine.Instance.ContentManager.Load<Texture2D>("ball");
            var bodyComponent = new CircleBodyComponent(1, 1, BodyType.Dynamic).SetBullet(true);
            AddComponent(new PositionComponent(position))
                .AddComponent(new TextureComponent(texture, 2, 2))
                .AddComponent(bodyComponent)
                .AddComponent(new ConstantVelocityComponent(65f));

            bodyComponent.Body.LinearVelocity = velocity;
            bodyComponent.SetRestitution(1);
        }
    }
}