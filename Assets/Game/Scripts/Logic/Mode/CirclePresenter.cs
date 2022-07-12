using UnityEngine;

namespace Game.Scripts.Logic.Mode
{
    public class CirclePresenter: IPresenter
    {
        private CircleView circleView;
        private CircleModel circleModel;
        private CircleController circleController;
        private PlayerView playerView;
        private RequirementView requirementView;

        public CirclePresenter(CircleView circleView, CircleModel circleModel, CircleController circleController, PlayerView playerView, RequirementView requirementView)
        {
            this.circleView = circleView;
            this.circleModel = circleModel;
            this.circleController = circleController;
            this.playerView = playerView;
            this.requirementView = requirementView;
        }

        private void OnTap()
        {
            if (circleModel.IsFinal)
            {
                requirementView.Destroy();
                playerView.OnShowHideControls();
            }
            Disable();
            playerView.Tool();
            circleView.Die();
            circleController.UnblockSpawn();
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