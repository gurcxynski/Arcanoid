using Arcanoid.Components;
using Arcanoid.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arcanoid.GameObjects
{
    class Palette : GameObject
    {

        public Palette(Texture2D texture)
        {
            AddComponent(new PositionComponent());
            AddComponent(new TextureComponent(texture));
            AddComponent(new VelocityComponent());
            AddComponent(new PaletteControlComponent());
        }

    }
}
