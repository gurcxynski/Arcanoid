using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Arkanoid.Core;
using Arkanoid.Scenes;
using Microsoft.Xna.Framework.Input;
using tainicom.Aether.Physics2D.Diagnostics;
using tainicom.Aether.Physics2D.Dynamics;

namespace Arkanoid
{
    public class Arkanoid : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private BasicEffect _spriteBatchEffect;

        private SpriteFont _arial;
        
        private World _world;
        private DebugView _debugView;


        public Arkanoid()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.Title = "Arkanoid";
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 800;
            _graphics.ApplyChanges();
            _world = new World
            {
                Gravity = Vector2.One * -0.01f
            };

            _debugView = new DebugView(_world);
            _debugView.LoadContent(_graphics.GraphicsDevice, Content);
            _debugView.AppendFlags(DebugViewFlags.Shape);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _spriteBatchEffect = new BasicEffect(_graphics.GraphicsDevice) {TextureEnabled = true};

            Engine.Instance.Initialize(_world, _spriteBatch, Content);
            Engine.Instance.LoadScene(new GameScene());
            _arial = Content.Load<SpriteFont>("arial");
        }

        protected override void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();
            Engine.Instance.Update(gameTime, keyboardState);
            _world.Step((float)gameTime.ElapsedGameTime.TotalSeconds);
            
            _graphics.ApplyChanges();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Pink);
            var vp = GraphicsDevice.Viewport;
            _spriteBatchEffect.View = Matrix.CreateLookAt(Vector3.Zero, Vector3.Forward, Vector3.Up);
            _spriteBatchEffect.Projection = Matrix.CreateOrthographic(100, 100, 0f, -1f);
            
            _spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, RasterizerState.CullClockwise, _spriteBatchEffect);
            Engine.Instance.Scene.Draw();
            _spriteBatch.End();

            //_debugView.RenderDebugData(_spriteBatchEffect.Projection , _spriteBatchEffect.View);
            base.Draw(gameTime);
        }
    }
}
