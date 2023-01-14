using System;
using UnityEngine;

namespace api.entity
{
    public abstract class Pawn : MonoBehaviour
    {
        [Header("Stats")] 
        public float health = 100.0f;
        public float damage = 100.0f;
        public float speed = 10.0f;
        public float jumpSpeed = 10.0f;

        [Header("Other")] 
        public SpriteRenderer sprite;
        public Rigidbody2D body;
        public Collider2D bodyCollider;

        public void Update()
        {
            Move();
        }

        public abstract void Move();

        public abstract void Spawn();
    }
}