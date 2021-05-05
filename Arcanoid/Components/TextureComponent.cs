using Arcanoid.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Arcanoid.Components
{
    public class TextureComponent : Component
    {
        private PositionComponent _positionComponent;
        public TextureComponent(Texture2D texture)
        {
            Texture = texture;
        }

        public override void Start(GameObject go)
        {
            _positionComponent = go.GetComponent<PositionComponent>();
        }

        public override void Draw(GameObject go, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, _positionComponent.Position , Color.White);
        }

        public Texture2D Texture { get; }
    }
}