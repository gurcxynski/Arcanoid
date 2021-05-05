using Arcanoid.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Arcanoid.Core;
using Arcanoid.GameObjects;
using Microsoft.Xna.Framework.Input;

namespace Arcanoid
{
    public class Arcanoid : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private SpriteFont _arial;
        
        private Scene _scene = new Scene();
        
        
        public Arcanoid()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.Title = "Arcanoid";
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 280;
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.ApplyChanges();
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            var ball = new Ball(Content.Load<Texture2D>("ball"));

            ball.GetComponent<VelocityComponent>().Velocity = new Vector2(1, 1);
            
            _scene.AddGameObject(ball);
            
            _arial = Content.Load<SpriteFont>("arial");
            
            _scene.Start();
        }

        protected override void Update(GameTime gameTime)
        {
            var kstate = Keyboard.GetState();
            _scene.Update();
//            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
//                Exit();
//
//            // TODO: Add your update logic here
//
//            
//
//            if (kstate.IsKeyDown(Keys.Space) && gameBall.getSpeed().Y == 0) gameBall.setYSpeed(ballSpeed);
//
//            gameBall.position.Y += gameBall.getSpeed().Y * (float)gameTime.ElapsedGameTime.TotalSeconds;
//
//            gameBall.position.X += gameBall.getSpeed().X * (float)gameTime.ElapsedGameTime.TotalSeconds;
//
//            if (kstate.IsKeyDown(Keys.Left))
//                gamePlate.position.X -= gamePlate.speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
//
//            if (kstate.IsKeyDown(Keys.Right))
//                gamePlate.position.X += gamePlate.speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
//
//            if (gamePlate.position.X < 0) gamePlate.position.X = 0;
//
//            if (gamePlate.position.X + gamePlate.texture.Width > Window.ClientBounds.Width) gamePlate.position.X = Window.ClientBounds.Width - gamePlate.texture.Width;
//
//            if (gameBall.position.X < 0)
//            {
//                gameBall.position.X = 0;
//                gameBall.setXSpeed(gameBall.getSpeed().X * -1);
//            }
//            if (gameBall.position.X + gameBall.texture.Width > Window.ClientBounds.Width)
//            {
//                gameBall.position.X = Window.ClientBounds.Width - gameBall.texture.Width;
//                gameBall.setXSpeed(gameBall.getSpeed().X * -1);
//            }
//
//
//
//            if (gameBall.position.Y + gameBall.texture.Height > gamePlate.position.Y)
//                if (gameBall.position.X < (gamePlate.position.X + gamePlate.texture.Width) && (gameBall.position.X + gameBall.texture.Width) > gamePlate.position.X)
//                {
//                    gameBall.setYSpeed(-ballSpeed);
//
//                    if (kstate.IsKeyDown(Keys.Left))
//                        gameBall.setXSpeed(gameBall.getSpeed().X - 100);
//
//                    if (kstate.IsKeyDown(Keys.Right))
//                        gameBall.setXSpeed(gameBall.getSpeed().X + 100);
//
//                }
//
//            if (gameBall.position.Y + gameBall.texture.Height > Window.ClientBounds.Height)
//            {
//                gameBall.position = new Vector2(Window.ClientBounds.Width / 2, 100);
//                gameBall.setYSpeed(0);
//                gameBall.setXSpeed(0);
//            }
//
//            if (gameBall.position.Y < block1.texture.Height)
//                gameBall.setYSpeed(ballSpeed);
//
            _graphics.ApplyChanges();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            
            _scene.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
