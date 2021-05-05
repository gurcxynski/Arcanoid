using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Arcanoid.Core
{
    public class Scene
    {
        private readonly List<GameObject> _gameObjects = new List<GameObject>();

        public Scene AddGameObject(GameObject go)
        {
            _gameObjects.Add(go);
            return this;
        }
        
        
        public void Update()
        {
            foreach (var gameObject in _gameObjects)
            {
                gameObject.Update();
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