using api.entity;
using game.entity;
using game.@event.args;
using UnityEngine;

namespace game.controller
{
    public class PlayerController : MonoBehaviour
    {
        private bool _isJumping;
        private bool _hasJumpCooldown;
        
        public void HandleMovement(EntityMoveEventArgs eventArgs)
        {
            var player = eventArgs.Pawn as Player;
            
            if (player == null) return;

            if (_isJumping) CheckIfStillJumping(player);
            
            switch (eventArgs.Direction)
            {
                case MovementDirection.Right:
                    player.sprite.flipX = false;
                    HandleMove(player);
                    break;
                
                case MovementDirection.Left:
                    player.sprite.flipX = true;
                    HandleMove(player);
                    break;

                case MovementDirection.Up:
                    if (_isJumping || _hasJumpCooldown) return;
                
                    _isJumping = true;
                    player.body.velocity = new Vector2(player.body.velocity.x, player.jumpSpeed);
                    
                    break;
                
                case MovementDirection.Down:
                    // Not necessary rn
                    break;

                default:
                    return;
            }
        }
        
        private void CheckIfStillJumping(Pawn pawn)
        {
            var hits = Physics2D.RaycastAll(pawn.transform.position, Vector2.down, 1.0f);

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
        
        private void HandleMove(Pawn pawn)
        {
            pawn.body.velocity = _isJumping ? new Vector2(Input.GetAxis("Horizontal") * pawn.jumpSpeed, pawn.body.velocity.y) 
                : new Vector2(Input.GetAxis("Horizontal") * pawn.speed, pawn.body.velocity.y);
        }
    }
}