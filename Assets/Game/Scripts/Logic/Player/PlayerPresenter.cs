using System.Collections;
using Game.Scripts.UI;
using UnityEngine;

namespace Game.Scripts.Logic
{
    public class PlayerPresenter : IPresenter
    {
        private PlayerView playerView;
        
        private PlayerModel playerModel;
        private InputController inputController;

        private Rigidbody2D rb;

        public PlayerPresenter(PlayerView playerView, PlayerModel playerModel, InputController inputController)
        {
            this.playerView = playerView;
            this.playerModel = playerModel;
            this.inputController = inputController;
            rb = playerView.GetComponent<Rigidbody2D>();
        }


        public void Enable()
        {
            playerView.TapEvent += OnTap;
            playerView.GoToEvent += OnGoTo;
            playerView.TurnEvent += Turn;
        }
        
        public void Disable()
        {
            playerView.TapEvent -= OnTap;
            playerView.GoToEvent -= OnGoTo;
            playerView.TurnEvent -= Turn;
        }


        private void OnGoTo(Transform target)
        {
           
            var pos = target.position;
            var playerPos = playerView.transform.position;
            if (pos.x<= playerPos.x)
            {
                PlayerMove(Vector2.left);
            }
            else
            {
                PlayerMove(Vector2.right);
            }
            playerModel.IsMoving = false;
            
            playerView.AnimateTranslationToTarget(target,inputController);

        }
        
        

        private void OnTap()
        {
            playerView.Happy();
        }

        
        public void MovePlayer()
        {
            rb.velocity = playerModel.MovingDirection.normalized * playerModel.Speed;
          //  playerView.transform.Translate(playerModel.MovingDirection.normalized * playerModel.Speed);
        }
        
        private void PlayerMove(Vector2 direction)
        {
            Turn(direction);
            playerModel.IsMoving = true;
            
            playerView.Walk();
        }

        private void FlipPLayer()
        {
            var scale =  playerView.transform.localScale;
            scale.x *= -1;
            playerView.transform.localScale = scale;
        }

        public void MoveLeft()
        {
            PlayerMove(Vector2.left);
        }
        public void MoveRight()
        {
            PlayerMove(Vector2.right);
        }

        public void StopMoving()
        {
            rb.velocity = Vector2.zero;
            playerModel.IsMoving = false;
            playerView.Idle();
        }
        
        private void Turn(Vector2 direction)
        {
            if (!direction.Equals(playerModel.MovingDirection))
            {
                FlipPLayer();
            }

            playerModel.MovingDirection = direction;
        }
        
    }
}