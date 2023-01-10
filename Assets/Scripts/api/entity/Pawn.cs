using UnityEngine;

namespace api.entity
{
    public abstract class Pawn : MonoBehaviour
    {
        public float Health { get; set; }
        
        public float Damage { get; set; }
        
        public float Speed { get; set; }
        
        public abstract void Move();

        public abstract void Spawn();
    }
}