using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Arcanoid.Core
{
    public class GameObject
    {
        private readonly List<Component> _components = new List<Component>();

        public GameObject AddComponent(Component comp)
        {
            _components.Add(comp);
            return this;
        }
        
        public void Update(float UpdateTime, KeyboardState kstate, GameWindow window, bool IsCollision)
        {
            foreach (var component in _components)
            {
                component.Update(this, UpdateTime, kstate, window, IsCollision);
            }
        }

        public void Start()
        {
            foreach (var component in _components)
            {
                component.Start(this);
            }
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var component in _components)
            {
                component.Draw(this, spriteBatch);
            }
            
        }

        public T GetComponent<T>() where T: Component
        {
            foreach (var component in _components)
            {
                if(component.GetType() == typeof(T))
                {
                    return component as T;
                }
            }
            return null;
        }
    }
}