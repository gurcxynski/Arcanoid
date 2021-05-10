using Arkanoid.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Arkanoid.Components
{
    public class TextureComponent : Component
    {
        private Texture2D Texture { get; }
        private float Width { get; }
        private float Height { get; }

        private PositionComponent _positionComponent;

        public TextureComponent(Texture2D texture, float width, float height)
        {
            Texture = texture;
            Width = width;
            Height = height;
        }

        public override void Start(GameObject go)
        {
            _positionComponent = go.GetComponent<PositionComponent>();
        }

        public override void Draw(GameObject go)
        {
            var posX = _positionComponent.Position.X - Width / 2f;
            var posY = _positionComponent.Position.Y - Height / 2f;
            var scaleX = Width / Texture.Width ;
            var scaleY = Height / Texture.Height;
            var position = new Vector2(posX, posY);
            var scale = new Vector2(scaleX, scaleY);

            Engine.Instance.SpriteBatch.Draw(Texture, position, null, Color.White, 0, Vector2.Zero, scale,
                SpriteEffects.None, 0);
        }
    }
}