using System;
using api.entity;

namespace game.@event.args
{
    public class EntitySpawnEventArgs : EventArgs
    {
        public Pawn Pawn { get; set; }
    }
}