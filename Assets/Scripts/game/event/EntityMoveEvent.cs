using System;
using api.entity;
using game.controller;
using game.entity;
using game.@event.args;
using UnityEngine;

namespace game.@event
{
    public class EntityMoveEvent : api.@event.IEvent
    {
        public event EventHandler<EntityMoveEventArgs> OnEntityMove; 
        
        private readonly Pawn _pawn;
        
        private readonly Vector2 _oldPosition;
        
        private readonly Vector2 _newPosition;
        
        private bool _isCancelled;

        private bool _isCancellable;
        
        public EntityMoveEvent(Pawn pawn, Vector2 oldPosition, Vector2 newPosition)
        {
            _pawn = pawn;
            _oldPosition = oldPosition;
            _newPosition = newPosition;
        }
        
        public Vector2 GetOldPosition()
        {
            return _oldPosition;
        }
        
        public Vector2 GetNewPosition()
        {
            return _newPosition;
        }
        
        public Pawn GetPawn()
        {
            return _pawn;
        }

        public void Fire()
        {
            var data = new EntityMoveEventArgs
            {
                Pawn = _pawn,
                OldPosition = _oldPosition,
                NewPosition = _newPosition
            };
            
            OnEntityMove?.Invoke(this, data);

            if (!_isCancelled)
            {
                // Handle Movement
                if (_pawn is Player player)
                {
                    GameManager.GetInstance().GetPlayerController().HandleMovement();
                }
                else
                {
                    GameManager.GetInstance().GetEnemyController().HandleMovement();
                }
            }
        }

        public bool IsCancellable()
        {
            return _isCancellable;
        }

        public bool IsCancelled()
        {
            return _isCancelled;
        }

        public void SetCancelled(bool cancelled)
        {
            _isCancelled = cancelled;
        }
    }
}