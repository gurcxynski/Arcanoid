using System;
using Arkanoid.Components;
using Arkanoid.Core;
using Arkanoid.GameObjects;
using Microsoft.Xna.Framework;

namespace Arkanoid.Events
{
    public class BallDoubleEvent : Event
    {
        public override void Execute()
        {
            Engine.Instance.Scene.FindOfType<Ball>().ForEach(ball =>
            {
                var random = new Random();
                Engine.Instance.Scene.AddGameObject(new Ball(ball.GetComponent<PositionComponent>().Position,
                    new Vector2((float) random.NextDouble() - 0.5f, (float) random.NextDouble() - 0.5f)));
            });
        }
    }
}