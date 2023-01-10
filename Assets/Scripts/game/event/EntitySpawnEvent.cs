using System;
using api.entity;
using game.entity;
using UnityEngine;

namespace game.@event
{
    public class EntitySpawnEvent : api.@event.IEvent
    {
        public event EventHandler<EntitySpawnEventArgs> OnEntitySpawn;
        
        private readonly Pawn _pawn;
        
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
            var data = new EntitySpawnEventArgs();

            try
            {
                Debug.Log("Enemy spawned, handling event...");

                data.Pawn = _pawn;
                _pawn.Spawn();
                
                OnComplete(data);
            } catch (Exception e)
            {
                Debug.Log("Error occurred while handling event: " + e.Message);
            }
        }

        public virtual void OnComplete(EventArgs e)
        {
            OnEntitySpawn?.Invoke(this, (EntitySpawnEventArgs) e);
        }
    }
}