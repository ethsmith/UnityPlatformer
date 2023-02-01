using System;

namespace api.@event
{
    public interface IEventListener
    {
        public IEvent GetEvent();
        
        public void OnFire(object sender, EventArgs args);
    }
}