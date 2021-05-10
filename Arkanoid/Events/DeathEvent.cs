using System.Linq;
using Arkanoid.Core;
using Arkanoid.GameObjects;
using Arkanoid.Scenes;

namespace Arkanoid.Events
{
    public class DeathEvent : Event
    {
        private readonly GameObject _a;
        private readonly GameObject _b;

        public DeathEvent(GameObject a, GameObject b)
        {
            _a = a;
            _b = b;
        }

        public override void Execute()
        {
            if (_a.Name == "Ball")
            {
                Engine.Instance.Scene.RemoveGameObject(_a);
            } 
            if (_b.Name == "Ball")
            {
                Engine.Instance.Scene.RemoveGameObject(_b);
            }

            if (!Engine.Instance.Scene.FindOfType<Ball>().Any())
            {
                Engine.Instance.LoadScene(new GameScene());
            }
        }
    }
}