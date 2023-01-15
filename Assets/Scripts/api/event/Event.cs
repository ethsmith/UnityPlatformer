using System;

namespace api.@event
{
    public interface IEvent
    {
        public void Fire();

        public bool IsCancellable();
        
        public bool IsCancelled();
        
        public void SetCancelled(bool cancelled);
    }
}