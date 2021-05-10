using Arkanoid.Core;

namespace Arkanoid.Events
{
    public class SpawnEvent : Event
    {
        private readonly GameObject _toSpawn;

        public SpawnEvent(GameObject toSpawn)
        {
            _toSpawn = toSpawn;
        }

        public override void Execute()
        {
            Engine.Instance.Scene.AddGameObject(_toSpawn);
        }
    }
}