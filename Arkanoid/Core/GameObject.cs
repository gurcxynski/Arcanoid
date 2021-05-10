using System;
using System.Collections.Generic;
using System.Linq;

namespace Arkanoid.Core
{
    public class GameObject
    {
        private static int _nextId = 0;
        private readonly List<Component> _components = new List<Component>();
        public readonly string Name;
        public readonly int Id;

        public GameObject(string name)
        {
            Name = name;
            Id = _nextId;
            _nextId++;
        }

        public GameObject AddComponent(Component comp)
        {
            _components.Add(comp);
            return this;
        }

        public void Update()
        {
            foreach (var component in _components)
            {
                component.Update(this);
            }
        }

        public void Start()
        {
            foreach (var component in _components)
            {
                component.Start(this);
            }
        }

        public void Draw()
        {
            foreach (var component in _components)
            {
                component.Draw(this);
            }
        }

        public T GetComponent<T>() where T : Component
        {
            foreach (var component in _components.Where(component => component.GetType() == typeof(T)))
            {
                return component as T;
            }

            throw new Exception("No component found");
        }

        public void Dispose()
        {
            foreach (var component in _components)
            {
                component.Dispose();
            }
        }
    }
}