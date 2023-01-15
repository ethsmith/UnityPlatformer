using System;
using api.entity;
using UnityEngine;

namespace game.@event.args
{
    public class EntityMoveEventArgs : EventArgs
    {
        public Pawn Pawn { get; set; }
        
        public Vector2 OldPosition { get; set; }
        
        public Vector2 NewPosition { get; set; }
    }
}