using System.Collections.Generic;

namespace Arkanoid.Core
{
    public class EventQueue
    {
        private readonly Queue<Event> _events = new Queue<Event>();

        public void Enqueue(Event @event)
        {
            _events.Enqueue(@event);
        }

        public void ExecuteQueue()
        {
            while (_events.Count > 0)
            {
                var @event = _events.Dequeue();
                @event.Execute();
            }
        }
        
    }
}