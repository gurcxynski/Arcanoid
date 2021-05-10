using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using tainicom.Aether.Physics2D.Dynamics;

namespace Arkanoid.Core
{
    public sealed class Engine
    {
        private static Engine _instance;
        
        public World PhysicsWorld { get; private set; }
        public SpriteBatch SpriteBatch { get; private set; }
        public ContentManager ContentManager { get; private set; }
        public Scene Scene { get; private set; }
        public GameTime GameTime { get; private set; }
        public KeyboardState KeyboardState { get; private set; }

        public readonly EventQueue EventQueue = new EventQueue();

        public static Engine Instance
        {
            get { return _instance ??= new Engine(); }
        }

        public void Initialize(World world, SpriteBatch spriteBatch, ContentManager contentManager)
        {
            PhysicsWorld = world;
            SpriteBatch = spriteBatch;
            ContentManager = contentManager;
        }

        public void LoadScene(Scene scene)
        {
            Scene?.DisposeAll();
            Scene = scene;
            Scene.Start();
        }

        public void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            GameTime = gameTime;
            KeyboardState = keyboardState;
            Scene.Update();
            EventQueue.ExecuteQueue();
        }
    }
}