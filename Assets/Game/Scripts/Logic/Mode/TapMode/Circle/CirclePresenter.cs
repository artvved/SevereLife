using UnityEngine;

namespace Game.Scripts.Logic.Mode
{
    public class CirclePresenter: IPresenter
    {
        private CircleView circleView;
        private CircleModel circleModel;
        private CircleSpawner circleSpawner;
        private PlayerView playerView;
        private CircleTapModeTriggerView circleTapModeTriggerView;

        public CirclePresenter(CircleView circleView, CircleModel circleModel, CircleSpawner circleSpawner, PlayerView playerView, CircleTapModeTriggerView circleTapModeTriggerView)
        {
            this.circleView = circleView;
            this.circleModel = circleModel;
            this.circleSpawner = circleSpawner;
            this.playerView = playerView;
            this.circleTapModeTriggerView = circleTapModeTriggerView;
        }

        private void OnTap()
        {
            if (circleModel.IsFinal)
            {
                circleTapModeTriggerView.Destroy();
                playerView.OnShowHideControls();
            }
            Disable();
            playerView.Tool();
            circleView.Die();
            circleSpawner.UnblockSpawn();
        }
        
        public void Enable()
        {
            circleView.TapEvent += OnTap;
        }

        public void Disable()
        {
            circleView.TapEvent -= OnTap;
        }
    }
}