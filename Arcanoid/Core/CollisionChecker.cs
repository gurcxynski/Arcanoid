using Arcanoid.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arcanoid.Core
{
    class CollisionChecker
    {
        private GameObject Ball;
        private GameObject Palette;

        public CollisionChecker(GameObject ball, GameObject palette)
        {
            Ball = ball;
            Palette = palette;
        }
        public bool Collision()
        {
            Vector2 BallPosition = Ball.GetComponent<PositionComponent>().Position;
            Vector2 PalettePosition = Palette.GetComponent<PositionComponent>().Position;
            Vector2 BallSize = new Vector2(Ball.GetComponent<TextureComponent>().Texture.Width, Ball.GetComponent<TextureComponent>().Texture.Height);
            Vector2 PaletteSize = new Vector2(Palette.GetComponent<TextureComponent>().Texture.Width, Palette.GetComponent<TextureComponent>().Texture.Height);
            return (BallPosition.X + BallSize.X > PalettePosition.X && BallPosition.X < PalettePosition.X + PaletteSize.X);
        }
    }
}
