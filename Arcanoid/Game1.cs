using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Arcanoid
{
    public class Ball
    {
        public Texture2D texture;
        float ballSpeed;
        public Vector2 position;
        public void setSpeed(float arg)
        {
            ballSpeed = arg;
        }
        public float getSpeed()
        {
            return ballSpeed;
        }
    }

    public class Block
    {
        Texture2D texture;
        Vector2 position;
        int row;
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
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.Title = "Arcanoid";

            gameBall = new Ball();
            gamePlate = new Plate();

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


            _graphics.PreferredBackBufferWidth = 300;
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.ApplyChanges();

            gameBall.position = new Vector2(Window.ClientBounds.Width / 2, 0);

            gamePlate.position = Window.ClientBounds.Width / 2;

            gameBall.setSpeed(ballSpeed);

            gamePlate.speed = 300;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            gameBall.texture = Content.Load<Texture2D>("ball");
            gamePlate.texture = Content.Load<Texture2D>("plate");
            arial = Content.Load<SpriteFont>("arial");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            var kstate = Keyboard.GetState();

            gameBall.position.Y += gameBall.getSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Left))
                gamePlate.position -= gamePlate.speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Right))
                gamePlate.position += gamePlate.speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (gamePlate.position < 0) gamePlate.position = 0;

            if (gamePlate.position + gamePlate.texture.Width > Window.ClientBounds.Width) gamePlate.position = Window.ClientBounds.Width - gamePlate.texture.Width;


            if (gameBall.position.Y + gameBall.texture.Height > Window.ClientBounds.Height - 50)
                if(gameBall.position.X < (gamePlate.position + gamePlate.texture.Width) && (gameBall.position.X + gameBall.texture.Width) > gamePlate.position)
                    gameBall.setSpeed(-ballSpeed);
                else
                {
                    gameBall.position = new Vector2(Window.ClientBounds.Width / 2, 0);
                    gameBall.setSpeed(ballSpeed);
                }

            if (gameBall.position.Y < 0)
                gameBall.setSpeed(ballSpeed);

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

            _spriteBatch.DrawString(arial, ((int)gameBall.position.Y).ToString(), new Vector2(0, 0), Color.White);

            _spriteBatch.DrawString(arial, (gameBall.getSpeed()).ToString(), new Vector2(0, 20), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
