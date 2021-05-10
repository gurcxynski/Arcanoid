using System;
using Arkanoid.Core;
using Arkanoid.GameObjects;
using Arkanoid.GameObjects.Bricks;
using Microsoft.Xna.Framework;

namespace Arkanoid.Scenes
{
    public class GameScene : Scene
    {
        public override void Start()
        {
            AddGameObject(new Ball(new Vector2(0, -30), new Vector2((float) new Random().NextDouble() * 2 - 1, 1)));
            AddGameObject(new Paddle(new Vector2(0, -45)));
            AddGameObject(new StaticBlock(-95, 0, 100, 300));
            AddGameObject(new StaticBlock(95, 0, 100, 300));
            AddGameObject(new StaticBlock(0, 95, 300, 100));
            AddGameObject(new DeathPlane(0, -95, 300, 100));


            //for (var y = 0; y < 5; y++)
            //{
            //    for (var x = 0; x < 5; x++)
            //    {
            //        var posX = x * 8.5f - 8 * 4.5f;
            //        var posY = 40 - y * 6.5f;
            //        AddGameObject(new BonusBrick(new Vector2(posX, posY)));
            //    }
            //}
            for (var y = 0; y < 12; y++)
            {
                for (var x = 0; x < 17; x++)
                {
                    var posX = x * 4.5f - 8 * 4.5f;
                    var posY = 40 - y * 2.5f;
                    if ((x + y) % 10 == 0)
                    {
                        AddGameObject(new BonusBrick(new Vector2(posX, posY)));
                    }
                    else if (y == 3)
                    {
                        AddGameObject(new IndestructibleBrick(new Vector2(posX, posY)));
                    }
                    else
                    {
                        AddGameObject(new Brick(new Vector2(posX, posY)));
                    }
                }
            }

            base.Start();
        }
    }
}