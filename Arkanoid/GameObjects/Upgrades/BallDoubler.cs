using Arkanoid.Components;
using Arkanoid.Core;
using Arkanoid.Events;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Arkanoid.GameObjects.Upgrades
{
    public class BallDoubler : GameObject
    {
        public BallDoubler(Vector2 position) : base("BallDoubler")
        {
            var texture = Engine.Instance.ContentManager.Load<Texture2D>("3block");
            AddComponent(new PositionComponent(position));
            AddComponent(new TextureComponent(texture, 4, 2));
            AddComponent(new FallComponent(20, -60));
            AddComponent(new TriggerComponent(4, 2,
                (a, b, contact) =>
                {
                    if (a.Name == "Paddle" || b.Name == "Paddle")
                    {
                        Engine.Instance.EventQueue.Enqueue(new BallDoubleEvent());
                        Engine.Instance.EventQueue.Enqueue(new DestroyEvent(this));
                    }
                }));
        }
    }
}