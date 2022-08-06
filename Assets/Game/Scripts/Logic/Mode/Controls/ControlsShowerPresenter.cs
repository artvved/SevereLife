using UnityEngine;

namespace Game.Scripts.Logic.Mode
{
    public class ControlsShowerPresenter : IPresenter
    {
        private ControlsShowerView view;
        private PlayerView playerView;

        public ControlsShowerPresenter(ControlsShowerView view, PlayerView playerView)
        {
            this.view = view;
            this.playerView = playerView;
        }

        private void DoAction()
        {
           
            if (view.Show)
            {
                playerView.OnShowControls();
                view.OnNext();
            }
            else
            {
                playerView.OnHideControls();
                view.NextDoAction();
            }
           
        }

        public void Enable()
        {
            view.DoActionEvent += DoAction;
        }

        public void Disable()
        {
            view.DoActionEvent -= DoAction;
        }
    }
}