using System;
using api.entity;
using game.entity;
using game.@event.args;
using UnityEngine;

namespace game.@event
{
    public class EntitySpawnEvent : api.@event.IEvent
    {
        public event EventHandler<EntitySpawnEventArgs> OnEntitySpawn;
        
        private readonly Pawn _pawn;
        
        private bool _isCancelled;

        private bool _isCancellable;
        
        public EntitySpawnEvent(Pawn pawn)
        {
            _pawn = pawn;
        }

        public Vector3 GetLocation()
        {
            return _pawn.transform.position;
        }

        public bool IsEnemy()
        {
            return _pawn.GetType() == typeof(Enemy);
        }

        public void Fire()
        {
            var data = new EntitySpawnEventArgs
            {
                Pawn = _pawn
            };

            OnEntitySpawn?.Invoke(this, data);
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