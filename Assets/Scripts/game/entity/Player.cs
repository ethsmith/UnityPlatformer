using System;
using api.entity;
using game.controller;
using game.@event;
using UnityEngine;

namespace game.entity
{
    public class Player : Pawn
    {
        public Camera playerCamera;

        private bool _isJumping;
        private bool _hasJumpCooldown;

        public void LateUpdate()
        {
            var cameraTransform = playerCamera.transform;
            var origCameraPosition = cameraTransform.position;
            var newCameraPosition = new Vector3(transform.position.x + 5, origCameraPosition.y, -10);
            
            cameraTransform.position = newCameraPosition;
        }

        public override void Move()
        {
            // Move Right
            if (Input.GetKey(KeyCode.D))
            {
                new EntityMoveEvent(this, MovementDirection.Right);
            }
            
            // Move Left
            if (Input.GetKey(KeyCode.A))
            {
                new EntityMoveEvent(this, MovementDirection.Left);
            }

            // Jump
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
            {
                new EntityMoveEvent(this, MovementDirection.Up);
            }
            
            // Duck
            if (Input.GetKey(KeyCode.S))
            {
                new EntityMoveEvent(this, MovementDirection.Down);
            }
        }

        public override void Spawn()
        { 
            // Isn't needed for the player atm
        }
    }
}