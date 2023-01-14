using System;
using api.entity;
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
            if (_isJumping) CheckIfStillJumping();

            // Move Right
            if (Input.GetKey(KeyCode.D))
            {
                sprite.flipX = false;
                HandleMove();
            }
            
            // Move Left
            if (Input.GetKey(KeyCode.A))
            {
                sprite.flipX = true;
                HandleMove();
            }

            // Jump
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
            {
                if (_isJumping || _hasJumpCooldown) return;
                
                _isJumping = true;
                body.velocity = new Vector2(body.velocity.x, jumpSpeed);
            }
            
            // Duck
            if (Input.GetKey(KeyCode.S))
            {
                // Mechanic not needed yet
            }
        }

        public override void Spawn()
        { 
            // Isn't needed for the player atm
        }

        private void HandleMove()
        {
            if (_isJumping)
            {
                Debug.Log("JumpSpeed");
                body.velocity = new Vector2(Input.GetAxis("Horizontal") * jumpSpeed, body.velocity.y);   
            }
            else
            {
                Debug.Log("Speed");
                body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
            }
        }

        private void CheckIfStillJumping()
        {
            var hits = Physics2D.RaycastAll(transform.position, Vector2.down, 1.0f);

            foreach (var hit in hits)
            {
                if (hit.collider.gameObject.CompareTag("Player")) continue;
                
                _isJumping = false;
                _hasJumpCooldown = true;
                        
                // Add a small delay before allowing another jump
                Invoke(nameof(RemoveJumpCooldown), 0.1f);
            }
        }
        
        private void RemoveJumpCooldown()
        {
            _hasJumpCooldown = false;
        }
    }
}