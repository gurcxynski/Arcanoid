using Arkanoid.Components;
using Arkanoid.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using tainicom.Aether.Physics2D.Dynamics;

namespace Arkanoid.GameObjects
{
    public class Paddle : GameObject
    {
        public Paddle(Vector2 position): base("Paddle")
        {
            var texture = Engine.Instance.ContentManager.Load<Texture2D>("plate");
            AddComponent(new PositionComponent(position));
            AddComponent(new TextureComponent(texture, 10, 2));
            AddComponent(new BoxBodyComponent(10f, 2f, 1f, BodyType.Dynamic).FixedRotation().SetBullet(true));
            AddComponent(new PaddleControllerComponent(8500, 0.90f));
            AddComponent(new XAxisLockComponent());
        }
    }
}