using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Arcanoid.Core
{
    public class Scene
    {
        private readonly List<GameObject> _gameObjects = new List<GameObject>();
        private CollisionChecker _CollisionChecker;

        public GameObject AddGameObject(GameObject go)
        {
            _gameObjects.Add(go);
            return go;
        }
            
        public void AddCollision(GameObject ball, GameObject palette)
        {
            _CollisionChecker = new CollisionChecker(ball, palette);
        }
        public void Update(float UpdateTime, KeyboardState kstate, GameWindow window)
        {
            bool IsCollision = _CollisionChecker.Collision();
            foreach (var gameObject in _gameObjects)
            {
                gameObject.Update(UpdateTime, kstate, window, IsCollision);
            }
        }

        public void Start()
        {
            foreach (var gameObject in _gameObjects)
            {
                gameObject.Start();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var gameObject in _gameObjects)
            {
                gameObject.Draw(spriteBatch);
            }
        }

    }
}