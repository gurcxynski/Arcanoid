using Arcanoid.Components;
using Arcanoid.Core;
using Microsoft.Xna.Framework.Graphics;

namespace Arcanoid.GameObjects
{
    public class Ball : GameObject
    {
        public Ball(Texture2D texture)
        {
            AddComponent(new PositionComponent())
                .AddComponent(new TextureComponent(texture))
                .AddComponent(new VelocityComponent());
        }
    }
}