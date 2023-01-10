using System;
using api.entity;

namespace game.@event
{
    public class EntitySpawnEventArgs : EventArgs
    {
        public Pawn Pawn { get; set; }
    }
}