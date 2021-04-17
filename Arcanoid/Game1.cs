using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Arcanoid
{
    public class Ball
    {
        public Texture2D texture;
        Vector2 ballSpeed;
        public Vector2 position;
        public void setSpeed(Vector2 arg)
        {
            ballSpeed = arg;
        }
        public void setXSpeed(float arg)
        {
            ballSpeed.X = arg;
        }
        public void setYSpeed(float arg)
        {
            ballSpeed.Y = arg;
        }
        public Vector2 getSpeed()
        {
            return ballSpeed;
        }
    }

    public class Block
    {
        public Texture2D texture;
        public Vector2 position;
        public int row;
    }

    public class Plate
    {
        public Texture2D texture;
        public float position;
        public int speed;
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Ball gameBall;
        Plate gamePlate;
        const float ballSpeed = 150;
        SpriteFont arial;
        Random x = new Random();
        Block block1;
        Block block2;
        Block block3;
        Block block4;
        Block block5;
        Block block6;
        Block block7;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.Title = "Arcanoid";

            gameBall = new Ball();
            gamePlate = new Plate();
            block1 = new Block();
            block2 = new Block();
            block3 = new Block();
            block4 = new Block();
            block5 = new Block();
            block6 = new Block();
            block7 = new Block();

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


            _graphics.PreferredBackBufferWidth = 280;
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.ApplyChanges();

            gameBall.position = new Vector2(Window.ClientBounds.Width / 2 - 10, 100);

            gamePlate.position = Window.ClientBounds.Width / 2 - 45;

            gameBall.setYSpeed(0);


            gamePlate.speed = 300;

            block1.position = new Vector2(0, 0);
            block2.position = new Vector2(40, 0);
            block3.position = new Vector2(80, 0);
            block4.position = new Vector2(120, 0);
            block5.position = new Vector2(160, 0);
            block6.position = new Vector2(200, 0);
            block7.position = new Vector2(240, 0);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            gameBall.texture = Content.Load<Texture2D>("ball");
            gamePlate.texture = Content.Load<Texture2D>("plate");
            arial = Content.Load<SpriteFont>("arial");
            block1.texture = Content.Load<Texture2D>(x.Next(1, 4) + "block");
            block2.texture = Content.Load<Texture2D>(x.Next(1, 4) + "block");
            block3.texture = Content.Load<Texture2D>(x.Next(1, 4) + "block");
            block4.texture = Content.Load<Texture2D>(x.Next(1, 4) + "block");
            block5.texture = Content.Load<Texture2D>(x.Next(1, 4) + "block");
            block6.texture = Content.Load<Texture2D>(x.Next(1, 4) + "block");
            block7.texture = Content.Load<Texture2D>(x.Next(1, 4) + "block");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Space) && gameBall.getSpeed().Y == 0) gameBall.setYSpeed(ballSpeed);

            gameBall.position.Y += gameBall.getSpeed().Y * (float)gameTime.ElapsedGameTime.TotalSeconds;

            gameBall.position.X += gameBall.getSpeed().X * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Left))
                gamePlate.position -= gamePlate.speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Right))
                gamePlate.position += gamePlate.speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (gamePlate.position < 0) gamePlate.position = 0;

            if (gamePlate.position + gamePlate.texture.Width > Window.ClientBounds.Width) gamePlate.position = Window.ClientBounds.Width - gamePlate.texture.Width;

            if (gameBall.position.X < 0)
            {
                gameBall.position.X = 0;
                gameBall.setXSpeed(gameBall.getSpeed().X * -1);
            }
            if (gameBall.position.X + gameBall.texture.Width > Window.ClientBounds.Width)
            {
                gameBall.position.X = Window.ClientBounds.Width - gameBall.texture.Width;
                gameBall.setXSpeed(gameBall.getSpeed().X * -1);
            }



            if (gameBall.position.Y + gameBall.texture.Height > Window.ClientBounds.Height - 50)
                if (gameBall.position.X < (gamePlate.position + gamePlate.texture.Width) && (gameBall.position.X + gameBall.texture.Width) > gamePlate.position)
                {
                    gameBall.setYSpeed(-ballSpeed);

                    if (kstate.IsKeyDown(Keys.Left))
                        gameBall.setXSpeed(gameBall.getSpeed().X - 100);

                    if (kstate.IsKeyDown(Keys.Right))
                        gameBall.setXSpeed(gameBall.getSpeed().X + 100);

                }

            if (gameBall.position.Y + gameBall.texture.Height > Window.ClientBounds.Height)
            {
                gameBall.position = new Vector2(Window.ClientBounds.Width / 2, 100);
                gameBall.setYSpeed(0);
                gameBall.setXSpeed(0);
            }

            if (gameBall.position.Y < block1.texture.Height)
                gameBall.setYSpeed(ballSpeed);

            _graphics.ApplyChanges();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _spriteBatch.Draw(gameBall.texture, gameBall.position, Color.White);

            _spriteBatch.Draw(gamePlate.texture, new Vector2(gamePlate.position, Window.ClientBounds.Height - 50), Color.White);

           

            _spriteBatch.Draw(block1.texture, block1.position, Color.White);
            _spriteBatch.Draw(block2.texture, block2.position, Color.White);
            _spriteBatch.Draw(block3.texture, block3.position, Color.White);
            _spriteBatch.Draw(block4.texture, block4.position, Color.White);
            _spriteBatch.Draw(block5.texture, block5.position, Color.White);
            _spriteBatch.Draw(block6.texture, block6.position, Color.White);
            _spriteBatch.Draw(block7.texture, block7.position, Color.White);

            _spriteBatch.DrawString(arial, "y: " + (gameBall.getSpeed().Y).ToString(), new Vector2(0, 40), Color.White);

            _spriteBatch.DrawString(arial, "x: " + (gameBall.getSpeed().X).ToString(), new Vector2(0, 20), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
