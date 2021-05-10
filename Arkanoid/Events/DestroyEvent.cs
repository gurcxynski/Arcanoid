using Arkanoid.Core;

namespace Arkanoid.Events
{
    public class DestroyEvent : Event
    {
        private readonly GameObject _toDestroy;

        public DestroyEvent(GameObject toDestroy)
        {
            _toDestroy = toDestroy;
        }

        public override void Execute()
        {
            Engine.Instance.Scene.RemoveGameObject(_toDestroy);
        }
    }
}