using System;
using Arkanoid.Components;
using Arkanoid.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using tainicom.Aether.Physics2D.Dynamics;
using tainicom.Aether.Physics2D.Dynamics.Contacts;

namespace Arkanoid.GameObjects.Bricks
{
    public class Brick : GameObject
    {
        public Brick(Vector2 position) : base("Brick")
        {
            var texture = Engine.Instance.ContentManager.Load<Texture2D>("1block");

            var onDestroy = new Action<GameObject, GameObject, Contact>((a, b, contact) =>
            {
                Engine.Instance.Scene.RemoveGameObject(this);
            });

            AddComponent(new PositionComponent(position))
                .AddComponent(new TextureComponent(texture, 4, 2))
                .AddComponent(new BoxBodyComponent(4, 2, 1f, BodyType.Static))
                .AddComponent(new BrickDestroyComponent(onDestroy));
        }
    }
}