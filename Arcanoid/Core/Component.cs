using Arcanoid.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Arcanoid.Core
{
    public class Component
    {
        public virtual void Update(GameObject go, float UpdateTime, KeyboardState kstate, GameWindow window, bool isCollision)
        {
            //go.GetComponent<PositionComponent>().Position += go.GetComponent<VelocityComponent>().Velocity * UpdateTime;
        }

        public virtual void Start(GameObject go)
        {
            
        }

        public virtual void Draw(GameObject go, SpriteBatch spriteBatch)
        {
            
        }
    }
}