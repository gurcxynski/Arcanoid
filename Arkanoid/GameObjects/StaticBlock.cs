using Arkanoid.Components;
using Arkanoid.Core;
using Microsoft.Xna.Framework.Graphics;
using tainicom.Aether.Physics2D.Dynamics;

namespace Arkanoid.GameObjects
{
    public class StaticBlock : GameObject
    {
        public StaticBlock(float x, float y, float width, float height): base("StaticBlock")
        {
            var texture = Engine.Instance.ContentManager.Load<Texture2D>("plate");
            AddComponent(new PositionComponent(x, y));
            var boxBodyComponent = new BoxBodyComponent(width, height, 1f, BodyType.Static);
            boxBodyComponent.SetFriction(0);
            AddComponent(boxBodyComponent);
            AddComponent(new TextureComponent(texture, width, height));
        }
    }
}