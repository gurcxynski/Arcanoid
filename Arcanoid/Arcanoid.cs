using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Arcanoid
{
    public class Component
    {

    }
    public class Position : Component
    {
        public Vector2 position;

        public Position()
        {
            position = new Vector2();
        }
        public Vector2 GetPosition()
        {
            return position;
        }
    }
    public class Texture : Component
    {
        public Texture2D texture;

        public Texture()
        {

        }

        public Texture(Texture2D texture)
        {
            this.texture = texture;
        }
    }
    public class GameObject
    {
        public Dictionary<string, Component> components;
        public GameObject()
        {
            components = new Dictionary<string, Component>();
            components.Add("position", new Position());
            components.Add("texture", new Texture());
        }
    }
    public class Ball : GameObject
    {
        Vector2 speed;
        public void setSpeed(Vector2 arg)
        {
            speed = arg;
        }
        public void setXSpeed(float arg)
        {
            speed.X = arg;
        }
        public void setYSpeed(float arg)
        {
            speed.Y = arg;
        }
        public Vector2 getSpeed()
        {
            return speed;
        }
    }


    public class Plate : GameObject
    {
        public int speed;
    }

    public class Arcanoid : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Dictionary<string, GameObject> objectList;
        const float ballSpeed = 150;
        SpriteFont arial;
        public Arcanoid()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.Title = "Arcanoid";

            objectList = new Dictionary<string, GameObject>();
            objectList.Add("ball", new Ball());
            objectList.Add("plate", new Plate());

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


            _graphics.PreferredBackBufferWidth = 280;
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.ApplyChanges();

            gameBall.position = new Vector2(Window.ClientBounds.Width / 2 - 10, 100);

            gamePlate.position = new Vector2(Window.ClientBounds.Width / 2 - 45, Window.ClientBounds.Height - 50);

            gameBall.setYSpeed(0);


            gamePlate.speed = 300;


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            objectList["ball"].components["texture"] = new Texture(Content.Load<Texture2D>("ball"));
            objectList["plate"].components["texture"] = new Texture(Content.Load<Texture2D>("plate"));
            arial = Content.Load<SpriteFont>("arial");

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
                gamePlate.position.X -= gamePlate.speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Right))
                gamePlate.position.X += gamePlate.speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (gamePlate.position.X < 0) gamePlate.position.X = 0;

            if (gamePlate.position.X + gamePlate.texture.Width > Window.ClientBounds.Width) gamePlate.position.X = Window.ClientBounds.Width - gamePlate.texture.Width;

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



            if (gameBall.position.Y + gameBall.texture.Height > gamePlate.position.Y)
                if (gameBall.position.X < (gamePlate.position.X + gamePlate.texture.Width) && (gameBall.position.X + gameBall.texture.Width) > gamePlate.position.X)
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

            _spriteBatch.Draw(objectList["ball"].components["texture"], gameBall.position, Color.White);

            _spriteBatch.Draw(objectList["plate"].components["texture"], objectList["ball"].components["position"], Color.White);
        
            _spriteBatch.DrawString(arial, "y: " + (gameBall.getSpeed().Y).ToString(), new Vector2(0, 40), Color.White);

            _spriteBatch.DrawString(arial, "x: " + (gameBall.getSpeed().X).ToString(), new Vector2(0, 20), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
