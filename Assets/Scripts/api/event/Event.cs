using System;

namespace api.@event
{
    public interface IEvent
    {
        public void Fire();
        
        public void OnComplete(EventArgs e);
    }
}