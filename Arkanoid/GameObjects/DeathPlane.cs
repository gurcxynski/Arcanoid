using Arkanoid.Components;
using Arkanoid.Core;
using Arkanoid.Events;

namespace Arkanoid.GameObjects
{
    public class DeathPlane : GameObject
    {
        public DeathPlane(float x, float y, float width, float height) : base("DeathPlane")
        {
            AddComponent(new PositionComponent(x, y));
            AddComponent(new TriggerComponent(width, height,
                (a, b, contact) =>
                {
                    Engine.Instance.EventQueue.Enqueue(new DeathEvent(a, b));
                }));
        }
    }
}