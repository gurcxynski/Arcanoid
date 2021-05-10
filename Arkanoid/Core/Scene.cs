using System;
using System.Collections.Generic;
using System.Linq;

namespace Arkanoid.Core
{
    public class Scene
    {
        private readonly Dictionary<int, GameObject> _gameObjects = new Dictionary<int, GameObject>();

        public Scene AddGameObject(GameObject go)
        {
            _gameObjects.Add(go.Id, go);
            go.Start();
            return this;
        }


        public void Update()
        {
            foreach (var gameObject in _gameObjects)
            {
                gameObject.Value.Update();
            }
        }

        public virtual void Start()
        {
            foreach (var gameObject in _gameObjects)
            {
            }
        }

        public void Draw()
        {
            foreach (var gameObject in _gameObjects)
            {
                gameObject.Value.Draw();
            }
        }

        public void DisposeAll()
        {
            foreach (var gameObject in _gameObjects)
            {
                gameObject.Value.Dispose();
            }
        }

        public void RemoveGameObject(GameObject go)
        {
            go.Dispose();
            if (!_gameObjects.Remove(go.Id))
            {
                throw new Exception("Cant remove GO");
            }
        }

        public List<T> FindOfType<T>() where T : GameObject
        {
            return _gameObjects.Values.Where(go => go.GetType() == typeof(T)).Select(go => (T) go).ToList();
        }
    }
}