using UnityEngine;

namespace Game.Scripts.Logic
{
    public class PlayerPresenter : IPresenter
    {
        private PlayerView playerView;
        private PlayerModel playerModel;

        public PlayerPresenter(PlayerView view, PlayerModel model)
        {
            playerView = view;
            playerModel = model;
        }

        public void Enable()
        {
            playerView.TapEvent += OnTap;
        }
        
        public void Disable()
        {
            playerView.TapEvent -= OnTap;
        }

        private void OnTap()
        {
            playerView.Happy();
        }

        
        public void MovePlayer()
        {
            playerView.transform.Translate(playerModel.MovingDirection.normalized * playerModel.Speed);
        }
        
        private void PlayerMove(Vector2 direction)
        {
            if (!direction.Equals(playerModel.MovingDirection))
            {
                FlipPLayer();
            }
            playerModel.IsMoving = true;
            playerModel.MovingDirection = direction;
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
            playerModel.IsMoving = false;
            playerView.Idle();
        }
        
    }
}